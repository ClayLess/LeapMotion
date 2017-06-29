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
	const Frame frame = controller.frame(); //��ȡ�豸�Ĵ�ʱ�̵�֡
	HandList hands = frame.hands();         //��ȡ��֡�е��ֵ��б�
	for (HandList::const_iterator hl = hands.begin(); hl != hands.end(); ++hl) 
	{
		//�����ֵ��б�

		const Hand hand = *hl; //����õ��ָ���hand

		if (hand.isRight()) 
		{
			//�ж��Ƿ�Ϊ����
			const FingerList fingers = hand.fingers(); //��ȡ��ָ�б�
			const Finger finger0 = fingers[0];         //��ȡĴָ
			const Finger finger1 = fingers[1];         //��ȡʳָ
			const Finger finger2 = fingers[2];         //��ȡ��ָ
			const Finger finger3 = fingers[3];         //��ȡ����ָ
			const Finger finger4 = fingers[4];         //��ȡСָ
			Vector handSpeed = hand.palmVelocity();    //��ȡ���Ƶ��ٶ�����
			Vector handCenter = hand.palmPosition();   //��ȡ�������ĵ�λ������

			if (finger0.isExtended() && finger1.isExtended() && finger2.isExtended() && finger3.isExtended() && finger4.isExtended())
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
					//mp.MapEnlarge();                        //�Ŵ�
					mp.MapNarrow();
					cout << "�Ŵ�" << handSpeed.y << endl;
				}
				else if (handSpeed.y < -400 && handCenter.y<100)
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
