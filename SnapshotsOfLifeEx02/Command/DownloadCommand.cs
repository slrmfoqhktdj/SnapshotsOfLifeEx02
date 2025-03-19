/******************************************************************************
*                                                                             *
*   PROJECT : Eos Digital camera Software Development Kit EDSDK               *
*                                                                             *
*   Description: This is the Sample code to show the usage of EDSDK.          *
*                                                                             *
*                                                                             *
*******************************************************************************
*                                                                             *
*   Written and developed by Canon Inc.                                       *
*   Copyright Canon Inc. 2018 All Rights Reserved                             *
*                                                                             *
*******************************************************************************/

using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace SnapshotsOfLifeEx02
{
    class DownloadCommand : Command
    {
        private IntPtr _directoryItem = IntPtr.Zero;

        public DownloadCommand(ref CameraModel model,ref IntPtr inRef) : base(ref model)
        {
            _directoryItem = inRef;
        }

        ~DownloadCommand() 
        {
            if (_directoryItem != IntPtr.Zero)
            {
                EDSDKLib.EDSDK.EdsRelease(_directoryItem);
                _directoryItem = IntPtr.Zero;
            }
        }

        private CameraEvent _event;
        public override bool Execute()
	    {
                if(_model.canDownloadImage == false)
                {
                    return true;
                }

			Console.WriteLine("DownloadCommand");

			uint err = EDSDKLib.EDSDK.EDS_ERR_OK;
		        IntPtr stream = IntPtr.Zero;


		        //Acquisition of the downloaded image information
		        EDSDKLib.EDSDK.EdsDirectoryItemInfo	dirItemInfo;
		        err = EDSDKLib.EDSDK.EdsGetDirectoryItemInfo( _directoryItem, out dirItemInfo);
	
		        // Forwarding beginning notification	
		        if(err == EDSDKLib.EDSDK.EDS_ERR_OK)
		        {
                    CameraEvent e = new CameraEvent(CameraEvent.Type.DOWNLOAD_START, stream);
                    _model.NotifyObservers(e);
		        }

		        //Make the file stream at the forwarding destination
		        if(err == EDSDKLib.EDSDK.EDS_ERR_OK)
		        {	
			        err = EDSDKLib.EDSDK.EdsCreateFileStream(dirItemInfo.szFileName, EDSDKLib.EDSDK.EdsFileCreateDisposition.CreateAlways, EDSDKLib.EDSDK.EdsAccess.ReadWrite, out stream);
					Console.WriteLine("name = " + dirItemInfo.szFileName);
		        }

                //Set Progress
                if (err == EDSDKLib.EDSDK.EDS_ERR_OK)
                {
                    err = EDSDKLib.EDSDK.EdsSetProgressCallback(stream, ProgressFunc, EDSDKLib.EDSDK.EdsProgressOption.Periodically, stream);
                }

                //Down load image
		        if(err == EDSDKLib.EDSDK.EDS_ERR_OK)
		        {
			        err = EDSDKLib.EDSDK.EdsDownload( _directoryItem, dirItemInfo.Size, stream);
					Console.WriteLine("Down load image");
				}

		        //Forwarding completion
		        if(err == EDSDKLib.EDSDK.EDS_ERR_OK)
		        {
			        err = EDSDKLib.EDSDK.EdsDownloadComplete( _directoryItem);
					Console.WriteLine("Forwarding completion");
				}

		        //Release Item
		        if(_directoryItem != IntPtr.Zero)
		        {
			        err = EDSDKLib.EDSDK.EdsRelease( _directoryItem);
			        _directoryItem = IntPtr.Zero;
					Console.WriteLine("Release Item");
				}

		        //Release stream
		        if(stream != IntPtr.Zero)
		        {
			        err =  EDSDKLib.EDSDK.EdsRelease(stream);
			        stream = IntPtr.Zero;
					Console.WriteLine("Release stream");
				}		
		
		        // Forwarding completion notification
		        if( err == EDSDKLib.EDSDK.EDS_ERR_OK)
		        {
                    CameraEvent e = new CameraEvent(CameraEvent.Type.DOWNLOAD_COMPLETE, stream);
                    _model.NotifyObservers(e);
					Console.WriteLine("Forwarding completion notification" );

					/*Image img_1 = Image.FromFile(dirItemInfo.szFileName);*/
					/*Image img_2 = Properties.Resources.back1;*/
					/*Bitmap cImg = CombineImages((Bitmap)img_1, (Bitmap)img_2);
					cImg.Save("c_imag.jpg", ImageFormat.Jpeg);*/



				}

		        //Notification of error
		        if( err != EDSDKLib.EDSDK.EDS_ERR_OK)
		        {
                    CameraEvent e = new CameraEvent(CameraEvent.Type.ERROR, (IntPtr)err);
                    _model.NotifyObservers(e);
		        }
		        return true;
	    }

        private uint ProgressFunc(uint inPercent, IntPtr inContext, ref bool outCancel)
        {
            _event = new CameraEvent(CameraEvent.Type.PROGRESS, (IntPtr)inPercent);
            _model.NotifyObservers(_event);
			
			return 0;
        }

		private Bitmap CombineImages(Bitmap image1, Bitmap image2)
		{
			// 두 이미지의 크기를 기준으로 새로운 비트맵 생성
			int width = Math.Max(image1.Width, image2.Width);
			int height = Math.Max(image1.Height, image2.Height);
			Console.WriteLine("width = "+ image1.Width+" height = "+image1.Height);
			Bitmap combinedBitmap = new Bitmap(image1.Width, image1.Height);

			using (Graphics g = Graphics.FromImage(combinedBitmap))
			{
				// 첫 번째 이미지를 그린다
				
				g.DrawImage(image1, 0,0,image1.Width, image1.Height);

				// 두 번째 이미지를 겹쳐서 그린다
				g.DrawImage(image2, 0,0,image1.Width, image1.Height); // 원하는 위치에 그릴 수 있음
			}

			return combinedBitmap;
		}
	}
}
