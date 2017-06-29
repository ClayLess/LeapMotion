#include"MapChange.h"
#include <iostream>
#include <string.h>
#include "Leap.h"

using namespace Leap;

int main()
{
	Controller controller; //连接Leap Motion
	Mapchange mp;         
	while (1)              //不断获取帧
	{
		const Frame frame = controller.frame(); //获取设备的此时刻的帧
		HandList hands = frame.hands();         //获取该帧中的手的列表
		for (HandList::const_iterator hl = hands.begin(); hl != hands.end(); ++hl) {
        //遍历手的列表

			const Hand hand = *hl; //将获得的手赋给hand

			if (hand.isRight()) {
            //判断是否为右手
				const FingerList fingers = hand.fingers(); //获取手指列表
				const Finger finger0 = fingers[0];         //获取拇指
				const Finger finger1 = fingers[1];         //获取食指
				const Finger finger2 = fingers[2];         //获取中指
				const Finger finger3 = fingers[3];         //获取无名指
				const Finger finger4 = fingers[4];         //获取小指
				Vector handSpeed = hand.palmVelocity();    //获取手掌的速度向量
				Vector handCenter = hand.palmPosition();   //获取手掌中心的位置坐标

				if (finger0.isExtended() && finger1.isExtended() && finger2.isExtended() && finger3.isExtended() && finger4.isExtended() )
				{
				//判断五指是否都伸开
					if (handCenter.z < -90)                     //手掌中心位置坐标z小于-90
					{
						mp.MapMoveup();                         //向上移动
						cout << "向上" << handCenter.z << endl;
					}
					else if (handCenter.z > 90)
					{
						mp.MapMovewdown();
						cout << "向下" << handCenter.z << endl;
					}
					if (handSpeed.y > 400 && handCenter.y>200)  //手掌速度向量y大于400并且手掌中心位置坐标y大于200
					{
						//mp.MapEnlarge();   //放大
						mp.MapNarrow();
						cout << "放大" << handSpeed.y << endl;
					}
					else if (handSpeed.y < -400 &&handCenter.y<100 )
					{
						//mp.MapNarrow();
						mp.MapEnlarge();
						cout << "缩小" << handSpeed.y << endl;
					}
					if (handCenter.x > 90)
					{
						mp.MapMoveright();
						cout << "向右" << handCenter.x << endl;
					}
					else if (handCenter.x < -100)
					{
						mp.MapMoveleft();
						cout << "向左" << handCenter.x << endl;
					}
					
				}

			}
		}
	}
    return 0;
}
