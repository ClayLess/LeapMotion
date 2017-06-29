#ifndef MAPCHANGE_CPP
#define MAPCHANGE_CPP
#include "MapChange.h"
#define ST 10
#define DE 60

int Mapchange::pre_dis = -1;
int Mapchange::pre_y = -1;
int Mapchange::pre_x = -1;

void Mapchange::MapEnlarge()//滚轮向上滚动，地图放大
{
	::GetCursorPos(&point);
    ::mouse_event(MOUSEEVENTF_WHEEL,point.x,point.y,120,0);//自然滚动方向
}
void Mapchange::MapNarrow()//滚轮向下滚动，地图缩小
{
	::GetCursorPos(&point);
    ::mouse_event(MOUSEEVENTF_WHEEL,point.x,point.y,-120,0);
}
void Mapchange::MapMoveup()//向上移动地图
{
	Sleep(ST);
    ::keybd_event(38,0,0,0);//上
    Sleep(DE);//长按不放的时间
    ::keybd_event(38,0,KEYEVENTF_KEYUP,0);
}
void Mapchange::MapMovewdown()//向下移动地图
{
	Sleep(ST);
    ::keybd_event(40,0,0,0);//下
    Sleep(DE);
    ::keybd_event(40,0,KEYEVENTF_KEYUP,0);
}
void Mapchange::MapMoveleft()//向左移动地图
{
	Sleep(ST);
    ::keybd_event(37,0,0,0);//左
    Sleep(DE);
    ::keybd_event(37,0,KEYEVENTF_KEYUP,0);
}
void Mapchange::MapMoveright()//向右移动地图
{
	Sleep(ST);
    ::keybd_event(39,0,0,0);//右
    Sleep(DE);
    ::keybd_event(39,0,KEYEVENTF_KEYUP,0);
}
#endif