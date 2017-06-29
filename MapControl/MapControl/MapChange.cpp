#ifndef MAPCHANGE_CPP
#define MAPCHANGE_CPP
#include "MapChange.h"
#define ST 10
#define DE 60

int Mapchange::pre_dis = -1;
int Mapchange::pre_y = -1;
int Mapchange::pre_x = -1;

void Mapchange::MapEnlarge()//�������Ϲ�������ͼ�Ŵ�
{
	::GetCursorPos(&point);
    ::mouse_event(MOUSEEVENTF_WHEEL,point.x,point.y,120,0);//��Ȼ��������
}
void Mapchange::MapNarrow()//�������¹�������ͼ��С
{
	::GetCursorPos(&point);
    ::mouse_event(MOUSEEVENTF_WHEEL,point.x,point.y,-120,0);
}
void Mapchange::MapMoveup()//�����ƶ���ͼ
{
	Sleep(ST);
    ::keybd_event(38,0,0,0);//��
    Sleep(DE);//�������ŵ�ʱ��
    ::keybd_event(38,0,KEYEVENTF_KEYUP,0);
}
void Mapchange::MapMovewdown()//�����ƶ���ͼ
{
	Sleep(ST);
    ::keybd_event(40,0,0,0);//��
    Sleep(DE);
    ::keybd_event(40,0,KEYEVENTF_KEYUP,0);
}
void Mapchange::MapMoveleft()//�����ƶ���ͼ
{
	Sleep(ST);
    ::keybd_event(37,0,0,0);//��
    Sleep(DE);
    ::keybd_event(37,0,KEYEVENTF_KEYUP,0);
}
void Mapchange::MapMoveright()//�����ƶ���ͼ
{
	Sleep(ST);
    ::keybd_event(39,0,0,0);//��
    Sleep(DE);
    ::keybd_event(39,0,KEYEVENTF_KEYUP,0);
}
#endif