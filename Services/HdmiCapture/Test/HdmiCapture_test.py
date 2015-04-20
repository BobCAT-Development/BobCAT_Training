import os, sys, traceback, Ice, AutoTestIce
import time
import subprocess

autotest_home = os.getenv("AUTOTEST_HOME")
sys.path.append(os.path.join(autotest_home, "src"))
sys.path.append(autotest_home)

import Services

from Services        import HdmiCaptureClient

if __name__ == "__main__":
    ceaptureRecvProc = None
    captureReceiverServerCmd = 'python ' + autotest_home + '/Services/HdmiCapture/Client/HdmiCaptureReceiver.py'
    ceaptureRecvProc = subprocess.Popen([captureReceiverServerCmd], shell = True)
    print "ceaptureRecvProc PID : ", ceaptureRecvProc.pid
    time.sleep(5)

    ic = None
    ic = Ice.initialize(sys.argv)

    print "ic = ", ic

    try:
        capture = HdmiCaptureClient.init(ic)
    except:
        print "HdmiCapture is NOT available"
        HdmiCaptureClient.KillProcess(ceaptureRecvProc)
        sys.exit(1)

    print "HdmiCapture is Available"

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
                print "9: Change Video Format"
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
                elif cmd == "9\n":
                    print "Do you want to change Video Format?"
                    print " 1:HD720p50"
                    print " 2:HD720p60"
                    print " 3:HD1080i50"
                    print " 4:HD1080i60"
                    print " 5:HD1080p50"
                    print " 6:HD1080p60"
                    sys.stdout.write("SelectVideo Format Number >> ")
                    cmd_form  = sys.stdin.readline()

                    if cmd_form == "1\n":
                        video_f = Services.VideoType.HD720p50
                    elif cmd_form == "2\n":
                        video_f = Services.VideoType.HD720p60
                    elif cmd_form == "3\n":
                        video_f = Services.VideoType.HD1080i50
                    elif cmd_form == "4\n":
                        video_f = Services.VideoType.HD1080i60
                    elif cmd_form == "5\n":
                        video_f = Services.VideoType.HD1080p50
                    elif cmd_form == "6\n":
                        video_f = Services.VideoType.HD1080p60

                    capture.SetVideoFormat(video_f)
                    print ' Change Format: ' , str(cmd_form)

                elif cmd == "\n" or cmd ==".\n":
                    break

        elif cmd == ".\n" or cmd =="\n":
            break

    HdmiCaptureClient.KillProcess(ceaptureRecvProc)
    print "End."