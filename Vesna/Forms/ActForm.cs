using System;
using System.Windows.Forms;
using Vesna.Business;
using Vesna.Business.Data;
using Vesna.Business.Utils;

namespace Vesna.Forms {
	public partial class ActForm : Form {
		private Auto _auto;
		private readonly AutoRepository _autoRepository = new AutoRepository();

		public ActForm() {
			InitializeComponent();
		}

		private bool CheckIt() {
			if (ModifierKeys == Keys.Shift) {
				return true;
			}
			bool flag = true;
			tb_error_msg.Text = string.Empty;
			string er = $"Заполните обязательные поля:{Environment.NewLine}";

			//if (cb_mesto_prov.Text.Length <= 2) { er += "Место контроля\n" + Environment.NewLine; flag = false; }
			//if (cb_imya_ppvk.Text.Length <= 2) { er += "Название ППВК\n" + Environment.NewLine; flag = false; }
			if (tb_marsh_dvig.Text.Length < 2) {
				er += $"Маршрут движения\n{Environment.NewLine}";
				flag = false;
			}
			if (cb_mark_1.Text.Length <= 2) {
				er += $"Марка ТС\n{Environment.NewLine}";
				flag = false;
			}
			//if (tb_tab_1_3.Text.Length <= 2) { MessageBox.Show("Заполните модель ТС"); return false; flag = false;}
			if (tb_reg_1.Text.Length <= 2) {
				er += $"Регистрационный номер ТС\n{Environment.NewLine}";
				flag = false;
			}
			if (cb_operat.Text.Length <= 2) {
				er += $"Оператор ППВК\n{Environment.NewLine}";
				flag = false;
			}
			if (cb_inspekt.Text.Length <= 2) {
				er += $"Инспектор ГБДД{Environment.NewLine}";
				flag = false;
			}
			if (cb_driver.Text.Length <= 2) {
				er += $"Водитель ТС\n{Environment.NewLine}";
				flag = false;
			}
			//if (cb_nomer_svid.Text.Length <= 0) { er += "Весовое оборудование\n" + Environment.NewLine; flag = false; }
			if (cb_kod_sub.Text.Length <= 0) {
				er += $"Код субъекта\n{Environment.NewLine}";
				flag = false;
			}
			try {
				int.Parse(tb_kol_poezdok.Text);
			} catch {
				er += "Количество поездок - Ошибка ввода" + Environment.NewLine;
				flag = false;
			}

			if (!flag) {
				tb_error_msg.Text = er;
			}
			return flag;
		}

		private void cb_strana_SelectedValueChanged(object sender, EventArgs e) {
			if (cb_strana.Text == "Российская федерация") {
				cb_kod_sub.Visible = true;
				l_sub.Visible = true;
			} else {
				l_sub.Text = string.Empty;
				l_sub.Visible = false;
				cb_kod_sub.Text = string.Empty;
				cb_kod_sub.Visible = false;
			}
		} // отключаем город и код субьекта при выборе другой страны

		private void FormAct_Load(object sender, EventArgs e) {
			if (_auto.IsCanEdit) {
				cb_inspekt.Items.AddRange(SpravochnikUtil.GetItemCollections("sp_Inspectors", "FIO"));
				cb_operat.Items.AddRange(SpravochnikUtil.GetItemCollections("sp_Operators", "FIO"));
				cb_kod_sub.Items.AddRange(SpravochnikUtil.GetItemCollections("sp_Kod_sub", "Kod"));
				cb_driver.Items.AddRange(SpravochnikUtil.GetItemCollections("sp_Driver", "name_Driver"));
				cb_vid_gruza.Items.AddRange(SpravochnikUtil.GetItemCollections("sp_Gruz", "name_gruz"));
				object[] col = SpravochnikUtil.GetItemCollections("sp_Mark", "name_Mark");
				cb_mark_1.Items.AddRange(col);
				cb_mark_2.Items.AddRange(col);
				cb_mark_3.Items.AddRange(col);

				cb_inspekt.Text = SpravochnikUtil.GetDefaultValue("sp_Inspectors", "FIO");
				cb_operat.Text = SpravochnikUtil.GetDefaultValue("sp_Operators", "FIO");
				cb_kod_sub.Text = SpravochnikUtil.GetDefaultValue("sp_Kod_sub", "Kod");

				if (cb_strana.Text == string.Empty) {
					cb_strana.Text = "Российская федерация";
				}
			}
		}

