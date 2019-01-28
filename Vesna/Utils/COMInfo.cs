using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace Vesna {
	internal class ComInfo {
		private static SerialPort _arduino;
		public string AllData;
		public string Znak;
		public float Ves;
		public int CountPoint;
		public string Control;
		public bool HaveError = false;
		public string ErrorMessage;

		public static string[] GetListCOM() {
			return SerialPort.GetPortNames();
		}

		public static int Open() {
			if (_arduino != null && _arduino.IsOpen) {
				Close();
			}
			_arduino = new SerialPort(Properties.Settings.Default.COMPortName, 9600, Parity.None, 8, StopBits.One);
			//if (arduino.IsOpen) { return 0; }
			try {
				_arduino.Open();
				return 0;
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
				return -1;
			}
		}

		public static void Close() {
			_arduino.Close();
		}

		private static string GetData() {
			//Random r = new Random();
			//return "+00" + r.Next(1000, 9999) + "01F\x3";
			//Open();

			if (_arduino != null && _arduino.IsOpen) {
				return _arduino.ReadExisting();
			}
			return string.Empty;
		}

		public static ComInfo GetVes() {
			var res = new ComInfo();
			string data = GetData();
			res.AllData = data;

			int indexEnd = data.LastIndexOf('\x3');
			if (indexEnd >= 10) {
				try {
					string d = data.Substring(indexEnd - 10, 10);
					res.Znak = d.Substring(0, 1);
					res.Ves = (float.Parse(d.Substring(1, 6)))/1000;
					if (res.Znak == "-") {
						res.Ves *= -1;
					}
					res.CountPoint = int.Parse(d.Substring(7, 1));
					res.Control = d.Substring(8, 2);
				} catch (Exception ex) {
					res.HaveError = true;
					res.ErrorMessage = ex.Message;
				}
			} else {
				res.HaveError = true;
				res.ErrorMessage = "От весов поступило не достаточно данных для обработки";
			}
			//data.Remove(indexEnd);
			return res; // vesArray[vesArray.Length - 1].ToString();
		}
	}
}
