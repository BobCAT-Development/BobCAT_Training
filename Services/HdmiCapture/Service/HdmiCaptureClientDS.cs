
using System;
using Services;
using System.Reflection;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;


namespace HdmiCaptureService
{
    public class HdmiCaptureClientDS : Ice.Application
    {
        private String m_DeviceName, m_VendorId, m_CaptureTime, m_OutputFolder;
        private CompressionType m_PixelFormat;
        private VideoType m_VideoFormat;

        private static void menu()
        {
            String Menus = 
                "----------------------------\n" +
                "  Hdmi Capture - Main menu  \n" +
                "----------------------------\n" +
             // "  d: Select (d)evice\n"         +
                "  p: Set (p)ixel format\n"      +
                "  v: Set (v)ideo format\n"      +
                "  t: Set capture (t)ime\n"      +
                "  f: Set output (f)older\n"     +
                "  s: (s)tart capture\n"         +
                "  e: (e)nd capture\n"           +
                "  g: (g)rab picture\n"          +
                "  r: (r)esume all settings\n"   +
                "\n"                             +
                "  m: this (m)enu\n"             +
                "\n"                             +
                "  c: (c)lose server\n"          +
                "  x: E(x)it client\n"           +
                "----------------------------\n";

            Console.WriteLine(Menus);
        }

