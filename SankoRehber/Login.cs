using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SankoRehber
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static bool isAdmin = false;
        RehberEntities db = new RehberEntities();

        private void BtnGiris_Click(object sender, EventArgs e)
        {

            try
            {
                lblLoading.Visible = false;
                if (TabControlLogin.SelectedTabPageIndex > 0)
                {
                    lblLoading.Visible = true;
                    isAdmin = true;
                    var adminsorgu = (from x in db.TblAdmin
                                      where x.KULLANICIAD == TxtKullaniciAdi.Text & x.SIFRE == TxtSifre.Text
                                      select x);
                    if (adminsorgu.Any())
                    {
                        FrmRehber frm = new FrmRehber();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bilgileri Eksik veya Yanlış Girdiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                    lblLoading.Visible = true;
                    var usersorgu = (from x in db.TblUser
                                     where x.KULLANICIAD == TxtKullaniciAdi.Text & x.SIFRE == TxtSifre.Text
                                     select x);
                    if (usersorgu.Any())
                    {
                        FrmRehber frm = new FrmRehber();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        XtraMessageBox.Show("Bilgileri Eksik veya Yanlış Girdiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                lblLoading.Visible = false;
                XtraMessageBox.Show("Sistem Sunucuya Bağlanamıyor Lütfen Yetkili İle İletişime Geçiniz", "Bağlantı Sorunu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var hata = ex;
                

            }
        }

        private void TabControlLogin_Click(object sender, EventArgs e)
        {
            if (TabControlLogin.SelectedTabPageIndex > 0)
            {
                TxtKullaniciAdi.Text = "";
                TxtSifre.Text = "";
            }
            else
            {
                TxtKullaniciAdi.Text = "sanko";
                TxtSifre.Text = "sanko";
            }
        }
    }
}
