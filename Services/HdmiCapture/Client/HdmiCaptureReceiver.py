# -*- coding: UTF-8 -*-
##
# @summary: $Id$
# @copyright: Sony Corporation

import os, sys, traceback, Ice, time
autotest_home = os.getenv("AUTOTEST_HOME")

Ice.loadSlice('--all ' + os.path.normpath(autotest_home + '/Services/HdmiCapture/Slice/HdmiCaptureDS.ice'))

import Services
import IceGrid

def init(ic):
        capture = None
        proxyProperty = 'hdmicaptureDS.Proxy'
        properties = ic.getProperties()
        proxy = properties.getProperty(proxyProperty)
        base = ic.stringToProxy(proxy)
        if not base:
            raise RuntimeError("Invalid property:" + proxyProperty)

        capture = Services.HdmiCaptureDSPrx.checkedCast(base.ice_twoway().ice_timeout(-1).ice_secure(False))

        if not capture:
            raise RuntimeError("Invalid proxy")

        print 'capture: ', capture

        return capture


class myReceiver(Services.HdmiCaptureDSEvents):
    def __init__(self):
        pass

    def EndCaptureReached(self, current = None):
        print " >> Capture is done !"

    def SendMessage(self, message, current = None):
        print "(From Server) --> " + message


class HdmiCaptureReceiver(Ice.Application):
    def __init__(self, capture, myReceiver):
        self.capture = capture
        self.myR = myReceiver

    def run(self, args):
        capture = self.capture

        adapter = self.communicator().createObjectAdapter("HdmiCaptureDSEvents")
        adapter.add(self.myR, self.communicator().stringToIdentity("hdmicapturereceiver"))
        adapter.activate()

        captureR = Services.HdmiCaptureDSEventsPrx.uncheckedCast(
            adapter.createProxy(self.communicator().stringToIdentity("hdmicapturereceiver")))

        if not captureR:
            print self.appName() + ": invalid proxy"
            return 1

        print 'captureR: ', captureR

        #capture.UnregisterHdmiCaptureDSEvents(captureR)
        capture.RegisterHdmiCaptureDSEvents(captureR)
        print 'CB within Python client was registered'

        print 'HdmiCaptureReceiver : waitForShutdown'
        self.communicator().waitForShutdown()

        capture.UnregisterHdmiCaptureDSEvents(captureR)
        self.communicator().destroy()


if __name__ == "__main__":
    ic = None
    ic = Ice.initialize(sys.argv)

    try:
        capture = init(ic)
    except:
        print("HdmiCapture is NOT available in Receiver.py")
        sys.exit(1)

    print("HdmiCapture is Available in Receiver.py")

    captureReceiver = HdmiCaptureReceiver(capture, myReceiver())
    captureReceiver.main(sys.argv)
