// **********************************************************************
//
// Copyright (c) 2003-2007 ZeroC, Inc. All rights reserved.
//
// This copy of Ice is licensed to you under the terms described in the
// ICE_LICENSE file included in this distribution.
//
// **********************************************************************

// Ice version 3.2.1
// Generated from file `HdmiCaptureDS.ice'

using _System = System;
using _Microsoft = Microsoft;

namespace Services
{
    public class HdmiCaptureDSEx : Ice.UserException
    {
        #region Slice data members

        public string ExMessage;

        #endregion

        #region Constructors

        public HdmiCaptureDSEx()
        {
        }

        public HdmiCaptureDSEx(_System.Exception ex__) : base(ex__)
        {
        }

        private void initDM__(string ExMessage)
        {
            this.ExMessage = ExMessage;
        }

        public HdmiCaptureDSEx(string ExMessage)
        {
            initDM__(ExMessage);
        }

        public HdmiCaptureDSEx(string ExMessage, _System.Exception ex__) : base(ex__)
        {
            initDM__(ExMessage);
        }

        #endregion

        #region Object members

        public override int GetHashCode()
        {
            int h__ = 0;
            if((object)ExMessage != null)
            {
                h__ = 5 * h__ + ExMessage.GetHashCode();
            }
            return h__;
        }

        public override bool Equals(object other__)
        {
            if(other__ == null)
            {
                return false;
            }
            if(object.ReferenceEquals(this, other__))
            {
                return true;
            }
            if(!(other__ is HdmiCaptureDSEx))
            {
                return false;
            }
            if(ExMessage == null)
            {
                if(((HdmiCaptureDSEx)other__).ExMessage != null)
                {
                    return false;
                }
            }
            else
            {
                if(!ExMessage.Equals(((HdmiCaptureDSEx)other__).ExMessage))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region Comparison members

        public static bool operator==(HdmiCaptureDSEx lhs__, HdmiCaptureDSEx rhs__)
        {
            return Equals(lhs__, rhs__);
        }

        public static bool operator!=(HdmiCaptureDSEx lhs__, HdmiCaptureDSEx rhs__)
        {
            return !Equals(lhs__, rhs__);
        }

        #endregion

        #region Marshaling support

        public override void write__(IceInternal.BasicStream os__)
        {
            os__.writeString("::Services::HdmiCaptureDSEx");
            os__.startWriteSlice();
            os__.writeString(ExMessage);
            os__.endWriteSlice();
        }

        public override void read__(IceInternal.BasicStream is__, bool rid__)
        {
            if(rid__)
            {
                /* string myId = */ is__.readString();
            }
            is__.startReadSlice();
            ExMessage = is__.readString();
            is__.endReadSlice();
        }

        public override void write__(Ice.OutputStream outS__)
        {
            Ice.MarshalException ex = new Ice.MarshalException();
            ex.reason = "exception Services::HdmiCaptureDSEx was not generated with stream support";
            throw ex;
        }

        public override void read__(Ice.InputStream inS__, bool rid__)
        {
            Ice.MarshalException ex = new Ice.MarshalException();
            ex.reason = "exception Services::HdmiCaptureDSEx was not generated with stream support";
            throw ex;
        }

        public override bool usesClasses__()
        {
            return true;
        }

        #endregion
    }

    public enum CompressionType
    {
        YUV8bits,
        YUV10bits,
        RGB10bits
    }

    public enum VideoType
    {
        HD720p50,
        HD720p60,
        HD1080i50,
        HD1080i60,
        HD1080p50,
        HD1080p60
    }

    public interface HdmiCaptureDSEvents : Ice.Object, HdmiCaptureDSEventsOperations_, HdmiCaptureDSEventsOperationsNC_
    {
    }

    public interface HdmiCaptureDS : Ice.Object, HdmiCaptureDSOperations_, HdmiCaptureDSOperationsNC_
    {
    }
}

namespace Services
{
    public interface HdmiCaptureDSEventsPrx : Ice.ObjectPrx
    {
        void EndCaptureReached();
        void EndCaptureReached(Ice.Context context__);

        void SendMessage(string message);
        void SendMessage(string message, Ice.Context context__);
    }

    public interface HdmiCaptureDSPrx : Ice.ObjectPrx
    {
        void GetAllVideoCaptureDevices(out string[] captureDeviceList);
        void GetAllVideoCaptureDevices(out string[] captureDeviceList, Ice.Context context__);

        void GetVideoCaptureDevice(out string deviceName, out string vendorId);
        void GetVideoCaptureDevice(out string deviceName, out string vendorId, Ice.Context context__);

        void GetPixelFormat(out Services.CompressionType pixelFormat);
        void GetPixelFormat(out Services.CompressionType pixelFormat, Ice.Context context__);

        void SetPixelFormat(Services.CompressionType pixelFormat);
        void SetPixelFormat(Services.CompressionType pixelFormat, Ice.Context context__);

        void GetVideoFormat(out Services.VideoType videoFormat);
        void GetVideoFormat(out Services.VideoType videoFormat, Ice.Context context__);

        void SetVideoFormat(Services.VideoType videoFormat);
        void SetVideoFormat(Services.VideoType videoFormat, Ice.Context context__);

        void GetVideoCaptureDuration(out int durationInSec);
        void GetVideoCaptureDuration(out int durationInSec, Ice.Context context__);

        void SetVideoCaptureDuration(string duration);
        void SetVideoCaptureDuration(string duration, Ice.Context context__);

        void GetOutputFolder(out string folderPath);
        void GetOutputFolder(out string folderPath, Ice.Context context__);

        void SetOutputFolder(string folderPath);
        void SetOutputFolder(string folderPath, Ice.Context context__);

        void StartVideoCaptureToFile(string aviFileName);
        void StartVideoCaptureToFile(string aviFileName, Ice.Context context__);

        void StopVideoCapture();
        void StopVideoCapture(Ice.Context context__);

        void RegisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver);
        void RegisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Context context__);

        void UnregisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver);
        void UnregisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Context context__);

        void ShutDown();
        void ShutDown(Ice.Context context__);

        void GrabStillFrame(string pictureFileName);
        void GrabStillFrame(string pictureFileName, Ice.Context context__);
    }
}

namespace Services
{
    public interface HdmiCaptureDSEventsOperations_
    {
        void EndCaptureReached(Ice.Current current__);

        void SendMessage(string message, Ice.Current current__);
    }

    public interface HdmiCaptureDSEventsOperationsNC_
    {
        void EndCaptureReached();

        void SendMessage(string message);
    }

    public interface HdmiCaptureDSOperations_
    {
        void GetAllVideoCaptureDevices(out string[] captureDeviceList, Ice.Current current__);

        void GetVideoCaptureDevice(out string deviceName, out string vendorId, Ice.Current current__);

        void GetPixelFormat(out Services.CompressionType pixelFormat, Ice.Current current__);

        void SetPixelFormat(Services.CompressionType pixelFormat, Ice.Current current__);

        void GetVideoFormat(out Services.VideoType videoFormat, Ice.Current current__);

        void SetVideoFormat(Services.VideoType videoFormat, Ice.Current current__);

        void GetVideoCaptureDuration(out int durationInSec, Ice.Current current__);

        void SetVideoCaptureDuration(string duration, Ice.Current current__);

