using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leap;
using Compare_Normalized;
using HandDatas;
using System.Threading;
using System.Windows.Forms;
using WinForm;

namespace FormMethod
{
    class FormHandCompare
    {
        //create background listenning thread
        public FormHandCompare()
        {
            using (ctrl = new Controller())
            {
                ctrl.SetPolicy(Controller.PolicyFlag.POLICY_BACKGROUND_FRAMES);
                ll = new LeapListener();
            }
            runflag = false;
            Answer_Fingers = new string[5];
        }
        //run thread 
        public void StartListen()
        {
            //runflag to make sure just 1 delegate in the ctrl.FrameReady queue
            if (!runflag)
            {
                ctrl.FrameReady += ll.OnFrame;
                runflag = true;
                ThreadLeapListener = new Thread(ListeningThread);//set new listening thread
                ThreadLeapListener.IsBackground = true;
                ThreadLeapListener.Start();
            }
        }

        public void StopListen()
        {
            //
            if (runflag)
            {
                runflag = false;
                ctrl.FrameReady -= ll.OnFrame;
            }
        }
        public void SetForm(string FN,string CCom, string CEcu,string CDot,string CAn)
        {
            FormName = FN;
            Ctrl_Compare = CCom;
            Ctrl_Euclid = CEcu;
            Ctrl_DotMult = CDot;
            Ctrl_Answer = CAn;
        }
        public void ListeningThread()
        {
            while(runflag)
            {
                try
                {
                    //demo
                    for(int i=0;i<5;i++)
                    {
                        Answer_Fingers[i] = ll.Answer_Fingers[i];
                    }
                    Answer_Euclid = ll.Answer_Euclid;
                    Answer_Compare = ll.Answer_Compare;
                    Answer_Dot_Product = ll.Answer_Dot_Product;
                    changeflag = ll.changeflag;
                    Answer = ll.answer;
                    WriteToForm();
                    Thread.Sleep(30);
                }
                catch
                {
                    MessageBox.Show("Listener Error");
                }
            }
        }

        //return resault to mainform
        public void WriteToForm()
        {
            try
            {
                MainForm Main = Application.OpenForms[FormName] as MainForm;
                TextBox CCom = Application.OpenForms[FormName].Controls[Ctrl_Compare] as TextBox;
                TextBox CEcu = Application.OpenForms[FormName].Controls[Ctrl_Euclid] as TextBox;
                TextBox CDot = Application.OpenForms[FormName].Controls[Ctrl_DotMult] as TextBox;
                Label Status = Application.OpenForms[FormName].Controls[Ctrl_Answer] as Label;
                //+listviewer
                ListView CFingers = Application.OpenForms[FormName].Controls["FingerList"] as ListView;
                //
                CCom.BeginInvoke(new Chang_Text(Change_Text_Method), CCom, Answer_Compare.ToString());
                CEcu.BeginInvoke(new Chang_Text(Change_Text_Method), CEcu, Answer_Euclid.ToString());
                CDot.BeginInvoke(new Chang_Text(Change_Text_Method), CDot, Answer_Dot_Product.ToString());
                
                if (Answer != null)
                {

                }
                else
                {
                    Answer = "Leap Motion Not Online";
                }
                CFingers.BeginInvoke(new Chang_List(Change_Text_Method), CFingers, Answer_Fingers);
                Status.BeginInvoke(new Chang_Lab(Change_Text_Method), Status, Answer);
            }
            catch
            {
                MessageBox.Show("Cannot Find Form Or Controller!!!");
            }
        }
        public void Change_Text_Method(TextBox tb, string text)
        {
            tb.Text = text;
        }
        public void Change_Text_Method(Label tb, string text)
        {
            tb.Text = text;
        }
        public void Change_Text_Method(ListView tb, string[] text)
        {
            tb.Clear();
            foreach (string str in text)
            {
                tb.Items.Add(str);
            }
        }
        private Controller ctrl;//leap motion controller
        public LeapListener ll;//leap motion listener
        private Thread ThreadLeapListener;//background run listenning thread
        //Answer (data wait to write to main form)
        public string Answer;//message shows on form
        public int Answer_Euclid;//plus euclidean distance
        public int Answer_Compare;//plus distance
        public int Answer_Dot_Product;//plus dot product
        public string[] Answer_Fingers;//per finger
        public bool changeflag;//data change sign
        public bool runflag;//thread run sign
        public delegate void Chang_Text(TextBox tb, string text);
        public delegate void Chang_Lab(Label tb, string text);
        public delegate void Chang_List(ListView tb, string[] text);
        //name of controller on form
        private string FormName;
        private string Ctrl_Compare;
        private string Ctrl_Euclid;
        private string Ctrl_DotMult;
        private string Ctrl_Answer;
        //virtual hand
        
    }
    public class LeapListener
    {
        public bool vhand_flag = false;
        public Hand vhand = new Hand();
        public LeapListener()
        {
            Answer_Euclid = 0;//
            Answer_Compare = 0;//
            Answer_Dot_Product = 0;//
            changeflag = false;//data change flag
            answer = "";
            Answer_Fingers = new string[5];
        }

