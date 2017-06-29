/******************************************************************************\
* Copyright (C) 2012-2016 Leap Motion, Inc. All rights reserved.               *
* Leap Motion proprietary and confidential. Not for distribution.              *
* Use subject to the terms of the Leap Motion SDK Agreement available at       *
* https://developer.leapmotion.com/sdk_agreement, or another agreement         *
* between Leap Motion and you, your company or other organization.             *
\******************************************************************************/

#include <iostream>
#include <cstring>
#include "Leap.h"
#include"MapChange.h"

using namespace Leap;

class SampleListener : public Listener {
  public:
    virtual void onInit(const Controller&);
    virtual void onConnect(const Controller&);
    virtual void onDisconnect(const Controller&);
    virtual void onExit(const Controller&);
    virtual void onFrame(const Controller&);
    virtual void onFocusGained(const Controller&);
    virtual void onFocusLost(const Controller&);
    virtual void onDeviceChange(const Controller&);
    virtual void onServiceConnect(const Controller&);
    virtual void onServiceDisconnect(const Controller&);
    virtual void onServiceChange(const Controller&);
    virtual void onDeviceFailure(const Controller&);
    virtual void onLogMessage(const Controller&, MessageSeverity severity, int64_t timestamp, const char* msg);
};

const std::string fingerNames[] = {"Thumb", "Index", "Middle", "Ring", "Pinky"};
const std::string boneNames[] = {"Metacarpal", "Proximal", "Middle", "Distal"};

void SampleListener::onInit(const Controller& controller) {
  std::cout << "Initialized" << std::endl;
}

void SampleListener::onConnect(const Controller& controller) {
  std::cout << "Connected" << std::endl;
}

void SampleListener::onDisconnect(const Controller& controller) {
  // Note: not dispatched when running in a debugger.
  std::cout << "Disconnected" << std::endl;
}

void SampleListener::onExit(const Controller& controller) {
  std::cout << "Exited" << std::endl;
}

void SampleListener::onFrame(const Controller& controller) 
{
	Mapchange mp;
	const Frame frame = controller.frame(); //获取设备的此时刻的帧
	HandList hands = frame.hands();         //获取该帧中的手的列表
	for (HandList::const_iterator hl = hands.begin(); hl != hands.end(); ++hl) 
	{
		//遍历手的列表

		const Hand hand = *hl; //将获得的手赋给hand

		if (hand.isRight()) 
		{
			//判断是否为右手
			const FingerList fingers = hand.fingers(); //获取手指列表
			const Finger finger0 = fingers[0];         //获取拇指
			const Finger finger1 = fingers[1];         //获取食指
			const Finger finger2 = fingers[2];         //获取中指
			const Finger finger3 = fingers[3];         //获取无名指
			const Finger finger4 = fingers[4];         //获取小指
			Vector handSpeed = hand.palmVelocity();    //获取手掌的速度向量
			Vector handCenter = hand.palmPosition();   //获取手掌中心的位置坐标

			if (finger0.isExtended() && finger1.isExtended() && finger2.isExtended() && finger3.isExtended() && finger4.isExtended())
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
					//mp.MapEnlarge();                        //放大
					mp.MapNarrow();
					cout << "放大" << handSpeed.y << endl;
				}
				else if (handSpeed.y < -400 && handCenter.y<100)
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

void SampleListener::onFocusGained(const Controller& controller) {
  std::cout << "Focus Gained" << std::endl;
}

void SampleListener::onFocusLost(const Controller& controller) {
  std::cout << "Focus Lost" << std::endl;
}

void SampleListener::onDeviceChange(const Controller& controller) {
  std::cout << "Device Changed" << std::endl;
  const DeviceList devices = controller.devices();

  for (int i = 0; i < devices.count(); ++i) {
    std::cout << "id: " << devices[i].toString() << std::endl;
    std::cout << "  isStreaming: " << (devices[i].isStreaming() ? "true" : "false") << std::endl;
    std::cout << "  isSmudged:" << (devices[i].isSmudged() ? "true" : "false") << std::endl;
    std::cout << "  isLightingBad:" << (devices[i].isLightingBad() ? "true" : "false") << std::endl;
  }
}

void SampleListener::onServiceConnect(const Controller& controller) {
  std::cout << "Service Connected" << std::endl;
}

void SampleListener::onServiceDisconnect(const Controller& controller) {
  std::cout << "Service Disconnected" << std::endl;
}

void SampleListener::onServiceChange(const Controller& controller) {
  std::cout << "Service Changed" << std::endl;
}

void SampleListener::onDeviceFailure(const Controller& controller) {
  std::cout << "Device Error" << std::endl;
  const Leap::FailedDeviceList devices = controller.failedDevices();

  for (FailedDeviceList::const_iterator dl = devices.begin(); dl != devices.end(); ++dl) {
    const FailedDevice device = *dl;
    std::cout << "  PNP ID:" << device.pnpId();
    std::cout << "    Failure type:" << device.failure();
  }
}

void SampleListener::onLogMessage(const Controller&, MessageSeverity s, int64_t t, const char* msg) {
  switch (s) {
  case Leap::MESSAGE_CRITICAL:
    std::cout << "[Critical]";
    break;
  case Leap::MESSAGE_WARNING:
    std::cout << "[Warning]";
    break;
  case Leap::MESSAGE_INFORMATION:
    std::cout << "[Info]";
    break;
  case Leap::MESSAGE_UNKNOWN:
    std::cout << "[Unknown]";
  }
  std::cout << "[" << t << "] ";
  std::cout << msg << std::endl;
}

int main(int argc, char** argv) {
  // Create a sample listener and controller
  SampleListener listener;
  Controller controller;

  // Have the sample listener receive events from the controller
  controller.addListener(listener);

  if (argc > 1 && strcmp(argv[1], "--bg") == 0)
    controller.setPolicy(Leap::Controller::POLICY_BACKGROUND_FRAMES);

  controller.setPolicy(Leap::Controller::POLICY_ALLOW_PAUSE_RESUME);

  // Keep this process running until Enter is pressed
  std::cout << "Press Enter to quit, or enter 'p' to pause or unpause the service..." << std::endl;

  bool paused = false;
  while (true) {
    char c = std::cin.get();
    if (c == 'p') {
      paused = !paused;
      controller.setPaused(paused);
      std::cin.get(); //skip the newline
    }
    else
      break;
  }

  // Remove the sample listener when done
  controller.removeListener(listener);

  return 0;
}