        void GetOutputFolder(out string folderPath, Ice.Current current__);

        void SetOutputFolder(string folderPath, Ice.Current current__);

        void StartVideoCaptureToFile(string aviFileName, Ice.Current current__);

        void StopVideoCapture(Ice.Current current__);

        void RegisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Current current__);

        void UnregisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Current current__);

        void ShutDown(Ice.Current current__);

        void GrabStillFrame(string pictureFileName, Ice.Current current__);
    }

    public interface HdmiCaptureDSOperationsNC_
    {
        void GetAllVideoCaptureDevices(out string[] captureDeviceList);

        void GetVideoCaptureDevice(out string deviceName, out string vendorId);

        void GetPixelFormat(out Services.CompressionType pixelFormat);

        void SetPixelFormat(Services.CompressionType pixelFormat);

        void GetVideoFormat(out Services.VideoType videoFormat);

        void SetVideoFormat(Services.VideoType videoFormat);

        void GetVideoCaptureDuration(out int durationInSec);

        void SetVideoCaptureDuration(string duration);

        void GetOutputFolder(out string folderPath);

        void SetOutputFolder(string folderPath);

        void StartVideoCaptureToFile(string aviFileName);

        void StopVideoCapture();

        void RegisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver);

        void UnregisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver);

        void ShutDown();

        void GrabStillFrame(string pictureFileName);
    }
}

namespace Services
{
    public sealed class StringListHelper
    {
        public static void write(IceInternal.BasicStream os__, string[] v__)
        {
            os__.writeStringSeq(v__);
        }

        public static string[] read(IceInternal.BasicStream is__)
        {
            string[] v__;
            v__ = is__.readStringSeq();
            return v__;
        }
    }

    public sealed class HdmiCaptureDSEventsPrxHelper : Ice.ObjectPrxHelperBase, HdmiCaptureDSEventsPrx
    {
        #region Synchronous operations

        public void EndCaptureReached()
        {
            EndCaptureReached(null, false);
        }

        public void EndCaptureReached(Ice.Context context__)
        {
            EndCaptureReached(context__, true);
        }