        public override int run(string[] args)
        {
            Int32 i, Index, CurrentPos, LastPos, CaptureTime;
            String line;

            try
            {
                HdmiCaptureDSPrx twoway = HdmiCaptureDSPrxHelper.checkedCast(
                        communicator().propertyToProxy("HdmiCaptureDS.Proxy").ice_twoway().ice_timeout(-1).ice_secure(false));
                if (twoway == null)
                {
                    Console.Error.WriteLine("Invalid proxy");
                    return 1;
                }
                //HdmiCaptureDSPrx oneway = HdmiCaptureDSPrxHelper.uncheckedCast(twoway.ice_oneway());
                //HdmiCaptureDSPrx batchOneway = HdmiCaptureDSPrxHelper.uncheckedCast(twoway.ice_batchOneway());
                //HdmiCaptureDSPrx datagram = HdmiCaptureDSPrxHelper.uncheckedCast(twoway.ice_datagram());
                //HdmiCaptureDSPrx batchDatagram = HdmiCaptureDSPrxHelper.uncheckedCast(twoway.ice_batchDatagram());


                Ice.ObjectAdapter adapter = communicator().createObjectAdapter("HdmiCaptureDSEvents");
                adapter.add(new EventsReceiverI(), communicator().stringToIdentity("EventsReceiver"));
                adapter.activate();

                HdmiCaptureDSEventsPrx twowayRec = HdmiCaptureDSEventsPrxHelper.uncheckedCast(
                    adapter.createProxy(communicator().stringToIdentity("EventsReceiver")));
                twoway.RegisterHdmiCaptureDSEvents(twowayRec);

                m_DeviceName = m_VendorId = m_CaptureTime = m_OutputFolder = "-";

                // ======================================================================================
                // Default settings
                // ======================================================================================
                twoway.GetVideoCaptureDevice(out m_DeviceName, out m_VendorId);
                Console.WriteLine(String.Format("Device name : <{0}> ({1})", m_DeviceName, m_VendorId));

                twoway.GetPixelFormat(out m_PixelFormat);
                Console.WriteLine(String.Format("Pixel format : <{0}>", m_PixelFormat));

                twoway.GetVideoFormat(out m_VideoFormat);
                Console.WriteLine(String.Format("Video format : <{0}>", m_VideoFormat));

                twoway.GetOutputFolder(out m_OutputFolder);
                Console.WriteLine(String.Format("Output folder : <{0}>", m_OutputFolder));

                twoway.GetVideoCaptureDuration(out CaptureTime);
                if (CaptureTime == Int32.MaxValue)
                {
                    m_CaptureTime = "Infinity";
                }
                else
                {
                    TimeSpan Span = new TimeSpan(0, 0, CaptureTime);
                    m_CaptureTime = Span.ToString();
                }
                Console.WriteLine(String.Format("Capture time : <{0}>", m_CaptureTime));

                // ======================================================================================

                Console.WriteLine();
                menu();

                LastPos = Console.CursorTop;
                line = String.Empty;

                do
                {
                    try
                    {
                        CurrentPos = Console.CursorTop;
                        if ((CurrentPos + 15) - LastPos > Console.WindowHeight)
                        {
                            LastPos = CurrentPos;
                            Console.WriteLine();
                            menu();
                        }

                        Console.Out.WriteLine();
                        Console.Out.Write("Main menu ==> ");
                        Console.Out.Flush();
                        line = Console.In.ReadLine();
                        if (String.IsNullOrEmpty(line) == true)
                        {
                            continue;
                        }

                        switch (line)
                        {
                            case "d":
                                Console.WriteLine("<Select device> feature doesn't supported in this version...");
                                #region Devices
                                //String[] DevicesList;

                                //twoway.GetVideoCaptureDevices(out DevicesList);
                                //if (DevicesList.Length > 0)
                                //{
                                //    DISPLAY_DEVICES:
                                //    for (i = 0; i < DevicesList.Length; i++)
                                //    {
                                //        Console.WriteLine(String.Format(" {0} - {1}", i + 1, DevicesList[i]));
                                //    }
                                //    Console.WriteLine();
                                //    Console.WriteLine("Please enter the index of the desired card :");
                                //    Console.Write("Device ==> ");
                                //    Console.Out.Flush();
                                //    line = Console.In.ReadLine();
                                //    if (String.IsNullOrEmpty(line) == true)
                                //    {
                                //        continue;
                                //    }
                                //    if (Int32.TryParse(line, out Index) == true)
                                //    {
                                //        if (Index - 1 < DevicesList.Length && Index - 1 > -1)
                                //        {
                                //            twoway.SetVideoCaptureDevice(DevicesList[Index - 1]);
                                //            m_DeviceName = DevicesList[Index - 1];
                                //            Console.WriteLine(String.Format("Device <{0}> selected !", DevicesList[Index - 1]));
                                //        }
                                //        else
                                //        {
                                //            Console.WriteLine("You have selected a wrong index !!");
                                //            goto DISPLAY_DEVICES;
                                //        }
                                //    }
                                //    else
                                //    {
                                //        Console.WriteLine("You have selected a wrong index !!");
                                //        goto DISPLAY_DEVICES;
                                //    }
                                //}
                                //else
                                //{
                                //    Console.WriteLine("Impossible to get available capture devices !!");
                                //} 
                                #endregion
                                break;

                            case "p":
                                #region Pixel Format
                                String[] PixelFormats;

                                DISPLAY_FORMAT:
                                    PixelFormats = Enum.GetNames(typeof(CompressionType));
                                for (i = 0; i < PixelFormats.Length; i++)
                                {
                                    Console.WriteLine(String.Format(" {0} - {1}", i + 1, PixelFormats[i]));
                                }
                                Console.WriteLine();
                                Console.WriteLine("Please enter the index of the desired format :");
                                DisplayWaitPrompt("Pixel format");
                                Console.Out.Flush();
                                line = Console.In.ReadLine();
                                if (String.IsNullOrEmpty(line) == true)
                                {
                                    continue;
                                }
                                if (Int32.TryParse(line, out Index) == true)
                                {
                                    if (Index - 1 < PixelFormats.Length && Index - 1 > -1)
                                    {
                                        twoway.SetPixelFormat((CompressionType)Enum.Parse(typeof(CompressionType), PixelFormats[Index - 1]));
                                        m_PixelFormat = (CompressionType)Enum.Parse(typeof(CompressionType), PixelFormats[Index - 1]);
                                        Console.WriteLine(String.Format("Format <{0}> selected !", PixelFormats[Index - 1]));
                                    }
                                    else
                                    {
                                        Console.WriteLine("You have selected a wrong index !!");
                                        goto DISPLAY_FORMAT;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You have selected a wrong index !!");
                                    goto DISPLAY_FORMAT;
                                }
                                    #endregion
                                break;

                            case "v":
                                #region Video Format
                                String[] VideoFormats;

                                DISPLAY_VIDEO:
                                    VideoFormats = Enum.GetNames(typeof(VideoType));
                                for (i = 0; i < VideoFormats.Length; i++)
                                {
                                    Console.WriteLine(String.Format(" {0} - {1}", i + 1, VideoFormats[i]));
                                }
                                Console.WriteLine();
                                Console.WriteLine("Please enter the index of the desired format :");
                                DisplayWaitPrompt("Video format");
                                Console.Out.Flush();
                                line = Console.In.ReadLine();
                                if (String.IsNullOrEmpty(line) == true)
                                {
                                    continue;
                                }
                                if (Int32.TryParse(line, out Index) == true)
                                {
                                    if (Index - 1 < VideoFormats.Length && Index - 1 > -1)
                                    {
                                        twoway.SetVideoFormat((VideoType)Enum.Parse(typeof(VideoType), VideoFormats[Index - 1]));
                                        m_VideoFormat = (VideoType)Enum.Parse(typeof(VideoType), VideoFormats[Index - 1]);
                                        Console.WriteLine(String.Format("Format <{0}> selected !", VideoFormats[Index - 1]));
                                    }
                                    else
                                    {
                                        Console.WriteLine("You have selected a wrong index !!");
                                        goto DISPLAY_VIDEO;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You have selected a wrong index !!");
                                    goto DISPLAY_VIDEO;
                                }
                                #endregion
                                break;

                            case "t":
                                #region Capture Time
                                Regex DurationFormat = new Regex(@"\d{2}:\d{2}:\d{2}");
                                Match RegularExp;

                                DISPLAY_DURATION:
                                    Console.WriteLine("Please enter the capture time in the following format: HH:MM:SS :");
                                Console.WriteLine("00:00:00 means 'Infinity'");
                                DisplayWaitPrompt("Capture time");
                                Console.Out.Flush();
                                line = Console.In.ReadLine();
                                if (String.IsNullOrEmpty(line) == true)
                                {
                                    continue;
                                }
                                RegularExp = DurationFormat.Match(line);
                                if (RegularExp.Success == true)
                                {
                                    twoway.SetVideoCaptureDuration(line);
                                    m_CaptureTime = line;
                                    if (m_CaptureTime.Equals("00:00:00") == true)
                                    {
                                        Console.WriteLine(String.Format("Capture time is set to <{0}>", "Infinity"));
                                    }
                                    else
                                    {
                                        Console.WriteLine(String.Format("Capture time is set to <{0}>", line));
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You have entered a capture time wrong format !!");
                                    goto DISPLAY_DURATION;
                                }
                                #endregion
                                break;

                            case "f":
                                #region Folder
                                DISPLAY_FOLDER:
                                    Console.WriteLine("Please enter the full path of the desired output folder :");
                                DisplayWaitPrompt("Output folder");
                                Console.Out.Flush();
                                line = Console.In.ReadLine();
                                if (String.IsNullOrEmpty(line) == true)
                                {
                                    continue;
                                }
                                if (String.IsNullOrEmpty(line) == false)
                                {
                                    twoway.SetOutputFolder(line);
                                    m_OutputFolder = line;
                                    Console.WriteLine(String.Format("Output folder is set to <{0}>", line));
                                }
                                else
                                {
                                    Console.WriteLine("You have entered a wrong format folder !!");
                                    goto DISPLAY_FOLDER;
                                }
                                #endregion
                                break;

                            case "s":
                                #region Start capture
                                Console.WriteLine("Please enter the filename without extension of the desired video file (AVI) :");
                                DisplayWaitPrompt("Video file");
                                Console.Out.Flush();
                                line = Console.In.ReadLine();
                                if (String.IsNullOrEmpty(line) == true)
                                {
                                    continue;
                                }
                                twoway.StartVideoCaptureToFile(String.Format("{0}.avi", line));
                                Console.WriteLine(String.Format("Capture on going to the file\n<{0}.avi>...", Path.Combine(m_OutputFolder, line)));
                                #endregion
                                break;

                            case "e":
                                #region End capture
                                Console.WriteLine("Do you really want to stop the capture (y/n) ?");
                                DisplayWaitPrompt("Stop capture");
                                Console.Out.Flush();
                                line = Console.In.ReadLine();
                                if (line.ToLower() == "y")
                                {
                                    twoway.StopVideoCapture();
                                    Console.WriteLine("Current capture is stopped successfully !");
                                }
                                #endregion
                                break;

                            case "g":
                                #region Grab picture
                                FileInfo FileName;
                                Console.WriteLine("Please enter the filename of the desired picture file\n" +
                                                    "with one of the following extensions (no extension means <JPG>\n" +
                                                    ".bmp, .emf, .gif, .jpg, .png, .tiff, .wmf :");
                                DisplayWaitPrompt("Picture file");
                                Console.Out.Flush();
                                line = Console.In.ReadLine();
                                if (String.IsNullOrEmpty(line) == true)
                                {
                                    continue;
                                }
                                FileName = new FileInfo(line);
                                twoway.GrabStillFrame(FileName.Name);
                                if (FileName.Extension.Equals(String.Empty) == true)
                                {
                                    Console.WriteLine(String.Format("Grab picture to the file\n<{0}.jpg>...", Path.Combine(m_OutputFolder, line)));
                                }
                                else
                                {
                                    Console.WriteLine(String.Format("Grab picture to the file\n<{0}>...", Path.Combine(m_OutputFolder, FileName.Name)));
                                }
                                #endregion
                                break;

                            case "r":
                                #region Resume settings
                                Console.Clear();
                                Console.WriteLine("--------------------------------------------------------");
                                Console.WriteLine("  Hdmi Capture - Resume    ");
                                Console.WriteLine("--------------------------------------------------------");
                                Console.WriteLine(String.Format(" Device selected        : {0}", m_DeviceName));
                                Console.WriteLine(String.Format(" Pixel format selected  : {0}", m_PixelFormat));
                                Console.WriteLine(String.Format(" Video format selected  : {0}", m_VideoFormat));
                                Console.WriteLine(String.Format(" Capture time value     : {0}", m_CaptureTime));
                                Console.WriteLine(String.Format(" Output folder selected : {0}", m_OutputFolder));
                                Console.WriteLine("--------------------------------------------------------");
                                #endregion
                                break;

                            case "m":
                                Console.Clear();
                                menu();
                                break;

                            case "c":
                                Console.WriteLine("Shutdown server...");
                                if (twoway != null && twowayRec != null)
                                {
                                    twoway.UnregisterHdmiCaptureDSEvents(twowayRec);
                                }
                                twoway.ShutDown();
                                break;

                            case "x":
                                Console.WriteLine("Bye...");
                                break;

                                            default:
                                Console.WriteLine("!!!!!!!!!!!!!!!!!");
                                Console.WriteLine("Unknow command...");
                                Console.WriteLine("!!!!!!!!!!!!!!!!!");
                                Console.WriteLine();
                                menu();
                                break;
                        }
                    }
                    catch (Ice.ConnectionLostException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("! ! ! ! ! ! ! ! ! ! !");
                        Console.WriteLine(" ICE Server is down !");
                        Console.WriteLine("! ! ! ! ! ! ! ! ! ! !");
                        Console.ReadLine();

                        return 2;
                    }
                    catch (System.Exception ex)
                    {
                        Console.Error.WriteLine(ex);
                    }
                }
                while (!line.Equals("x"));

                return 0;
            }
            catch (Ice.ConnectionRefusedException ConRefEx)
            {
                Exception Ex = new Exception("Are you sure that 'Server' is started ??", ConRefEx);
                ThreadExceptionDialog ExpDialog = new ThreadExceptionDialog(Ex);
                ExpDialog.ShowDialog();
                return 2;
            }            
            catch (Exception Ex)
            {
                while (Ex.InnerException != null)
                {
                    Ex = Ex.InnerException;
                }

                ThreadExceptionDialog ExpDialog = new ThreadExceptionDialog(Ex);
                ExpDialog.ShowDialog();
                return 2;
            }
            finally
            {
            }
        }

        public static void Main(string[] args)
        {
            Version AppVersion;
            Int32 AppStatus;
            HdmiCaptureClientDS App;
            String DefaultCfgFileName;

            try
            {
                Console.WindowWidth = 80;
                Console.WindowHeight = 50;
                AppVersion = Assembly.GetAssembly(typeof(HdmiCaptureClientDS)).GetName().Version;
                Console.Title = String.Format(" [ ICE Client ] - Hdmi Capture DirectShow - ({0}.{1}{2}{3})", AppVersion.Major, AppVersion.Minor, AppVersion.Build, AppVersion.Revision);

                DefaultCfgFileName = "config.client"; 
                App = new HdmiCaptureClientDS();
                if (args.Length == 0)
                {
                    if (File.Exists(DefaultCfgFileName) == false)
                    {
                        throw new Exception(String.Format("The config file <{0}> doesn't exist !!", Path.Combine(Directory.GetCurrentDirectory(), DefaultCfgFileName)));
                    }
                    AppStatus = App.main(args, DefaultCfgFileName);
                }
                else
                {
                    foreach (String item in args)
                    {
                        if (item.ToLower().StartsWith("--ice.config=") == true)
                        {
                            String[] Cfg = item.Split("=".ToCharArray());
                            if (Cfg.Length == 2)
                            {
                                if (File.Exists(Cfg[1]) == false)
                                {
                                    throw new Exception(String.Format("The config file <{0}> doesn't exist !!", Path.Combine(Directory.GetCurrentDirectory(), Cfg[1])));
                                }
                            }
                        }
                    }

                    AppStatus = App.main(args);
                }
                if (AppStatus != 0)
                {
                    System.Environment.Exit(AppStatus);
                }
            }
            catch (Exception Ex)
            {
                while (Ex.InnerException != null)
                {
                    Ex = Ex.InnerException;
                }

                ThreadExceptionDialog ExpDialog = new ThreadExceptionDialog(Ex);
                ExpDialog.ShowDialog();
            }
            finally
            {
            }
        }

        private void DisplayWaitPrompt(String prefix)
        {
            try
            {
                Console.WriteLine("Press [ENTER] directly to return to main menu...");
                Console.Write(String.Format("{0} ==> ", prefix));
            }
            catch (System.Exception Ex)
            {
                throw Ex;
            }
            finally
            {
            }
        }
    }
}