#include <cstdio>
#include <iostream>
#include <ctime>
#include <queue>
#include <cmath>
#include <algorithm>
#include <functional>
#include <cstring>
#include <stdlib.h>
#include <windows.h>
using namespace std;

class Mapchange
{
public:
	POINT point;
	static int pre_dis;//�жϵ�ͼ�ǷŴ����С
	static int pre_y;//�жϵ�ͼ���ϻ�����
	static int pre_x;//�жϵ�ͼ���������

	void MapEnlarge();//�������Ϲ�������ͼ�Ŵ�
	void MapNarrow();//�������¹�������ͼ��С
	void MapMoveup();//�����ƶ���ͼ
	void MapMovewdown();//�����ƶ���ͼ
	void MapMoveleft();//�����ƶ���ͼ
	void MapMoveright();//�����ƶ���ͼ
};