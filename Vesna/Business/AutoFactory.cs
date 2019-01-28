using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Vesna.Business {
	static class AutoFactory {
		private const string Folder = "./Data/";

		public static void Save(Auto auto) {
			var xml = new XmlSerializer(typeof(Auto));
			using (var fStream = new FileStream(string.Format("{0}{1}.xml", Folder, auto.IdAuto), FileMode.Create, FileAccess.Write, FileShare.None)) {
				xml.Serialize(fStream, auto);
			}
		}

		public static Auto Load(Guid id) {
			Auto auto = null;
			var xml = new XmlSerializer(typeof(Auto));
			string path = string.Format("{0}{1}.xml", Folder, id);
			if (File.Exists(path)) {
				using (var fStream = File.OpenRead(path)) {
					auto = (Auto) xml.Deserialize(fStream);
				}
			}
			return auto;
		}

		public static Auto[] GetAllData() {
			var listAuto = new List<Auto>();

			foreach (string file in Directory.GetFiles(Folder, "*.xml")) {
				string fileName = Path.GetFileNameWithoutExtension(file);
				Guid guid;
				if (Guid.TryParse(fileName, out guid)) {
					listAuto.Add(Load(guid));
				}
			}

			return listAuto.ToArray();
		}
	}
}
