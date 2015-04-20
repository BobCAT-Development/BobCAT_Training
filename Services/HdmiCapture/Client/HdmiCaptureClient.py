# -*- coding: UTF-8 -*-
##
# @summary: $Id$
# @copyright: Sony Corporation

import os, sys, traceback, Ice, time
import subprocess
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

def KillProcess(proc):
    if proc and proc.poll() == None:
        print "Killing " + str(proc.pid)
        p = subprocess.Popen(['TASKKILL',
                              '/PID', str(proc.pid),
                              '/F', '/T'],
                              stdout=subprocess.PIPE,
                              stderr=subprocess.PIPE)
        while p.poll() == None:
            print ".",
            time.sleep(0.1)
        print "Done"

def demo(capture):
    photoFolder = autotest_home + '\\db\\results\\photo\\'
    capture.SetOutputFolder(photoFolder)
    getFolder = capture.GetOutputFolder()
    print "** Output Folder *** ", getFolder

    while 1:
        print "HDMI Capture Service TEST"
        print "0: Start"
        print ".: Exit"
        sys.stdout.write("SelectCommand >> ")
        cmd  = sys.stdin.readline()

        if cmd == "0\n":
            while 1:
                print
                print "0: Any Functions"
                print "1: StartVideoCaptureToFile"
                print "2: StopVideoCapture"
                print "3: GrabStillFrame"
                print ".: return to mode select"
                sys.stdout.write("SelectCommand >> ")
                cmd  = sys.stdin.readline()

                if cmd == "0\n":
                    sys.stdout.write("Function Name ex)StartVideoCaptureToFile(filename)\n >> ")
                    cmd  = sys.stdin.readline()
                    funcname = cmd[:-1]
                    execStr = "res = capture." + funcname
                    exec(execStr)
                    print "return = ", res

                elif cmd == "1\n":
                    sys.stdout.write("File Name (input name only; caputerd 'name.avi') >> ")
                    cmd  = sys.stdin.readline()
                    filename = cmd[:-1] + ".avi"
                    print "File Name : ", filename
                    capture.StartVideoCaptureToFile(filename)
                    print "Capture Start ..."

                elif cmd == "2\n":
                    capture.StopVideoCapture()
                    print "... Capture Stop"

                elif cmd == "3\n":
                    sys.stdout.write("File Name (if filename has no extension, default extension is JPG) >> ")
                    cmd  = sys.stdin.readline()
                    filename = cmd[:-1]
                    print "File Name : ", filename
                    capture.GrabStillFrame(filename)
                    print "Captured"

                elif cmd == "\n" or cmd ==".\n":
                    break

        elif cmd == ".\n" or cmd =="\n":
            return

if __name__ == "__main__":
    try:
        ceaptureRecvProc = None
        captureReceiverServerCmd = 'python ' + autotest_home + '/Services/HdmiCapture/Client/HdmiCaptureReceiver.py'
        ceaptureRecvProc = subprocess.Popen([captureReceiverServerCmd], shell = True)
        print "ceaptureRecvProc PID : ", ceaptureRecvProc.pid
        time.sleep(5)

        ic = None
        ic = Ice.initialize(sys.argv)

        try:
            capture = init(ic)
        except:
            print("HdmiCapture is NOT available")
            KillProcess(ceaptureRecvProc)
            sys.exit(1)

        print("HdmiCapture is Available")

        demo(capture)
        KillProcess(ceaptureRecvProc)
        print "End."

    except:
        KillProcess(ceaptureRecvProc)
        print("\nExcept\n")