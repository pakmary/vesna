using System;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Globalization;
using System.Threading;
using Vesna.Business.Data;
using Vesna.Forms;

namespace Vesna {
	internal static class Program {
		public static string User = "User";
		public static string PPVKName { get; set; }
		public static string ControlPlace { get; set; }
		public static RoadType CurrentRoadType { get; set; }	
		public static bool IsFederalRoad { get; set; }
		public static bool IsSoftRoad { get; set; }
		public static string ScaleNumber { get; set; }

		private static OleDbConnection _connection;
		private static readonly OleDbDataAdapter Adapter = new OleDbDataAdapter();
		private static readonly string MyDbPath = $@"{Application.StartupPath}\Files\database_inspector.mdb";
		private static string ConStr;

		[STAThread]
		private static void Main() {
            CultureInfo ci = new CultureInfo("ru-Ru");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            UpdateBaseFile(MyDbPath);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new InitForm());
		}

		public static void UpdateBaseFile(string path) {
			ConStr = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path};Jet OLEDB:Database Password=hfpdbnbt";
		}

		private static void ConOpen() {
			try {
				_connection = new OleDbConnection(ConStr);
				_connection.Open();
			} catch (Exception e) {
				MessageBox.Show($"Ошибка: не удалось загрузить базу данных\n{MyDbPath}\n{e.Message}");
			}
		}

		private static void ConClose() {
			try {
				_connection.Close();
			} catch (Exception e) {
				MessageBox.Show($"Ошибка: не удалось закрыть подключение к базе данных\n{MyDbPath}\n{e.Message}");
			}
		}

		public static int MakeAccess(string strcom) {
			var command = new OleDbCommand(strcom, _connection);
			return MakeAccess(command);
		}

		public static int MakeAccess(OleDbCommand com) {
			try {
				ConOpen();
				com.Connection = _connection;
				com.ExecuteScalar();
				ConClose();
				return 0;
			} catch (Exception e) {
				MessageBox.Show($"ОШИБКА: Не удалось выполнить запрос\n{com.CommandText}\n{e.Message}");
				return -1;
			}
		}

		public static DataTable GetAccess(string com) {
			if (com == string.Empty) {
				return null;
			}
			var dt = new DataTable();
			ConOpen();
			var command = new OleDbCommand(com, _connection);
			ConClose();

			try {
				Adapter.SelectCommand = command;
				Adapter.Fill(dt);
			} catch (Exception ex) {
				MessageBox.Show($"ОШИБКА: Не удалось выполнить запрос \n{com}\n{ex.Message}");
			}
			return dt;
		}

		/*public static void AddToLog(DateTime dateTime, string text) {
			MakeAccess(string.Format("INSERT INTO Log_base VALUES ( '{0}' , '{1}' , 'Пользователь' " + " )", dateTime.ToString("dd.MM.yyyy HH:mm:ss"), text));
		}*/
	}
}
