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
			DataTable dt = Program.GetAccess($"SELECT {curCol} FROM {curTable} {param}");
			foreach (DataRow r in dt.Rows) {
				oc.Add(r[curCol].ToString());
			}
			if (sort) {
				oc.Sort();
			}
			return oc.ToArray();
		}

		public static string GetDefaultValue(string tbl, string curCol) {
			try {
				return Program.GetAccess($"SELECT * FROM {tbl} WHERE def = true").Rows[0][curCol].ToString();
			} catch {
				return string.Empty;
			}
		}

		public static int IdentificationNumber {
			get => int.Parse(Program.GetAccess("SELECT id FROM idAvto").Rows[0]["id"].ToString());
			set => Program.MakeAccess("UPDATE idAvto SET id=" + value.ToString(CultureInfo.InvariantCulture));
		}

		public static DateTime GetVesiDate(string zavodNomer, string colName) {
			DateTime date = DateTime.Parse("01.01.2000");
			try {
				string res = Program.GetAccess($"SELECT {colName} FROM sp_Vesi WHERE Zavod_nomer = '{zavodNomer}'").Rows[0][colName].ToString();
				date = DateTime.Parse(res);
			} catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
			return date;
		}

		public static string ToStringVesiDate(string zavodNomer) {
			try {
				DataTable tempDt = Program.GetAccess("SELECT * FROM sp_Vesi WHERE Zavod_nomer = '" + zavodNomer + "'");
				DateTime dtOt = DateTime.Parse(tempDt.Rows[0]["DateOT"].ToString());
				DateTime dtDo = DateTime.Parse(tempDt.Rows[0]["DateDO"].ToString());
				return $"Дата поверки от '{dtOt.ToString("dd.MM.yyyy")}' до '{dtDo.ToString("dd.MM.yyyy")}'";
			} catch {
				return string.Empty;
			}
		}

		public static string GetSubWithKode(string kod) {
			try {
				return Program.GetAccess($"SELECT Sub FROM sp_Kod_sub WHERE Kod = {kod}").Rows[0]["Sub"].ToString();
			} catch {
				return "Неизвестно";
			}
		}

		public static string GetAutoName(AutoType type) {
			return Program.GetAccess($"SELECT NameAuto FROM TypesAuto WHERE id = {(int)type}").Rows[0]["NameAuto"].ToString();
		}

		public static string GetRoadDescription(RoadType type) {
			return Program.GetAccess($"SELECT Description FROM TypesRoad WHERE id = {(int)type}").Rows[0]["Description"].ToString();
		}
	}
}