        private void EndCaptureReached(Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    delBase__ = getDelegate__();
                    HdmiCaptureDSEventsDel_ del__ = (HdmiCaptureDSEventsDel_)delBase__;
                    del__.EndCaptureReached(context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void SendMessage(string message)
        {
            SendMessage(message, null, false);
        }

        public void SendMessage(string message, Ice.Context context__)
        {
            SendMessage(message, context__, true);
        }

        private void SendMessage(string message, Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    delBase__ = getDelegate__();
                    HdmiCaptureDSEventsDel_ del__ = (HdmiCaptureDSEventsDel_)delBase__;
                    del__.SendMessage(message, context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        #endregion

        #region Checked and unchecked cast operations

        public static HdmiCaptureDSEventsPrx checkedCast(Ice.ObjectPrx b)
        {
            if(b == null)
            {
                return null;
            }
            if(b is HdmiCaptureDSEventsPrx)
            {
                return (HdmiCaptureDSEventsPrx)b;
            }
            if(b.ice_isA("::Services::HdmiCaptureDSEvents"))
            {
                HdmiCaptureDSEventsPrxHelper h = new HdmiCaptureDSEventsPrxHelper();
                h.copyFrom__(b);
                return h;
            }
            return null;
        }

        public static HdmiCaptureDSEventsPrx checkedCast(Ice.ObjectPrx b, Ice.Context ctx)
        {
            if(b == null)
            {
                return null;
            }
            if(b is HdmiCaptureDSEventsPrx)
            {
                return (HdmiCaptureDSEventsPrx)b;
            }
            if(b.ice_isA("::Services::HdmiCaptureDSEvents", ctx))
            {
                HdmiCaptureDSEventsPrxHelper h = new HdmiCaptureDSEventsPrxHelper();
                h.copyFrom__(b);
                return h;
            }
            return null;
        }

        public static HdmiCaptureDSEventsPrx checkedCast(Ice.ObjectPrx b, string f)
        {
            if(b == null)
            {
                return null;
            }
            Ice.ObjectPrx bb = b.ice_facet(f);
            try
            {
                if(bb.ice_isA("::Services::HdmiCaptureDSEvents"))
                {
                    HdmiCaptureDSEventsPrxHelper h = new HdmiCaptureDSEventsPrxHelper();
                    h.copyFrom__(bb);
                    return h;
                }
            }
            catch(Ice.FacetNotExistException)
            {
            }
            return null;
        }

        public static HdmiCaptureDSEventsPrx checkedCast(Ice.ObjectPrx b, string f, Ice.Context ctx)
        {
            if(b == null)
            {
                return null;
            }
            Ice.ObjectPrx bb = b.ice_facet(f);
            try
            {
                if(bb.ice_isA("::Services::HdmiCaptureDSEvents", ctx))
                {
                    HdmiCaptureDSEventsPrxHelper h = new HdmiCaptureDSEventsPrxHelper();
                    h.copyFrom__(bb);
                    return h;
                }
            }
            catch(Ice.FacetNotExistException)
            {
            }
            return null;
        }

        public static HdmiCaptureDSEventsPrx uncheckedCast(Ice.ObjectPrx b)
        {
            if(b == null)
            {
                return null;
            }
            HdmiCaptureDSEventsPrxHelper h = new HdmiCaptureDSEventsPrxHelper();
            h.copyFrom__(b);
            return h;
        }

        public static HdmiCaptureDSEventsPrx uncheckedCast(Ice.ObjectPrx b, string f)
        {
            if(b == null)
            {
                return null;
            }
            Ice.ObjectPrx bb = b.ice_facet(f);
            HdmiCaptureDSEventsPrxHelper h = new HdmiCaptureDSEventsPrxHelper();
            h.copyFrom__(bb);
            return h;
        }

        #endregion

        #region Marshaling support

        protected override Ice.ObjectDelM_ createDelegateM__()
        {
            return new HdmiCaptureDSEventsDelM_();
        }

        protected override Ice.ObjectDelD_ createDelegateD__()
        {
            return new HdmiCaptureDSEventsDelD_();
        }

        public static void write__(IceInternal.BasicStream os__, HdmiCaptureDSEventsPrx v__)
        {
            os__.writeProxy(v__);
        }

        public static HdmiCaptureDSEventsPrx read__(IceInternal.BasicStream is__)
        {
            Ice.ObjectPrx proxy = is__.readProxy();
            if(proxy != null)
            {
                HdmiCaptureDSEventsPrxHelper result = new HdmiCaptureDSEventsPrxHelper();
                result.copyFrom__(proxy);
                return result;
            }
            return null;
        }

        #endregion
    }

    public sealed class HdmiCaptureDSPrxHelper : Ice.ObjectPrxHelperBase, HdmiCaptureDSPrx
    {
        #region Synchronous operations

        public void GetAllVideoCaptureDevices(out string[] captureDeviceList)
        {
            GetAllVideoCaptureDevices(out captureDeviceList, null, false);
        }

        public void GetAllVideoCaptureDevices(out string[] captureDeviceList, Ice.Context context__)
        {
            GetAllVideoCaptureDevices(out captureDeviceList, context__, true);
        }

        private void GetAllVideoCaptureDevices(out string[] captureDeviceList, Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    checkTwowayOnly__("GetAllVideoCaptureDevices");
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.GetAllVideoCaptureDevices(out captureDeviceList, context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void GetOutputFolder(out string folderPath)
        {
            GetOutputFolder(out folderPath, null, false);
        }

        public void GetOutputFolder(out string folderPath, Ice.Context context__)
        {
            GetOutputFolder(out folderPath, context__, true);
        }

        private void GetOutputFolder(out string folderPath, Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    checkTwowayOnly__("GetOutputFolder");
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.GetOutputFolder(out folderPath, context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void GetPixelFormat(out Services.CompressionType pixelFormat)
        {
            GetPixelFormat(out pixelFormat, null, false);
        }

        public void GetPixelFormat(out Services.CompressionType pixelFormat, Ice.Context context__)
        {
            GetPixelFormat(out pixelFormat, context__, true);
        }

        private void GetPixelFormat(out Services.CompressionType pixelFormat, Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    checkTwowayOnly__("GetPixelFormat");
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.GetPixelFormat(out pixelFormat, context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void GetVideoCaptureDevice(out string deviceName, out string vendorId)
        {
            GetVideoCaptureDevice(out deviceName, out vendorId, null, false);
        }

        public void GetVideoCaptureDevice(out string deviceName, out string vendorId, Ice.Context context__)
        {
            GetVideoCaptureDevice(out deviceName, out vendorId, context__, true);
        }

        private void GetVideoCaptureDevice(out string deviceName, out string vendorId, Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    checkTwowayOnly__("GetVideoCaptureDevice");
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.GetVideoCaptureDevice(out deviceName, out vendorId, context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void GetVideoCaptureDuration(out int durationInSec)
        {
            GetVideoCaptureDuration(out durationInSec, null, false);
        }

        public void GetVideoCaptureDuration(out int durationInSec, Ice.Context context__)
        {
            GetVideoCaptureDuration(out durationInSec, context__, true);
        }

        private void GetVideoCaptureDuration(out int durationInSec, Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    checkTwowayOnly__("GetVideoCaptureDuration");
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.GetVideoCaptureDuration(out durationInSec, context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void GetVideoFormat(out Services.VideoType videoFormat)
        {
            GetVideoFormat(out videoFormat, null, false);
        }

        public void GetVideoFormat(out Services.VideoType videoFormat, Ice.Context context__)
        {
            GetVideoFormat(out videoFormat, context__, true);
        }

        private void GetVideoFormat(out Services.VideoType videoFormat, Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    checkTwowayOnly__("GetVideoFormat");
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.GetVideoFormat(out videoFormat, context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void GrabStillFrame(string pictureFileName)
        {
            GrabStillFrame(pictureFileName, null, false);
        }

        public void GrabStillFrame(string pictureFileName, Ice.Context context__)
        {
            GrabStillFrame(pictureFileName, context__, true);
        }

        private void GrabStillFrame(string pictureFileName, Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.GrabStillFrame(pictureFileName, context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void RegisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver)
        {
            RegisterHdmiCaptureDSEvents(receiver, null, false);
        }

        public void RegisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Context context__)
        {
            RegisterHdmiCaptureDSEvents(receiver, context__, true);
        }

        private void RegisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.RegisterHdmiCaptureDSEvents(receiver, context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void SetOutputFolder(string folderPath)
        {
            SetOutputFolder(folderPath, null, false);
        }

        public void SetOutputFolder(string folderPath, Ice.Context context__)
        {
            SetOutputFolder(folderPath, context__, true);
        }

        private void SetOutputFolder(string folderPath, Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    checkTwowayOnly__("SetOutputFolder");
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.SetOutputFolder(folderPath, context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void SetPixelFormat(Services.CompressionType pixelFormat)
        {
            SetPixelFormat(pixelFormat, null, false);
        }

        public void SetPixelFormat(Services.CompressionType pixelFormat, Ice.Context context__)
        {
            SetPixelFormat(pixelFormat, context__, true);
        }

        private void SetPixelFormat(Services.CompressionType pixelFormat, Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.SetPixelFormat(pixelFormat, context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void SetVideoCaptureDuration(string duration)
        {
            SetVideoCaptureDuration(duration, null, false);
        }

        public void SetVideoCaptureDuration(string duration, Ice.Context context__)
        {
            SetVideoCaptureDuration(duration, context__, true);
        }

        private void SetVideoCaptureDuration(string duration, Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    checkTwowayOnly__("SetVideoCaptureDuration");
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.SetVideoCaptureDuration(duration, context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void SetVideoFormat(Services.VideoType videoFormat)
        {
            SetVideoFormat(videoFormat, null, false);
        }

        public void SetVideoFormat(Services.VideoType videoFormat, Ice.Context context__)
        {
            SetVideoFormat(videoFormat, context__, true);
        }

        private void SetVideoFormat(Services.VideoType videoFormat, Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.SetVideoFormat(videoFormat, context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void ShutDown()
        {
            ShutDown(null, false);
        }

        public void ShutDown(Ice.Context context__)
        {
            ShutDown(context__, true);
        }

        private void ShutDown(Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.ShutDown(context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void StartVideoCaptureToFile(string aviFileName)
        {
            StartVideoCaptureToFile(aviFileName, null, false);
        }

        public void StartVideoCaptureToFile(string aviFileName, Ice.Context context__)
        {
            StartVideoCaptureToFile(aviFileName, context__, true);
        }

        private void StartVideoCaptureToFile(string aviFileName, Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    checkTwowayOnly__("StartVideoCaptureToFile");
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.StartVideoCaptureToFile(aviFileName, context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void StopVideoCapture()
        {
            StopVideoCapture(null, false);
        }

        public void StopVideoCapture(Ice.Context context__)
        {
            StopVideoCapture(context__, true);
        }

        private void StopVideoCapture(Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    checkTwowayOnly__("StopVideoCapture");
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.StopVideoCapture(context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        public void UnregisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver)
        {
            UnregisterHdmiCaptureDSEvents(receiver, null, false);
        }

        public void UnregisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Context context__)
        {
            UnregisterHdmiCaptureDSEvents(receiver, context__, true);
        }

        private void UnregisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Context context__, bool explicitContext__)
        {
            if(explicitContext__ && context__ == null)
            {
                context__ = emptyContext_;
            }
            int cnt__ = 0;
            while(true)
            {
                Ice.ObjectDel_ delBase__ = null;
                try
                {
                    delBase__ = getDelegate__();
                    HdmiCaptureDSDel_ del__ = (HdmiCaptureDSDel_)delBase__;
                    del__.UnregisterHdmiCaptureDSEvents(receiver, context__);
                    return;
                }
                catch(IceInternal.LocalExceptionWrapper ex__)
                {
                    handleExceptionWrapper__(delBase__, ex__);
                }
                catch(Ice.LocalException ex__)
                {
                    cnt__ = handleException__(delBase__, ex__, cnt__);
                }
            }
        }

        #endregion

        #region Checked and unchecked cast operations

        public static HdmiCaptureDSPrx checkedCast(Ice.ObjectPrx b)
        {
            if(b == null)
            {
                return null;
            }
            if(b is HdmiCaptureDSPrx)
            {
                return (HdmiCaptureDSPrx)b;
            }
            if(b.ice_isA("::Services::HdmiCaptureDS"))
            {
                HdmiCaptureDSPrxHelper h = new HdmiCaptureDSPrxHelper();
                h.copyFrom__(b);
                return h;
            }
            return null;
        }

        public static HdmiCaptureDSPrx checkedCast(Ice.ObjectPrx b, Ice.Context ctx)
        {
            if(b == null)
            {
                return null;
            }
            if(b is HdmiCaptureDSPrx)
            {
                return (HdmiCaptureDSPrx)b;
            }
            if(b.ice_isA("::Services::HdmiCaptureDS", ctx))
            {
                HdmiCaptureDSPrxHelper h = new HdmiCaptureDSPrxHelper();
                h.copyFrom__(b);
                return h;
            }
            return null;
        }

        public static HdmiCaptureDSPrx checkedCast(Ice.ObjectPrx b, string f)
        {
            if(b == null)
            {
                return null;
            }
            Ice.ObjectPrx bb = b.ice_facet(f);
            try
            {
                if(bb.ice_isA("::Services::HdmiCaptureDS"))
                {
                    HdmiCaptureDSPrxHelper h = new HdmiCaptureDSPrxHelper();
                    h.copyFrom__(bb);
                    return h;
                }
            }
            catch(Ice.FacetNotExistException)
            {
            }
            return null;
        }

        public static HdmiCaptureDSPrx checkedCast(Ice.ObjectPrx b, string f, Ice.Context ctx)
        {
            if(b == null)
            {
                return null;
            }
            Ice.ObjectPrx bb = b.ice_facet(f);
            try
            {
                if(bb.ice_isA("::Services::HdmiCaptureDS", ctx))
                {
                    HdmiCaptureDSPrxHelper h = new HdmiCaptureDSPrxHelper();
                    h.copyFrom__(bb);
                    return h;
                }
            }
            catch(Ice.FacetNotExistException)
            {
            }
            return null;
        }

        public static HdmiCaptureDSPrx uncheckedCast(Ice.ObjectPrx b)
        {
            if(b == null)
            {
                return null;
            }
            HdmiCaptureDSPrxHelper h = new HdmiCaptureDSPrxHelper();
            h.copyFrom__(b);
            return h;
        }

        public static HdmiCaptureDSPrx uncheckedCast(Ice.ObjectPrx b, string f)
        {
            if(b == null)
            {
                return null;
            }
            Ice.ObjectPrx bb = b.ice_facet(f);
            HdmiCaptureDSPrxHelper h = new HdmiCaptureDSPrxHelper();
            h.copyFrom__(bb);
            return h;
        }

        #endregion

        #region Marshaling support

        protected override Ice.ObjectDelM_ createDelegateM__()
        {
            return new HdmiCaptureDSDelM_();
        }

        protected override Ice.ObjectDelD_ createDelegateD__()
        {
            return new HdmiCaptureDSDelD_();
        }

        public static void write__(IceInternal.BasicStream os__, HdmiCaptureDSPrx v__)
        {
            os__.writeProxy(v__);
        }

        public static HdmiCaptureDSPrx read__(IceInternal.BasicStream is__)
        {
            Ice.ObjectPrx proxy = is__.readProxy();
            if(proxy != null)
            {
                HdmiCaptureDSPrxHelper result = new HdmiCaptureDSPrxHelper();
                result.copyFrom__(proxy);
                return result;
            }
            return null;
        }

        #endregion
    }
}

namespace Services
{
    public interface HdmiCaptureDSEventsDel_ : Ice.ObjectDel_
    {
        void EndCaptureReached(Ice.Context context__);

        void SendMessage(string message, Ice.Context context__);
    }

    public interface HdmiCaptureDSDel_ : Ice.ObjectDel_
    {
        void GetAllVideoCaptureDevices(out string[] captureDeviceList, Ice.Context context__);

        void GetVideoCaptureDevice(out string deviceName, out string vendorId, Ice.Context context__);

        void GetPixelFormat(out Services.CompressionType pixelFormat, Ice.Context context__);

        void SetPixelFormat(Services.CompressionType pixelFormat, Ice.Context context__);

        void GetVideoFormat(out Services.VideoType videoFormat, Ice.Context context__);

        void SetVideoFormat(Services.VideoType videoFormat, Ice.Context context__);

        void GetVideoCaptureDuration(out int durationInSec, Ice.Context context__);

        void SetVideoCaptureDuration(string duration, Ice.Context context__);

        void GetOutputFolder(out string folderPath, Ice.Context context__);

        void SetOutputFolder(string folderPath, Ice.Context context__);

        void StartVideoCaptureToFile(string aviFileName, Ice.Context context__);

        void StopVideoCapture(Ice.Context context__);

        void RegisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Context context__);

        void UnregisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Context context__);

        void ShutDown(Ice.Context context__);

        void GrabStillFrame(string pictureFileName, Ice.Context context__);
    }
}

namespace Services
{
    public sealed class HdmiCaptureDSEventsDelM_ : Ice.ObjectDelM_, HdmiCaptureDSEventsDel_
    {
        public void EndCaptureReached(Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("EndCaptureReached", Ice.OperationMode.Normal, context__);
            try
            {
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void SendMessage(string message, Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("SendMessage", Ice.OperationMode.Normal, context__);
            try
            {
                try
                {
                    IceInternal.BasicStream os__ = og__.ostr();
                    os__.writeString(message);
                }
                catch(Ice.LocalException ex__)
                {
                    og__.abort(ex__);
                }
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }
    }

    public sealed class HdmiCaptureDSDelM_ : Ice.ObjectDelM_, HdmiCaptureDSDel_
    {
        public void GetAllVideoCaptureDevices(out string[] captureDeviceList, Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("GetAllVideoCaptureDevices", Ice.OperationMode.Normal, context__);
            try
            {
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Services.HdmiCaptureDSEx)
                        {
                            throw;
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                    captureDeviceList = is__.readStringSeq();
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void GetOutputFolder(out string folderPath, Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("GetOutputFolder", Ice.OperationMode.Normal, context__);
            try
            {
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                    folderPath = is__.readString();
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void GetPixelFormat(out Services.CompressionType pixelFormat, Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("GetPixelFormat", Ice.OperationMode.Normal, context__);
            try
            {
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                    pixelFormat = (Services.CompressionType)is__.readByte();
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void GetVideoCaptureDevice(out string deviceName, out string vendorId, Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("GetVideoCaptureDevice", Ice.OperationMode.Normal, context__);
            try
            {
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Services.HdmiCaptureDSEx)
                        {
                            throw;
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                    deviceName = is__.readString();
                    vendorId = is__.readString();
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void GetVideoCaptureDuration(out int durationInSec, Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("GetVideoCaptureDuration", Ice.OperationMode.Normal, context__);
            try
            {
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                    durationInSec = is__.readInt();
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void GetVideoFormat(out Services.VideoType videoFormat, Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("GetVideoFormat", Ice.OperationMode.Normal, context__);
            try
            {
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                    videoFormat = (Services.VideoType)is__.readByte();
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void GrabStillFrame(string pictureFileName, Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("GrabStillFrame", Ice.OperationMode.Normal, context__);
            try
            {
                try
                {
                    IceInternal.BasicStream os__ = og__.ostr();
                    os__.writeString(pictureFileName);
                }
                catch(Ice.LocalException ex__)
                {
                    og__.abort(ex__);
                }
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void RegisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("RegisterHdmiCaptureDSEvents", Ice.OperationMode.Normal, context__);
            try
            {
                try
                {
                    IceInternal.BasicStream os__ = og__.ostr();
                    Services.HdmiCaptureDSEventsPrxHelper.write__(os__, receiver);
                }
                catch(Ice.LocalException ex__)
                {
                    og__.abort(ex__);
                }
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void SetOutputFolder(string folderPath, Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("SetOutputFolder", Ice.OperationMode.Normal, context__);
            try
            {
                try
                {
                    IceInternal.BasicStream os__ = og__.ostr();
                    os__.writeString(folderPath);
                }
                catch(Ice.LocalException ex__)
                {
                    og__.abort(ex__);
                }
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Services.HdmiCaptureDSEx)
                        {
                            throw;
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void SetPixelFormat(Services.CompressionType pixelFormat, Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("SetPixelFormat", Ice.OperationMode.Normal, context__);
            try
            {
                try
                {
                    IceInternal.BasicStream os__ = og__.ostr();
                    os__.writeByte((byte)pixelFormat);
                }
                catch(Ice.LocalException ex__)
                {
                    og__.abort(ex__);
                }
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void SetVideoCaptureDuration(string duration, Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("SetVideoCaptureDuration", Ice.OperationMode.Normal, context__);
            try
            {
                try
                {
                    IceInternal.BasicStream os__ = og__.ostr();
                    os__.writeString(duration);
                }
                catch(Ice.LocalException ex__)
                {
                    og__.abort(ex__);
                }
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Services.HdmiCaptureDSEx)
                        {
                            throw;
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void SetVideoFormat(Services.VideoType videoFormat, Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("SetVideoFormat", Ice.OperationMode.Normal, context__);
            try
            {
                try
                {
                    IceInternal.BasicStream os__ = og__.ostr();
                    os__.writeByte((byte)videoFormat);
                }
                catch(Ice.LocalException ex__)
                {
                    og__.abort(ex__);
                }
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void ShutDown(Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("ShutDown", Ice.OperationMode.Normal, context__);
            try
            {
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void StartVideoCaptureToFile(string aviFileName, Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("StartVideoCaptureToFile", Ice.OperationMode.Normal, context__);
            try
            {
                try
                {
                    IceInternal.BasicStream os__ = og__.ostr();
                    os__.writeString(aviFileName);
                }
                catch(Ice.LocalException ex__)
                {
                    og__.abort(ex__);
                }
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Services.HdmiCaptureDSEx)
                        {
                            throw;
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void StopVideoCapture(Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("StopVideoCapture", Ice.OperationMode.Normal, context__);
            try
            {
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Services.HdmiCaptureDSEx)
                        {
                            throw;
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }

        public void UnregisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Context context__)
        {
            IceInternal.Outgoing og__ = getOutgoing("UnregisterHdmiCaptureDSEvents", Ice.OperationMode.Normal, context__);
            try
            {
                try
                {
                    IceInternal.BasicStream os__ = og__.ostr();
                    Services.HdmiCaptureDSEventsPrxHelper.write__(os__, receiver);
                }
                catch(Ice.LocalException ex__)
                {
                    og__.abort(ex__);
                }
                bool ok__ = og__.invoke();
                try
                {
                    IceInternal.BasicStream is__ = og__.istr();
                    if(!ok__)
                    {
                        try
                        {
                            is__.throwException();
                        }
                        catch(Ice.UserException ex)
                        {
                            throw new Ice.UnknownUserException(ex);
                        }
                    }
                }
                catch(Ice.LocalException ex__)
                {
                    throw new IceInternal.LocalExceptionWrapper(ex__, false);
                }
            }
            finally
            {
                reclaimOutgoing(og__);
            }
        }
    }
}

namespace Services
{
    public sealed class HdmiCaptureDSEventsDelD_ : Ice.ObjectDelD_, HdmiCaptureDSEventsDel_
    {
        public void EndCaptureReached(Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "EndCaptureReached", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDSEvents)
                {
                    try
                    {
                        ((Services.HdmiCaptureDSEvents)servant__).EndCaptureReached(current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void SendMessage(string message, Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "SendMessage", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDSEvents)
                {
                    try
                    {
                        ((Services.HdmiCaptureDSEvents)servant__).SendMessage(message, current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }
    }

    public sealed class HdmiCaptureDSDelD_ : Ice.ObjectDelD_, HdmiCaptureDSDel_
    {
        public void GetAllVideoCaptureDevices(out string[] captureDeviceList, Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "GetAllVideoCaptureDevices", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).GetAllVideoCaptureDevices(out captureDeviceList, current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void GetOutputFolder(out string folderPath, Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "GetOutputFolder", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).GetOutputFolder(out folderPath, current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void GetPixelFormat(out Services.CompressionType pixelFormat, Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "GetPixelFormat", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).GetPixelFormat(out pixelFormat, current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void GetVideoCaptureDevice(out string deviceName, out string vendorId, Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "GetVideoCaptureDevice", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).GetVideoCaptureDevice(out deviceName, out vendorId, current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void GetVideoCaptureDuration(out int durationInSec, Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "GetVideoCaptureDuration", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).GetVideoCaptureDuration(out durationInSec, current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void GetVideoFormat(out Services.VideoType videoFormat, Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "GetVideoFormat", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).GetVideoFormat(out videoFormat, current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void GrabStillFrame(string pictureFileName, Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "GrabStillFrame", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).GrabStillFrame(pictureFileName, current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void RegisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "RegisterHdmiCaptureDSEvents", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).RegisterHdmiCaptureDSEvents(receiver, current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void SetOutputFolder(string folderPath, Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "SetOutputFolder", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).SetOutputFolder(folderPath, current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void SetPixelFormat(Services.CompressionType pixelFormat, Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "SetPixelFormat", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).SetPixelFormat(pixelFormat, current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void SetVideoCaptureDuration(string duration, Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "SetVideoCaptureDuration", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).SetVideoCaptureDuration(duration, current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void SetVideoFormat(Services.VideoType videoFormat, Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "SetVideoFormat", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).SetVideoFormat(videoFormat, current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void ShutDown(Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "ShutDown", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).ShutDown(current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void StartVideoCaptureToFile(string aviFileName, Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "StartVideoCaptureToFile", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).StartVideoCaptureToFile(aviFileName, current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void StopVideoCapture(Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "StopVideoCapture", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).StopVideoCapture(current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }

        public void UnregisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Context context__)
        {
            Ice.Current current__ = new Ice.Current();
            initCurrent__(ref current__, "UnregisterHdmiCaptureDSEvents", Ice.OperationMode.Normal, context__);
            while(true)
            {
                IceInternal.Direct direct__ = new IceInternal.Direct(current__);
                object servant__ = direct__.servant();
                if(servant__ is HdmiCaptureDS)
                {
                    try
                    {
                        ((Services.HdmiCaptureDS)servant__).UnregisterHdmiCaptureDSEvents(receiver, current__);
                        return;
                    }
                    catch(Ice.LocalException ex__)
                    {
                        throw new IceInternal.LocalExceptionWrapper(ex__, false);
                    }
                    finally
                    {
                        direct__.destroy();
                    }
                }
                else
                {
                    direct__.destroy();
                    Ice.OperationNotExistException opEx__ = new Ice.OperationNotExistException();
                    opEx__.id = current__.id;
                    opEx__.facet = current__.facet;
                    opEx__.operation = current__.operation;
                    throw opEx__;
                }
            }
        }
    }
}

namespace Services
{
    public abstract class HdmiCaptureDSEventsDisp_ : Ice.ObjectImpl, HdmiCaptureDSEvents
    {
        #region Slice operations

        public void EndCaptureReached()
        {
            EndCaptureReached(Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void EndCaptureReached(Ice.Current current__);

        public void SendMessage(string message)
        {
            SendMessage(message, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void SendMessage(string message, Ice.Current current__);

        #endregion

        #region Slice type-related members

        public static new string[] ids__ = 
        {
            "::Ice::Object",
            "::Services::HdmiCaptureDSEvents"
        };

        public override bool ice_isA(string s)
        {
            if(IceInternal.AssemblyUtil.runtime_ == IceInternal.AssemblyUtil.Runtime.Mono)
            {
                // Mono bug: System.Array.BinarySearch() uses the wrong collation sequence,
                // so we do a linear search for the time being
                int pos = 0;
                while(pos < ids__.Length)
                {
                    if(ids__[pos] == s)
                    {
                        break;
                    }
                    ++pos;
                }
                if(pos == ids__.Length)
                {
                    pos = -1;
                }
                return pos >= 0;
            }
            else
            {
                return _System.Array.BinarySearch(ids__, s, _System.Collections.Comparer.DefaultInvariant) >= 0;
            }
        }

        public override bool ice_isA(string s, Ice.Current current__)
        {
            if(IceInternal.AssemblyUtil.runtime_ == IceInternal.AssemblyUtil.Runtime.Mono)
            {
                // Mono bug: System.Array.BinarySearch() uses the wrong collation sequence,
                // so we do a linear search for the time being
                int pos = 0;
                while(pos < ids__.Length)
                {
                    if(ids__[pos] == s)
                    {
                        break;
                    }
                    ++pos;
                }
                if(pos == ids__.Length)
                {
                    pos = -1;
                }
                return pos >= 0;
            }
            else
            {
                return _System.Array.BinarySearch(ids__, s, _System.Collections.Comparer.DefaultInvariant) >= 0;
            }
        }

        public override string[] ice_ids()
        {
            return ids__;
        }

        public override string[] ice_ids(Ice.Current current__)
        {
            return ids__;
        }

        public override string ice_id()
        {
            return ids__[1];
        }

        public override string ice_id(Ice.Current current__)
        {
            return ids__[1];
        }

        public static new string ice_staticId()
        {
            return ids__[1];
        }

        #endregion

        #region Operation dispatch

        public static IceInternal.DispatchStatus EndCaptureReached___(HdmiCaptureDSEvents obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            obj__.EndCaptureReached(current__);
            return IceInternal.DispatchStatus.DispatchOK;
        }

        public static IceInternal.DispatchStatus SendMessage___(HdmiCaptureDSEvents obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream is__ = inS__.istr();
            string message;
            message = is__.readString();
            obj__.SendMessage(message, current__);
            return IceInternal.DispatchStatus.DispatchOK;
        }

        private static string[] all__ =
        {
            "EndCaptureReached",
            "ice_id",
            "ice_ids",
            "ice_isA",
            "ice_ping",
            "SendMessage"
        };

        public override IceInternal.DispatchStatus dispatch__(IceInternal.Incoming inS__, Ice.Current current__)
        {
            int pos;
            if(IceInternal.AssemblyUtil.runtime_ == IceInternal.AssemblyUtil.Runtime.Mono)
            {
                // Mono bug: System.Array.BinarySearch() uses the wrong collation sequence,
                // so we do a linear search for the time being
                pos = 0;
                while(pos < all__.Length)
                {
                    if(all__[pos] == current__.operation)
                    {
                        break;
                    }
                    ++pos;
                }
                if(pos == all__.Length)
                {
                    pos = -1;
                }
            }
            else
            {
                pos = _System.Array.BinarySearch(all__, current__.operation, _System.Collections.Comparer.DefaultInvariant);
            }
            if(pos < 0)
            {
                return IceInternal.DispatchStatus.DispatchOperationNotExist;
            }

            switch(pos)
            {
                case 0:
                {
                    return EndCaptureReached___(this, inS__, current__);
                }
                case 1:
                {
                    return ice_id___(this, inS__, current__);
                }
                case 2:
                {
                    return ice_ids___(this, inS__, current__);
                }
                case 3:
                {
                    return ice_isA___(this, inS__, current__);
                }
                case 4:
                {
                    return ice_ping___(this, inS__, current__);
                }
                case 5:
                {
                    return SendMessage___(this, inS__, current__);
                }
            }

            _System.Diagnostics.Debug.Assert(false);
            return IceInternal.DispatchStatus.DispatchOperationNotExist;
        }

        #endregion

        #region Marshaling support

        public override void write__(IceInternal.BasicStream os__)
        {
            os__.writeTypeId(ice_staticId());
            os__.startWriteSlice();
            os__.endWriteSlice();
            base.write__(os__);
        }

        public override void read__(IceInternal.BasicStream is__, bool rid__)
        {
            if(rid__)
            {
                /* string myId = */ is__.readTypeId();
            }
            is__.startReadSlice();
            is__.endReadSlice();
            base.read__(is__, true);
        }

        public override void write__(Ice.OutputStream outS__)
        {
            Ice.MarshalException ex = new Ice.MarshalException();
            ex.reason = "type Services::HdmiCaptureDSEvents was not generated with stream support";
            throw ex;
        }

        public override void read__(Ice.InputStream inS__, bool rid__)
        {
            Ice.MarshalException ex = new Ice.MarshalException();
            ex.reason = "type Services::HdmiCaptureDSEvents was not generated with stream support";
            throw ex;
        }

        #endregion
    }

    public abstract class HdmiCaptureDSDisp_ : Ice.ObjectImpl, HdmiCaptureDS
    {
        #region Slice operations

        public void GetAllVideoCaptureDevices(out string[] captureDeviceList)
        {
            GetAllVideoCaptureDevices(out captureDeviceList, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void GetAllVideoCaptureDevices(out string[] captureDeviceList, Ice.Current current__);

        public void GetVideoCaptureDevice(out string deviceName, out string vendorId)
        {
            GetVideoCaptureDevice(out deviceName, out vendorId, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void GetVideoCaptureDevice(out string deviceName, out string vendorId, Ice.Current current__);

        public void GetPixelFormat(out Services.CompressionType pixelFormat)
        {
            GetPixelFormat(out pixelFormat, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void GetPixelFormat(out Services.CompressionType pixelFormat, Ice.Current current__);

        public void SetPixelFormat(Services.CompressionType pixelFormat)
        {
            SetPixelFormat(pixelFormat, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void SetPixelFormat(Services.CompressionType pixelFormat, Ice.Current current__);

        public void GetVideoFormat(out Services.VideoType videoFormat)
        {
            GetVideoFormat(out videoFormat, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void GetVideoFormat(out Services.VideoType videoFormat, Ice.Current current__);

        public void SetVideoFormat(Services.VideoType videoFormat)
        {
            SetVideoFormat(videoFormat, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void SetVideoFormat(Services.VideoType videoFormat, Ice.Current current__);

        public void GetVideoCaptureDuration(out int durationInSec)
        {
            GetVideoCaptureDuration(out durationInSec, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void GetVideoCaptureDuration(out int durationInSec, Ice.Current current__);

        public void SetVideoCaptureDuration(string duration)
        {
            SetVideoCaptureDuration(duration, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void SetVideoCaptureDuration(string duration, Ice.Current current__);

        public void GetOutputFolder(out string folderPath)
        {
            GetOutputFolder(out folderPath, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void GetOutputFolder(out string folderPath, Ice.Current current__);

        public void SetOutputFolder(string folderPath)
        {
            SetOutputFolder(folderPath, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void SetOutputFolder(string folderPath, Ice.Current current__);

        public void StartVideoCaptureToFile(string aviFileName)
        {
            StartVideoCaptureToFile(aviFileName, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void StartVideoCaptureToFile(string aviFileName, Ice.Current current__);

        public void StopVideoCapture()
        {
            StopVideoCapture(Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void StopVideoCapture(Ice.Current current__);

        public void RegisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver)
        {
            RegisterHdmiCaptureDSEvents(receiver, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void RegisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Current current__);

        public void UnregisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver)
        {
            UnregisterHdmiCaptureDSEvents(receiver, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void UnregisterHdmiCaptureDSEvents(Services.HdmiCaptureDSEventsPrx receiver, Ice.Current current__);

        public void ShutDown()
        {
            ShutDown(Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void ShutDown(Ice.Current current__);

        public void GrabStillFrame(string pictureFileName)
        {
            GrabStillFrame(pictureFileName, Ice.ObjectImpl.defaultCurrent);
        }

        public abstract void GrabStillFrame(string pictureFileName, Ice.Current current__);

        #endregion

        #region Slice type-related members

        public static new string[] ids__ = 
        {
            "::Ice::Object",
            "::Services::HdmiCaptureDS"
        };

        public override bool ice_isA(string s)
        {
            if(IceInternal.AssemblyUtil.runtime_ == IceInternal.AssemblyUtil.Runtime.Mono)
            {
                // Mono bug: System.Array.BinarySearch() uses the wrong collation sequence,
                // so we do a linear search for the time being
                int pos = 0;
                while(pos < ids__.Length)
                {
                    if(ids__[pos] == s)
                    {
                        break;
                    }
                    ++pos;
                }
                if(pos == ids__.Length)
                {
                    pos = -1;
                }
                return pos >= 0;
            }
            else
            {
                return _System.Array.BinarySearch(ids__, s, _System.Collections.Comparer.DefaultInvariant) >= 0;
            }
        }

        public override bool ice_isA(string s, Ice.Current current__)
        {
            if(IceInternal.AssemblyUtil.runtime_ == IceInternal.AssemblyUtil.Runtime.Mono)
            {
                // Mono bug: System.Array.BinarySearch() uses the wrong collation sequence,
                // so we do a linear search for the time being
                int pos = 0;
                while(pos < ids__.Length)
                {
                    if(ids__[pos] == s)
                    {
                        break;
                    }
                    ++pos;
                }
                if(pos == ids__.Length)
                {
                    pos = -1;
                }
                return pos >= 0;
            }
            else
            {
                return _System.Array.BinarySearch(ids__, s, _System.Collections.Comparer.DefaultInvariant) >= 0;
            }
        }

        public override string[] ice_ids()
        {
            return ids__;
        }

        public override string[] ice_ids(Ice.Current current__)
        {
            return ids__;
        }

        public override string ice_id()
        {
            return ids__[1];
        }

        public override string ice_id(Ice.Current current__)
        {
            return ids__[1];
        }

        public static new string ice_staticId()
        {
            return ids__[1];
        }

        #endregion

        #region Operation dispatch

        public static IceInternal.DispatchStatus GetAllVideoCaptureDevices___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream os__ = inS__.ostr();
            string[] captureDeviceList;
            try
            {
                obj__.GetAllVideoCaptureDevices(out captureDeviceList, current__);
                os__.writeStringSeq(captureDeviceList);
                return IceInternal.DispatchStatus.DispatchOK;
            }
            catch(Services.HdmiCaptureDSEx ex)
            {
                os__.writeUserException(ex);
                return IceInternal.DispatchStatus.DispatchUserException;
            }
        }

        public static IceInternal.DispatchStatus GetVideoCaptureDevice___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream os__ = inS__.ostr();
            string deviceName;
            string vendorId;
            try
            {
                obj__.GetVideoCaptureDevice(out deviceName, out vendorId, current__);
                os__.writeString(deviceName);
                os__.writeString(vendorId);
                return IceInternal.DispatchStatus.DispatchOK;
            }
            catch(Services.HdmiCaptureDSEx ex)
            {
                os__.writeUserException(ex);
                return IceInternal.DispatchStatus.DispatchUserException;
            }
        }

        public static IceInternal.DispatchStatus GetPixelFormat___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream os__ = inS__.ostr();
            Services.CompressionType pixelFormat;
            obj__.GetPixelFormat(out pixelFormat, current__);
            os__.writeByte((byte)pixelFormat);
            return IceInternal.DispatchStatus.DispatchOK;
        }

        public static IceInternal.DispatchStatus SetPixelFormat___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream is__ = inS__.istr();
            Services.CompressionType pixelFormat;
            pixelFormat = (Services.CompressionType)is__.readByte();
            obj__.SetPixelFormat(pixelFormat, current__);
            return IceInternal.DispatchStatus.DispatchOK;
        }

        public static IceInternal.DispatchStatus GetVideoFormat___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream os__ = inS__.ostr();
            Services.VideoType videoFormat;
            obj__.GetVideoFormat(out videoFormat, current__);
            os__.writeByte((byte)videoFormat);
            return IceInternal.DispatchStatus.DispatchOK;
        }

        public static IceInternal.DispatchStatus SetVideoFormat___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream is__ = inS__.istr();
            Services.VideoType videoFormat;
            videoFormat = (Services.VideoType)is__.readByte();
            obj__.SetVideoFormat(videoFormat, current__);
            return IceInternal.DispatchStatus.DispatchOK;
        }

        public static IceInternal.DispatchStatus GetVideoCaptureDuration___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream os__ = inS__.ostr();
            int durationInSec;
            obj__.GetVideoCaptureDuration(out durationInSec, current__);
            os__.writeInt(durationInSec);
            return IceInternal.DispatchStatus.DispatchOK;
        }

        public static IceInternal.DispatchStatus SetVideoCaptureDuration___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream is__ = inS__.istr();
            IceInternal.BasicStream os__ = inS__.ostr();
            string duration;
            duration = is__.readString();
            try
            {
                obj__.SetVideoCaptureDuration(duration, current__);
                return IceInternal.DispatchStatus.DispatchOK;
            }
            catch(Services.HdmiCaptureDSEx ex)
            {
                os__.writeUserException(ex);
                return IceInternal.DispatchStatus.DispatchUserException;
            }
        }

        public static IceInternal.DispatchStatus GetOutputFolder___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream os__ = inS__.ostr();
            string folderPath;
            obj__.GetOutputFolder(out folderPath, current__);
            os__.writeString(folderPath);
            return IceInternal.DispatchStatus.DispatchOK;
        }

        public static IceInternal.DispatchStatus SetOutputFolder___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream is__ = inS__.istr();
            IceInternal.BasicStream os__ = inS__.ostr();
            string folderPath;
            folderPath = is__.readString();
            try
            {
                obj__.SetOutputFolder(folderPath, current__);
                return IceInternal.DispatchStatus.DispatchOK;
            }
            catch(Services.HdmiCaptureDSEx ex)
            {
                os__.writeUserException(ex);
                return IceInternal.DispatchStatus.DispatchUserException;
            }
        }

        public static IceInternal.DispatchStatus StartVideoCaptureToFile___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream is__ = inS__.istr();
            IceInternal.BasicStream os__ = inS__.ostr();
            string aviFileName;
            aviFileName = is__.readString();
            try
            {
                obj__.StartVideoCaptureToFile(aviFileName, current__);
                return IceInternal.DispatchStatus.DispatchOK;
            }
            catch(Services.HdmiCaptureDSEx ex)
            {
                os__.writeUserException(ex);
                return IceInternal.DispatchStatus.DispatchUserException;
            }
        }

        public static IceInternal.DispatchStatus StopVideoCapture___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream os__ = inS__.ostr();
            try
            {
                obj__.StopVideoCapture(current__);
                return IceInternal.DispatchStatus.DispatchOK;
            }
            catch(Services.HdmiCaptureDSEx ex)
            {
                os__.writeUserException(ex);
                return IceInternal.DispatchStatus.DispatchUserException;
            }
        }

        public static IceInternal.DispatchStatus RegisterHdmiCaptureDSEvents___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream is__ = inS__.istr();
            Services.HdmiCaptureDSEventsPrx receiver;
            receiver = Services.HdmiCaptureDSEventsPrxHelper.read__(is__);
            obj__.RegisterHdmiCaptureDSEvents(receiver, current__);
            return IceInternal.DispatchStatus.DispatchOK;
        }

        public static IceInternal.DispatchStatus UnregisterHdmiCaptureDSEvents___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream is__ = inS__.istr();
            Services.HdmiCaptureDSEventsPrx receiver;
            receiver = Services.HdmiCaptureDSEventsPrxHelper.read__(is__);
            obj__.UnregisterHdmiCaptureDSEvents(receiver, current__);
            return IceInternal.DispatchStatus.DispatchOK;
        }

        public static IceInternal.DispatchStatus ShutDown___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            obj__.ShutDown(current__);
            return IceInternal.DispatchStatus.DispatchOK;
        }

        public static IceInternal.DispatchStatus GrabStillFrame___(HdmiCaptureDS obj__, IceInternal.Incoming inS__, Ice.Current current__)
        {
            checkMode__(Ice.OperationMode.Normal, current__.mode);
            IceInternal.BasicStream is__ = inS__.istr();
            string pictureFileName;
            pictureFileName = is__.readString();
            obj__.GrabStillFrame(pictureFileName, current__);
            return IceInternal.DispatchStatus.DispatchOK;
        }

        private static string[] all__ =
        {
            "GetAllVideoCaptureDevices",
            "GetOutputFolder",
            "GetPixelFormat",
            "GetVideoCaptureDevice",
            "GetVideoCaptureDuration",
            "GetVideoFormat",
            "GrabStillFrame",
            "ice_id",
            "ice_ids",
            "ice_isA",
            "ice_ping",
            "RegisterHdmiCaptureDSEvents",
            "SetOutputFolder",
            "SetPixelFormat",
            "SetVideoCaptureDuration",
            "SetVideoFormat",
            "ShutDown",
            "StartVideoCaptureToFile",
            "StopVideoCapture",
            "UnregisterHdmiCaptureDSEvents"
        };

        public override IceInternal.DispatchStatus dispatch__(IceInternal.Incoming inS__, Ice.Current current__)
        {
            int pos;
            if(IceInternal.AssemblyUtil.runtime_ == IceInternal.AssemblyUtil.Runtime.Mono)
            {
                // Mono bug: System.Array.BinarySearch() uses the wrong collation sequence,
                // so we do a linear search for the time being
                pos = 0;
                while(pos < all__.Length)
                {
                    if(all__[pos] == current__.operation)
                    {
                        break;
                    }
                    ++pos;
                }
                if(pos == all__.Length)
                {
                    pos = -1;
                }
            }
            else
            {
                pos = _System.Array.BinarySearch(all__, current__.operation, _System.Collections.Comparer.DefaultInvariant);
            }
            if(pos < 0)
            {
                return IceInternal.DispatchStatus.DispatchOperationNotExist;
            }

            switch(pos)
            {
                case 0:
                {
                    return GetAllVideoCaptureDevices___(this, inS__, current__);
                }
                case 1:
                {
                    return GetOutputFolder___(this, inS__, current__);
                }
                case 2:
                {
                    return GetPixelFormat___(this, inS__, current__);
                }
                case 3:
                {
                    return GetVideoCaptureDevice___(this, inS__, current__);
                }
                case 4:
                {
                    return GetVideoCaptureDuration___(this, inS__, current__);
                }
                case 5:
                {
                    return GetVideoFormat___(this, inS__, current__);
                }
                case 6:
                {
                    return GrabStillFrame___(this, inS__, current__);
                }
                case 7:
                {
                    return ice_id___(this, inS__, current__);
                }
                case 8:
                {
                    return ice_ids___(this, inS__, current__);
                }
                case 9:
                {
                    return ice_isA___(this, inS__, current__);
                }
                case 10:
                {
                    return ice_ping___(this, inS__, current__);
                }
                case 11:
                {
                    return RegisterHdmiCaptureDSEvents___(this, inS__, current__);
                }
                case 12:
                {
                    return SetOutputFolder___(this, inS__, current__);
                }
                case 13:
                {
                    return SetPixelFormat___(this, inS__, current__);
                }
                case 14:
                {
                    return SetVideoCaptureDuration___(this, inS__, current__);
                }
                case 15:
                {
                    return SetVideoFormat___(this, inS__, current__);
                }
                case 16:
                {
                    return ShutDown___(this, inS__, current__);
                }
                case 17:
                {
                    return StartVideoCaptureToFile___(this, inS__, current__);
                }
                case 18:
                {
                    return StopVideoCapture___(this, inS__, current__);
                }
                case 19:
                {
                    return UnregisterHdmiCaptureDSEvents___(this, inS__, current__);
                }
            }

            _System.Diagnostics.Debug.Assert(false);
            return IceInternal.DispatchStatus.DispatchOperationNotExist;
        }

        #endregion

        #region Marshaling support

        public override void write__(IceInternal.BasicStream os__)
        {
            os__.writeTypeId(ice_staticId());
            os__.startWriteSlice();
            os__.endWriteSlice();
            base.write__(os__);
        }

        public override void read__(IceInternal.BasicStream is__, bool rid__)
        {
            if(rid__)
            {
                /* string myId = */ is__.readTypeId();
            }
            is__.startReadSlice();
            is__.endReadSlice();
            base.read__(is__, true);
        }

        public override void write__(Ice.OutputStream outS__)
        {
            Ice.MarshalException ex = new Ice.MarshalException();
            ex.reason = "type Services::HdmiCaptureDS was not generated with stream support";
            throw ex;
        }

        public override void read__(Ice.InputStream inS__, bool rid__)
        {
            Ice.MarshalException ex = new Ice.MarshalException();
            ex.reason = "type Services::HdmiCaptureDS was not generated with stream support";
            throw ex;
        }

        #endregion
    }
}
