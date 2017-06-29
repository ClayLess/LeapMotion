#include"MapChange.h"
#include <iostream>
#include <string.h>
#include "Leap.h"

using namespace Leap;

int main()
{
	Controller controller; //����Leap Motion
	Mapchange mp;         
	while (1)              //���ϻ�ȡ֡
	{
		const Frame frame = controller.frame(); //��ȡ�豸�Ĵ�ʱ�̵�֡
		HandList hands = frame.hands();         //��ȡ��֡�е��ֵ��б�
		for (HandList::const_iterator hl = hands.begin(); hl != hands.end(); ++hl) {
        //�����ֵ��б�

			const Hand hand = *hl; //����õ��ָ���hand

			if (hand.isRight()) {
            //�ж��Ƿ�Ϊ����
				const FingerList fingers = hand.fingers(); //��ȡ��ָ�б�
				const Finger finger0 = fingers[0];         //��ȡĴָ
				const Finger finger1 = fingers[1];         //��ȡʳָ
				const Finger finger2 = fingers[2];         //��ȡ��ָ
				const Finger finger3 = fingers[3];         //��ȡ����ָ
				const Finger finger4 = fingers[4];         //��ȡСָ
				Vector handSpeed = hand.palmVelocity();    //��ȡ���Ƶ��ٶ�����
				Vector handCenter = hand.palmPosition();   //��ȡ�������ĵ�λ������

				if (finger0.isExtended() && finger1.isExtended() && finger2.isExtended() && finger3.isExtended() && finger4.isExtended() )
				{
				//�ж���ָ�Ƿ��쿪
					if (handCenter.z < -90)                     //��������λ������zС��-90
					{
						mp.MapMoveup();                         //�����ƶ�
						cout << "����" << handCenter.z << endl;
					}
					else if (handCenter.z > 90)
					{
						mp.MapMovewdown();
						cout << "����" << handCenter.z << endl;
					}
					if (handSpeed.y > 400 && handCenter.y>200)  //�����ٶ�����y����400������������λ������y����200
					{
						//mp.MapEnlarge();   //�Ŵ�
						mp.MapNarrow();
						cout << "�Ŵ�" << handSpeed.y << endl;
					}
					else if (handSpeed.y < -400 &&handCenter.y<100 )
					{
						//mp.MapNarrow();
						mp.MapEnlarge();
						cout << "��С" << handSpeed.y << endl;
					}
					if (handCenter.x > 90)
					{
						mp.MapMoveright();
						cout << "����" << handCenter.x << endl;
					}
					else if (handCenter.x < -100)
					{
						mp.MapMoveleft();
						cout << "����" << handCenter.x << endl;
					}
					
				}

			}
		}
	}
    return 0;
}
