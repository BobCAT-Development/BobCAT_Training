using System;
using System.Collections.Generic;
using System.Text;

// Add by user
using Services;


namespace HdmiCaptureService
{
    class EventsReceiverI : HdmiCaptureDSEventsDisp_
    {
        public override void EndCaptureReached(Ice.Current current__)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Capture is done !");
            Console.ResetColor();
        }

        public override void SendMessage(string message, Ice.Current current__)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(String.Format("(From Server) --> {0}", message));
            Console.ResetColor();
        }
    }
}
