using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SnapshotsOfLifeEx02
{
    static class Program
    {

        /*public static MainWindow mw;
        public static ChoiceWindow cw = new ChoiceWindow();*/

        /*       [DllImport("Coredll.dll")]
               public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

               [DllImport("coredll.dll")]
               public static extern int GetWindowLong(IntPtr hWnd, int nIndex);


               static void DisableAnimation(Form form)
               {
                   const int WS_EX_NOANIMATION = 0x04000000;
                   const int GWL_EX_STYLE = -20;

                   int style = GetWindowLong(form.Handle, GWL_EX_STYLE);
                   style |= WS_EX_NOANIMATION;
                   SetWindowLong(form.Handle, GWL_EX_STYLE, style);
               }*/

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        /// 

        public static string appName = "SnapshotsOfLifeEx02";

        [STAThread]
        static void Main()
        {

            // 중복실행 체크
            if (IsRunningCheck())
            {
                MessageBox.Show("이미 프로그램이 실행 중 입니다.");
                return;
            }


            // Initialization of SDK
            uint err = EDSDKLib.EDSDK.EdsInitializeSDK();

            bool isSDKLoaded = false;
            if (err == EDSDKLib.EDSDK.EDS_ERR_OK)
            {
                isSDKLoaded = true;
            }

            //Acquisition of camera list
            IntPtr cameraList = IntPtr.Zero;
            if (err == EDSDKLib.EDSDK.EDS_ERR_OK)
            {
                err = EDSDKLib.EDSDK.EdsGetCameraList(out cameraList);
            }

            //Acquisition of number of Cameras
            if (err == EDSDKLib.EDSDK.EDS_ERR_OK)
            {
                int count = 0;
                err = EDSDKLib.EDSDK.EdsGetChildCount(cameraList, out count);
                if (count == 0)
                {
                    err = EDSDKLib.EDSDK.EDS_ERR_DEVICE_NOT_FOUND;
                }
            }



            //Acquisition of camera at the head of the list
            IntPtr camera = IntPtr.Zero;
            if (err == EDSDKLib.EDSDK.EDS_ERR_OK)
            {
                err = EDSDKLib.EDSDK.EdsGetChildAtIndex(cameraList, 0, out camera);
            }

            //Acquisition of camera information
            EDSDKLib.EDSDK.EdsDeviceInfo deviceInfo;
            if (err == EDSDKLib.EDSDK.EDS_ERR_OK)
            {
                err = EDSDKLib.EDSDK.EdsGetDeviceInfo(camera, out deviceInfo);
                if (err == EDSDKLib.EDSDK.EDS_ERR_OK && camera == IntPtr.Zero)
                {
                    err = EDSDKLib.EDSDK.EDS_ERR_DEVICE_NOT_FOUND;
                }
            }


            //Release camera list
            if (cameraList != IntPtr.Zero)
            {
                EDSDKLib.EDSDK.EdsRelease(cameraList);
            }

            //Create Camera model
            CameraModel model = null;
            if (err == EDSDKLib.EDSDK.EDS_ERR_OK)
            {
                model = new CameraModel(camera);
            }

            if (err != EDSDKLib.EDSDK.EDS_ERR_OK)
            {
                MessageBox.Show("Cannot detect camera");
            }

            EDSDKLib.EDSDK.EdsPropertyEventHandler handlePropertyEvent = new EDSDKLib.EDSDK.EdsPropertyEventHandler(CameraEventListener.HandlePropertyEvent);
            EDSDKLib.EDSDK.EdsObjectEventHandler handleObjectEvent = new EDSDKLib.EDSDK.EdsObjectEventHandler(CameraEventListener.HandleObjectEvent);
            EDSDKLib.EDSDK.EdsStateEventHandler handleStateEvent = new EDSDKLib.EDSDK.EdsStateEventHandler(CameraEventListener.HandleStateEvent);

            CameraController controller;
            if (err == EDSDKLib.EDSDK.EDS_ERR_OK)
            {
                //Create CameraController
                controller = new CameraController(ref model);
                GCHandle handle = GCHandle.Alloc(controller);
                IntPtr ptr = GCHandle.ToIntPtr(handle);

                //Set Property Event Handler
                if (err == EDSDKLib.EDSDK.EDS_ERR_OK)
                {
                    err = EDSDKLib.EDSDK.EdsSetPropertyEventHandler(camera, EDSDKLib.EDSDK.PropertyEvent_All, handlePropertyEvent, ptr);
                }

                //Set Object Event Handler
                if (err == EDSDKLib.EDSDK.EDS_ERR_OK)
                {
                    err = EDSDKLib.EDSDK.EdsSetObjectEventHandler(camera, EDSDKLib.EDSDK.ObjectEvent_All, handleObjectEvent, ptr);
                }

                //Set State Event Handler
                if (err == EDSDKLib.EDSDK.EDS_ERR_OK)
                {
                    err = EDSDKLib.EDSDK.EdsSetCameraStateEventHandler(camera, EDSDKLib.EDSDK.StateEvent_All, handleStateEvent, ptr);
                    
                }

                controller.Run();

                Application.EnableVisualStyles();
                /*Application.SetCompatibleTextRenderingDefault(false);*/

                IObserver form = new MainWindow(ref controller);
                model.Add(ref form);

                Application.Run((MainWindow)form);

                handle.Free();
            }

            GC.KeepAlive(handlePropertyEvent);
            GC.KeepAlive(handleObjectEvent);
            GC.KeepAlive(handleStateEvent);

            //Release Camera
            if (camera != IntPtr.Zero)
            {
                EDSDKLib.EDSDK.EdsRelease(camera);
            }

            //Termination of SDK
            if (isSDKLoaded)
            {
                EDSDKLib.EDSDK.EdsTerminateSDK();
            }



            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());*/
        }

        // 중복 프로그램 실행 방지
        public static bool IsRunningCheck()
        {
            System.Diagnostics.Process[] processes = null;
            string strCurrentProcess = System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToUpper();
            processes = System.Diagnostics.Process.GetProcessesByName(strCurrentProcess);

            if (processes.Length > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // 레지스토리에 시작프로그램으로 등록 - 안됨
        /*public static void WindowStartSet()
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run",true))
            {
                try
                {
                    if(rk.GetValue(appName) == null)
                    {
                        rk.SetValue(appName, Application.ExecutablePath.ToString());
                    }

                    rk.Close();
                }
                catch (Exception ex)
                {

                }
            }
        
        }


        public static void WindowStartRemove()
        {
            using (RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                try
                {
                    if (rk.GetValue(appName) != null)
                    {
                        rk.DeleteValue(appName, false);
                    }

                    rk.Close();
                }
                catch (Exception ex)
                {

                }
            }

        }*/
    }
}
