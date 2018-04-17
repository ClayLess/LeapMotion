using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using Leap;
using Leap.Unity;
using HandDatas;
using Compare_Normalized;
using UnityEngine.UI;
public class HandTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        using (controller = new Leap.Controller())
        {
            controller.SetPolicy(Leap.Controller.PolicyFlag.POLICY_ALLOW_PAUSE_RESUME);

            // Set up our listener:
            test = new MyListener();
            controller.FrameReady += test.OnFrame;
        }
        click_flag = true;
        click_str = "";
        
    }
    // Update is called once per frame
    void Update()
    {
           
    }
    void OnGUI()
    {
        //controller.FrameReady += test.OnFrame;
        GUI.skin.label.fontSize = 40;
        //if(click_flag)
        GUI.Label(new Rect(/*Screen.width - 400*/10, 10, Screen.width, Screen.height), test.answer.ToString());
        Thread.Sleep(10);
        //else
        //{
            
        //    GUI.Label(new Rect(/*Screen.width - 400*/10, 10, Screen.width, Screen.height),"Pause");
        //}
        
    }
    /*
    public void On_Click(GameObject Sender)
    {
        switch (Sender.name)
        {
            case "TEST":
                Console.WriteLine("BUTTON CLICK");
                break;
        }
    }
    */
    
    public void OnClick()
    {
        Text txt = GameObject.Find("btnPause/Text").GetComponent<Text>();
        //if(MyObj.name=="Button_Test")
        if (click_flag)
        {
            //Text txt = GameObject.Find("Button_Test/Text").GetComponent<Text>();
            txt.text = "Continue";
            controller.FrameReady -= test.OnFrame;
            test.answer = "Pause";
        }
        else
        {
            
            
            txt.text = "Pause";
            controller.FrameReady += test.OnFrame;
        }
        click_flag = !click_flag;
    }
    string click_str;
    bool click_flag;
    MyListener test;
    Leap.IController controller;

}
class MyListener
{
    public void OnFrame(object sender, FrameEventArgs args)
    {
        // Get the most recent frame and report some basic information
        Frame frame = args.frame;
        if (frame.Hands.Count == 2)
        {
            answer = "对比结果：" + "\n";
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
        }
        //调试分支
        /*
        else if (frame.Hands.Count == 1)
        {
            HKD0.Load(frame.Hands[0]);
            HKD1.Load(frame.Hands[0]);
            answer = "单手归零测试：\n";
            Compare_Method();
        }
        */
        else if (frame.Hands.Count > 2)
        {
            answer = "To many hands!!!";

        }
        else
        {
            answer = "Need " + (2 - frame.Hands.Count).ToString() + " more hands";
        }
    }
    private void Compare_Method()
    {
        answer += "对应点距离和之差：" + Convert.ToInt64(Compare.Hand_Compare(HKD0, HKD1)).ToString() + "\n"
                + "欧几里得距离差：" + Convert.ToInt64(Compare.Hand_Euclid(HKD0, HKD1)).ToString() + "\n"
                + "点积差：" + Convert.ToInt64(Compare.Hand_Dot_Product(HKD0, HKD1)) + "\n"
                ;
        for (int i = 0; i < 5; i++)
        {
            answer += ((FingerKeyData.FingerType)i).ToChinese()
                + ":" + Convert.ToInt64(Compare.Finger_Compare(HKD0.Finger_[i], HKD1.Finger_[i])).ToString()
                + "\n";
        }
    }
    private HandKeyData HKD0 = new HandKeyData();
    private HandKeyData HKD1 = new HandKeyData();
    public string answer;
}