		private void cb_kod_sub_SelectedIndexChanged(object sender, EventArgs e) {
			if (cb_kod_sub.Text != string.Empty) {
				l_sub.Text = SpravochnikUtil.GetSubWithKode(cb_kod_sub.Text);
			}
		}

		private void SetCanEditAct(bool f) {
			foreach (Control c in Controls) {
				if ((c is TextBox || c is ComboBox) && !c.Equals(tb_primecanie)) {
					c.Enabled = f;
				}
			}
		}

		public void FillCurTCFromAct() {
			_auto.Datetime = DateTime.Parse(l_data.Text);
			/*curTC.Vesi.SvidetelstvoNomer = cb_nomer_svid.Text;
            curTC.Vesi.DatePoverkiOT = DateTime.Parse(l_ves_data.Text);//.ToString("dd.MM.yyyy HH:mm:ss");
            curTC.MestoKontrolya = cb_mesto_prov.Text;
            curTC.HarakterNarush = cb_hatakter_narush.Text;
            curTC.PPVK = cb_imya_ppvk.Text;*/

			_auto.Mark = cb_mark_1.Text;
			_auto.Model = tb_model_1.Text;
			_auto.RegNumber = tb_reg_1.Text;

			_auto.Trailer1.Kind = cb_vid_2.Text;
			_auto.Trailer1.Mark = cb_mark_2.Text;
			_auto.Trailer1.Model = tb_model_2.Text;
			_auto.Trailer1.RegNomer = tb_reg_2.Text;

			_auto.Trailer2.Kind = cb_vid_3.Text;
			_auto.Trailer2.Mark = cb_mark_3.Text;
			_auto.Trailer2.Model = tb_model_3.Text;
			_auto.Trailer2.RegNomer = tb_reg_3.Text;

			_auto.Sobstvenik = tb_sobstv.Text;
			_auto.SobstvenikAddess = tb_adres_sobs.Text;
			_auto.SobstvenikSvidetelstvo = tb_sobs_svid.Text;
			_auto.SobstvenikPricep = tb_sobstv_pricep.Text;
			_auto.SobstvenikPricepAddess = tb_sobstv_pricep_addess.Text;
			_auto.SobstvenikPricepSvidetelstvo = tb_sobstv_pricep_svid.Text;

			_auto.Road.County = cb_strana.Text;
			_auto.Road.Region = l_sub.Text;
			_auto.Road.RegionKode = int.Parse(cb_kod_sub.Text);

			_auto.VidGruza = cb_vid_gruza.Text;

			_auto.Road.WayText = tb_marsh_dvig.Text;
			_auto.Road.CountWays = int.Parse(tb_kol_poezdok.Text);

			_auto.HarakterGruza = cb_harakter_gruza.Text;
			_auto.VoditelObyasnenie = tb_obyasn_vodit.Text;

			_auto.OperatorPvk = cb_operat.Text;
			_auto.InspectorGibdd = cb_inspekt.Text;
			_auto.Driver = cb_driver.Text;
			_auto.DriverLicense = tb_driver_license.Text;

			_auto.Primechanie = tb_primecanie.Text;
		}

		public void LoadActFromAuto(Auto auto) {
			_auto = auto;
			l_nomer_act.Text = _auto.Id.ToString();
			if (_auto.Id == -1) {
				l_nomer_act.Text = "Новый";
			}
			SetCanEditAct(_auto.IsCanEdit);

			pb_foto.Image = _auto.Foto;
			l_data.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
			l_vid_1.Text = SpravochnikUtil.GetAutoName(_auto.AutoType);
			l_km.Text = _auto.Road.Distance.ToString();
			l_razm_usherba.Text = _auto.FullAutoDamage.ToString();
		}

		private void b_exit_Click(object sender, EventArgs e) {
			if (FillAndSaveTc() >= 0) {
				Close();
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			if (_auto.IsCanEdit) {
				if (FillAndSaveTc() >= 0) {
					WordExportUtil.Export(_auto);
				}
			}
		}

		private int FillAndSaveTc() {
			if (CheckIt()) {
				FillCurTCFromAct();
				int r = _autoRepository.Save(_auto);
				SetCanEditAct(_auto.IsCanEdit);
				l_nomer_act.Text = _auto.CarId + "." + _auto.Id;
				return r;
			}
			return -1;
		}

		private void b_print_Click(object sender, EventArgs e) {
			if (FillAndSaveTc() >= 0) {
				WordExportUtil.Print(_auto);
			}
		}
	}
}