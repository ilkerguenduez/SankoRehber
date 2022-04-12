using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SankoRehber.Properties;

namespace SankoRehber
{
    public partial class FrmSifreİslem : Form
    {
        RehberService service;
        //DbRehber db = new DbRehber();


        public FrmSifreİslem()
        {
            InitializeComponent();
        }
        //void listele()
        //{
        //    var veriler = from x in db.TblUser
        //                  select new
        //                  {
        //                      x.ID,
        //                      x.KULLANICIAD,
        //                      x.SIFRE
        //                  };
        //    GridCntrlSifre.DataSource = veriler.ToList();
        //    Fit.FitColums(GridWiewSifre);
        //}

        private void FrmSifreİslem_Load(object sender, EventArgs e)
        {
            try
            {
                TxtID.Enabled = false;
                //listele();
                //service.listele();
                service = new RehberService();
                sifList();
                Fit.FitColums(GridWiewSifre);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Sistem Sunucuya Bağlanamıyor Lütfen Yetkili İle İletişime Geçiniz", "Bağlantı Sorunu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var hata = ex;
            }
        }

        private void GridWiewSifre_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = GridWiewSifre.GetFocusedRowCellValue("ID")?.ToString();
            TxtKullanıcıAdı.Text = GridWiewSifre.GetFocusedRowCellValue("KULLANICIAD")?.ToString();
            TxtSifre.Text = GridWiewSifre.GetFocusedRowCellValue("SIFRE")?.ToString();
        }
        public void sifList()
        {
            GridCntrlSifre.DataSource = service.sifreListele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtKullanıcıAdı.Text != null)
                {
                    TblUser k = new TblUser();
                    k.KULLANICIAD = TxtKullanıcıAdı.Text;
                    k.SIFRE = TxtSifre.Text;
                    var res = service.UserKyadet(k);
                    if (res > 0)
                    {
                        sifList();
                        Temizle();
                        MessageBox.Show("Kişi Başarıyla Eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kişi Eklenemedi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Bilgileri Doğru ve Eksiksiz Giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Sistem Sunucuya Bağlanamıyor Lütfen Yetkili İle İletişime Geçiniz", "Bağlantı Sorunu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var hata = ex;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Silmek İstediğinize Emin Misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (TxtID.Text == "")
                    {
                        MessageBox.Show("Kişi Silinemedi.Silmek istediğiniz kişiyi seçiniz", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        int id = int.Parse(TxtID.Text);
                        var res = service.UserSil(id);
                        if (res)
                        {
                            sifList();
                            Temizle();
                            MessageBox.Show("Kişi Başarıyla Silindi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Kişi Silinemedi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Sistem Sunucuya Bağlanamıyor Lütfen Yetkili İle İletişime Geçiniz", "Bağlantı Sorunu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var hata = ex;
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(TxtID.Text);
                // var guncelle = db.TblUser.Find(id);
                var guncelle = service.GetUser(id);
                guncelle.KULLANICIAD = TxtKullanıcıAdı.Text;
                guncelle.SIFRE = TxtSifre.Text;

                var res = service.UserGuncelle(guncelle);
                //var res = db.SaveChanges();
                if (res)
                {
                    sifList();
                    Temizle();
                    MessageBox.Show("Kişi Başarıyla Güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Kişi Güncellenemedi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Sistem Sunucuya Bağlanamıyor Lütfen Yetkili İle İletişime Geçiniz", "Bağlantı Sorunu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var hata = ex;
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            try
            {
                Temizle();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Sistem Sunucuya Bağlanamıyor Lütfen Yetkili İle İletişime Geçiniz", "Bağlantı Sorunu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var hata = ex;
            }
            
        }
        public void Temizle()
        {
            TxtID.Text = "";
            TxtKullanıcıAdı.Text = "";
            TxtSifre.Text = "";
        }
    }
}