        //action on every frame.
        public void OnFrame(object sender, FrameEventArgs args)
        {
            // Get the most recent frame and report some basic information
            Frame frame = args.frame;
            
            if(copyflag)
            {
                nowHand0.CopyFrom(frame.Hands[0]);
                copyflag = false;
            }
            //add virtual hand
            if (vhand_flag)
            {
                VirtualHand.AddHand(ref frame, vhand);
            }
            //works when 2 hands in the hans pool
            if (frame.Hands.Count == 2)
            {
                
                HKD0.Load(frame.Hands[0]);
                HKD1.Load(frame.Hands[1]);
                HKD0.Transform(HKD0.GetRIMatrix());
                //the same side then just transform
                if (frame.Hands[0].IsLeft == frame.Hands[1].IsLeft)
                {
                    HKD1.Transform(HKD1.GetRIMatrix());
                }
                //not the same then transform after mirror on x-axis
                else
                {
                    HKD1.Transform(HKD1.MirrorXRI());
                }
                Normalized.Hand_Normalized(ref HKD0, ref HKD1);
                Compare_Method();
                changeflag = true;
                Thread.Sleep(10);
            }
            else if (frame.Hands.Count > 2)
            {
                changeflag = false;
                answer = "To many hands!!!";
                clear();
            }
            else
            {
                changeflag = false;
                answer = "Need " + (2 - frame.Hands.Count).ToString() + " more hands";
                clear();
            }
        }
        private void Compare_Method()
        {
            answer = "Running...";
            Answer_Compare = Convert.ToInt32(Compare.Hand_Compare(HKD0, HKD1));
            Answer_Euclid = Convert.ToInt32(Compare.Hand_Euclid(HKD0, HKD1));
            Answer_Dot_Product = Convert.ToInt32(Compare.Hand_Dot_Product(HKD0, HKD1));
            for(int i=0;i<5;i++)
            {
                Answer_Fingers[i] = Fin(i)+": " +Convert.ToInt32(HKD0.Finger_[i].TipPosition.DistanceTo(HKD1.Finger_[i].TipPosition)).ToString();
            }
        }
        private void clear()
        {
            Answer_Compare = 0;
            Answer_Dot_Product = 0;
            Answer_Euclid = 0;
        }
        private string Fin(int id)
        {
            string an;
            switch(id)
            {
                case 0:
                    an = "Thumb";
                    break;
                case 1:
                    an = "Index";
                    break;
                case 2:
                    an = "Middle";
                    break;
                case 3:
                    an = "Ring";
                    break;
                case 4:
                    an = "Pinky";
                    break;
                default:
                    an = "NULL";
                    break;
            }
            return an;
        }
        private HandKeyData HKD0 = new HandKeyData();
        private HandKeyData HKD1 = new HandKeyData();
        public string answer;
        public int Answer_Euclid;
        public int Answer_Compare;
        public int Answer_Dot_Product;
        public string[] Answer_Fingers;
        public bool changeflag;
        //public Hand[] handspool;
        private Hand nowHand0;
        private bool copyflag;
        public Hand GetNowHand0()
        {
            nowHand0 = new Hand();
            copyflag = true;
            while(copyflag)
            {
                Thread.Sleep(1);
            }
            return nowHand0;
        }
    }
}
