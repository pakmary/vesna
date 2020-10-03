using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video.DirectShow;

namespace Vesna.Business.Utils {
	public static class VideoUtil {
		public static VideoCaptureDevice VideoSource;
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
				}
				//make default to first cam
			} catch (ApplicationException) {
				_deviceExist = false;
			}
			return list.ToArray();
		}

		public static void Start(int indexDev) {
			try {
				if (_deviceExist) {
					VideoSource = new VideoCaptureDevice(_videoDevices[indexDev].MonikerString);
					CloseVideoSource();
					VideoSource.DesiredFrameSize = new Size(160, 120);
					VideoSource.Start();
				}
			} catch (Exception e) {
				MessageBox.Show(e.Message);
			}
		}

		public static void CloseVideoSource() {
			if (VideoSource != null && VideoSource.IsRunning) {
				VideoSource.SignalToStop();
				VideoSource = null;
			}
		}
	}
}