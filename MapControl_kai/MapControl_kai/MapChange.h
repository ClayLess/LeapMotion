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
	static int pre_dis;//判断地图是放大或缩小
	static int pre_y;//判断地图向上或向下
	static int pre_x;//判断地图向左或向右

	void MapEnlarge();//滚轮向上滚动，地图放大
	void MapNarrow();//滚轮向下滚动，地图缩小
	void MapMoveup();//向上移动地图
	void MapMovewdown();//向下移动地图
	void MapMoveleft();//向左移动地图
	void MapMoveright();//向右移动地图
};