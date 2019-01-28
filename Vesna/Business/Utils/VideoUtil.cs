using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video.DirectShow;

namespace Vesna.Business.Utils {
	public static class VideoUtil {
		public static VideoCaptureDevice VideoSource = null;
		
		private static bool _deviceExist;
		private static FilterInfoCollection _videoDevices;
		
		public static object[] GetCamList() {
			var list = new List<object>();
			try {
				_videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
				list.Clear();
				if (_videoDevices.Count == 0) {
					throw new ApplicationException();
				}
				_deviceExist = true;
				foreach (FilterInfo device in _videoDevices) {
					list.Add(device.Name);
				} //make dafault to first cam
			} catch (ApplicationException) {
				_deviceExist = false;
			}
			return list.ToArray();
		}

		public static void Start(int indexDev) {
			/*if (start.Text == "&Start")
            {*/
			try {
				if (_deviceExist) {
					VideoSource = new VideoCaptureDevice(_videoDevices[indexDev].MonikerString);
					//videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
					CloseVideoSource();
					VideoSource.DesiredFrameSize = new Size(160, 120);
					//videoSource.DesiredFrameRate = 10;
					VideoSource.Start();
					/*label2.Text = "Device running...";
                    start.Text = "&Stop";
                    timer1.Enabled = true;*/
				}
			} catch (Exception e) {
				MessageBox.Show(e.Message);
			}
			/*else
                {
                    label2.Text = "Error: No Device selected.";
                }
            }
            else
            {
                if (videoSource.IsRunning)
                {
                    timer1.Enabled = false;
                    CloseVideoSource();
                    label2.Text = "Device stopped.";
                    start.Text = "&Start";                    
                }
            }*/
		}

		public static void CloseVideoSource() {
			if (VideoSource != null && VideoSource.IsRunning) {
				VideoSource.SignalToStop();
				VideoSource = null;
			}
		}
	}
}