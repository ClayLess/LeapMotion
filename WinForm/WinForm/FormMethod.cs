﻿using System;
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
        public FormHandCompare()
        {
            using (ctrl = new Controller())
            {
                ctrl.SetPolicy(Controller.PolicyFlag.POLICY_BACKGROUND_FRAMES);
                ll = new LeapListener();
            }
            runflag = false;
        }
        public void StartListen()
        {
            if (!runflag)
            {
                ctrl.FrameReady += ll.OnFrame;
                runflag = true;
                ThreadLeapListener = new Thread(ListeningThread);
                ThreadLeapListener.IsBackground = true;
                ThreadLeapListener.Start();
            }
        }
        public void StopListen()
        {
            if (runflag)
            {
                runflag = false;
                //ThreadLeapListener.Abort();
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
        public void WriteToForm()
        {
            try
            {
                MainForm Main = Application.OpenForms[FormName] as MainForm;
                TextBox CCom = Application.OpenForms[FormName].Controls[Ctrl_Compare] as TextBox;
                TextBox CEcu = Application.OpenForms[FormName].Controls[Ctrl_Euclid] as TextBox;
                TextBox CDot = Application.OpenForms[FormName].Controls[Ctrl_DotMult] as TextBox;
                Label Status = Application.OpenForms[FormName].Controls[Ctrl_Answer] as Label;
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
        private Controller ctrl;
        private LeapListener ll;
        private Thread ThreadLeapListener;
        public string Answer;
        public int Answer_Euclid;
        public int Answer_Compare;
        public int Answer_Dot_Product;
        public bool changeflag;
        public bool runflag;
        public delegate void Chang_Text(TextBox tb, string text);
        public delegate void Chang_Lab(Label tb, string text);
        private string FormName;
        private string Ctrl_Compare;
        private string Ctrl_Euclid;
        private string Ctrl_DotMult;
        private string Ctrl_Answer;
    }
    public class LeapListener
    {
        public LeapListener()
        {
            Answer_Euclid = 0;
            Answer_Compare = 0;
            Answer_Dot_Product = 0;
            changeflag = false;
            answer = "";
        }
        public void OnFrame(object sender, FrameEventArgs args)
        {
            // Get the most recent frame and report some basic information
            Frame frame = args.frame;
            
            if (frame.Hands.Count == 2)
            {
                
                HKD0.Load(frame.Hands[0]);
                HKD1.Load(frame.Hands[1]);
                HKD0.Transform(HKD0.GetRIMatrix());
                if (frame.Hands[0].IsLeft == frame.Hands[1].IsLeft)
                {
                    HKD1.Transform(HKD1.GetRIMatrix());
                }
                else
                {
                    HKD1.Transform(HKD1.MirrorXRI());
                }
                Normalized.Hand_Normalized(ref HKD0, ref HKD1);
                Compare_Method();
                //
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
        }
        private void clear()
        {
            Answer_Compare = 0;
            Answer_Dot_Product = 0;
            Answer_Euclid = 0;
        }
        private HandKeyData HKD0 = new HandKeyData();
        private HandKeyData HKD1 = new HandKeyData();
        public string answer;
        public int Answer_Euclid;
        public int Answer_Compare;
        public int Answer_Dot_Product;
        public bool changeflag;
    }
}