using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Vesna.Business.Data;

namespace Vesna.Business.Utils {
	static class SpravochnikUtil {
		public static object[] GetItemCollections(string curTable, string curCol, bool sort = true, string param = "") {
			var oc = new List<object>();
			DataTable dt = Program.GetAccess(string.Format("SELECT {0} FROM {1} {2}", curCol, curTable, param));
			foreach (DataRow r in dt.Rows) {
				oc.Add(r[curCol].ToString());
			}
			if (sort) {
				oc.Sort();
			}
			return oc.ToArray();
		}

		public static string GetDefaultValue(string tbl, string cur_col) {
			try {
				return Program.GetAccess(string.Format("SELECT * FROM {0} WHERE def = true", tbl)).Rows[0][cur_col].ToString();
			} catch {
				return string.Empty;
			}
		}

		public static int IdentificationNumber {
			get { return int.Parse(Program.GetAccess("SELECT id FROM idAvto").Rows[0]["id"].ToString()); }
			set { Program.MakeAccess("UPDATE idAvto SET id=" + value.ToString(CultureInfo.InvariantCulture)); }
		}

		public static DateTime GetVesiDate(string zavodNomer, string colName) {
			DateTime date = DateTime.Parse("01.01.2000");
			try {
				string res = Program.GetAccess(string.Format("SELECT {0} FROM sp_Vesi WHERE Zavod_nomer = '{1}'", colName, zavodNomer)).Rows[0][colName].ToString();
				date = DateTime.Parse(res);
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
			return date;
		}

		public static string ToStringVesiDate(string zavodNomer) {
			try {
				DataTable temp_dt = Program.GetAccess("SELECT * FROM sp_Vesi WHERE Zavod_nomer = '" + zavodNomer + "'");
				var dtOT = DateTime.Parse(temp_dt.Rows[0]["DateOT"].ToString());
				var dtDO = DateTime.Parse(temp_dt.Rows[0]["DateDO"].ToString());
				return string.Format("Дата поверки от '{0}' до '{1}'", dtOT.ToString("dd.MM.yyyy"), dtDO.ToString("dd.MM.yyyy"));
			} catch {
				return string.Empty;
			}
		}

		public static string GetSubWithKode(string kod) {
			try {
				return Program.GetAccess(string.Format("SELECT Sub FROM sp_Kod_sub WHERE Kod = {0}", kod)).Rows[0]["Sub"].ToString();
			} catch {
				return "Неизвестно";
			}
		}

		public static string GetAutoName(AutoType type) {
			return Program.GetAccess(string.Format("SELECT NameAuto FROM TypesAuto WHERE id = {0}", (int)type)).Rows[0]["NameAuto"].ToString();
		}

		public static string GetRoadDescription(RoadType type) {
			return Program.GetAccess(string.Format("SELECT Description FROM TypesRoad WHERE id = {0}", (int)type)).Rows[0]["Description"].ToString();
		}
	}
}
