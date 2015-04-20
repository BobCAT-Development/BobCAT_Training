#ifndef HDMI_CAPTURE_DS_ICE
#define HDMI_CAPTURE_DS_ICE

module Services 
{
	exception HdmiCaptureDSEx
	{
		string ExMessage;
	};
	
	enum CompressionType
	{
		YUV8bits,
		YUV10bits,
		RGB10bits,
	};
	
	enum VideoType
	{
		HD720p50,
		HD720p60,
		HD1080i50,
		HD1080i60,
		HD1080p50,
		HD1080p60,
	};

	sequence<string> StringList;
	
	interface HdmiCaptureDSEvents
	{	
		void EndCaptureReached();
		void SendMessage(string message);
	};
	
	interface HdmiCaptureDS
	{
		void GetAllVideoCaptureDevices(out StringList captureDeviceList) throws HdmiCaptureDSEx;
		void GetVideoCaptureDevice(out string deviceName, out string vendorId) throws HdmiCaptureDSEx;
		//void SetVideoCaptureDevice(string captureDeviceName)  throws HdmiCaptureDSEx;
		
		void GetPixelFormat(out CompressionType pixelFormat);
		void SetPixelFormat(CompressionType pixelFormat);
		
		void GetVideoFormat(out VideoType videoFormat);
		void SetVideoFormat(VideoType videoFormat);
		
		void GetVideoCaptureDuration(out int durationInSec);
		void SetVideoCaptureDuration(string duration) throws HdmiCaptureDSEx;
		
		void GetOutputFolder(out string folderPath);
		void SetOutputFolder(string folderPath) throws HdmiCaptureDSEx;
		
		void StartVideoCaptureToFile(string aviFileName) throws HdmiCaptureDSEx;
		void StopVideoCapture() throws HdmiCaptureDSEx;
		
		void RegisterHdmiCaptureDSEvents(HdmiCaptureDSEvents* receiver);
		void UnregisterHdmiCaptureDSEvents(HdmiCaptureDSEvents* receiver);
		
		void ShutDown();
		
		void GrabStillFrame(string pictureFileName);
    };    
};

#endif