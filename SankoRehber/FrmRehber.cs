using DevExpress.Export;
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
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();

        }
        RehberService service;

        private void FrmRehber_Load(object sender, EventArgs e)
        {
            try
            {
                TxtID.Enabled = false;
                GrpCntrlRehberIslem.Visible = Login.isAdmin;
                if (Login.isAdmin == false)
                {
                    GridCntrlRehber.Dock = DockStyle.Top;
                    GridCntrlRehber.Width = 1520;
                    ExporttExcel.Left = 1425;
                    ExporttPdf.Left = 1300;
                    ExporttWord.Left = 1175;
                    pictureEdit2.Visible = true;
                    labelControl16.Visible = true;
                    labelControl17.Visible = true;
                    ExporttExcel.Visible = false;
                    ExporttPdf.Visible = false;
                    ExporttWord.Visible = false;
                    BtnYenile.Visible = true;
                    
                }
                Sifreİslemleri.Visible = Login.isAdmin;
                //GridCntrlRehber.Dock = DockStyle.Right;
                service = new RehberService();
                GridListele();
                Fit.FitColums(GridWiewRehber);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Sistem Sunucuya Bağlanamıyor Lütfen Yetkili İle İletişime Geçiniz", "Bağlantı Sorunu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var hata = ex;
            }
        }

        private void GridWiewRehber_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            TxtID.Text = GridWiewRehber.GetFocusedRowCellValue("ID")?.ToString();
            TxtFırmaAd.Text = GridWiewRehber.GetFocusedRowCellValue("Firma_Adı")?.ToString();
            TxtLokasyon.Text = GridWiewRehber.GetFocusedRowCellValue("Lokasyon")?.ToString();
            TxtDepartman.Text = GridWiewRehber.GetFocusedRowCellValue("Departman")?.ToString();
            TxtAd.Text = GridWiewRehber.GetFocusedRowCellValue("Adı")?.ToString();
            TxtSoyad.Text = GridWiewRehber.GetFocusedRowCellValue("Soyadı")?.ToString();
            TxtYetkili.Text = GridWiewRehber.GetFocusedRowCellValue("Yetkili")?.ToString();
            TxtDahili1.Text = GridWiewRehber.GetFocusedRowCellValue("Dahili_1")?.ToString();
            TxtDahili2.Text = GridWiewRehber.GetFocusedRowCellValue("Dahili_2")?.ToString();
            TxtDahili3.Text = GridWiewRehber.GetFocusedRowCellValue("Dahili_3")?.ToString();
            TxtTelefon.Text = GridWiewRehber.GetFocusedRowCellValue("Telefon")?.ToString();
            TxtCepTelefonu.Text = GridWiewRehber.GetFocusedRowCellValue("Cep_Telefonu")?.ToString();
            TxtFaks.Text = GridWiewRehber.GetFocusedRowCellValue("Faks_No")?.ToString();
        }
        private void Sifreİslemleri_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSifreİslem frm = new FrmSifreİslem();
                frm.Show();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Sistem Sunucuya Bağlanamıyor Lütfen Yetkili İle İletişime Geçiniz", "Bağlantı Sorunu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var hata = ex;
            }
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtFırmaAd.Text != "")
                {
                    TblRehber k = new TblRehber();
                    k.FİRMA_ADI = TxtFırmaAd.Text;
                    k.LOKASYON = TxtLokasyon.Text;
                    k.DEPARTMAN = TxtDepartman.Text;
                    k.ADI = TxtAd.Text;
                    k.SOYADI = TxtSoyad.Text;
                    k.YETKİLİ = TxtYetkili.Text;
                    k.DAHİLİ_1 = TxtDahili1.Text;
                    k.DAHİLİ_2 = TxtDahili2.Text;
                    k.DAHİLİ_3 = TxtDahili3.Text;
                    k.TELEFON = TxtTelefon.Text;
                    k.CEP_TELEFONU = TxtCepTelefonu.Text;
                    k.FAX_NO = TxtFaks.Text;
                    var res = service.RehberKaydet(k);
                    if (res > 0)
                    {
                        GridListele();
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
            /*int id = int.Parse(TxtID.Text);
            var sil = db.TblRehberSet.Find(id);
            db.TblRehberSet.Remove(sil);
            var res = db.SaveChanges();
            if (res > 0)
            {
                //listele();
                temizle();
                MessageBox.Show("Kişi Başarıyla Silindi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kişi Silinemedi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //listele();*/
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
                        var res = service.RehberSil(id);
                        if (res)
                        {
                            GridListele();
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
                if (TxtID.Text != "")
                {
                    int id = int.Parse(TxtID.Text);
                    // var guncelle = db.TblRehber.Find(id);
                    var guncelle = service.GetRehber(id);
                    guncelle.FİRMA_ADI = TxtFırmaAd.Text;
                    guncelle.LOKASYON = TxtLokasyon.Text;
                    guncelle.DEPARTMAN = TxtDepartman.Text;
                    guncelle.ADI = TxtAd.Text;
                    guncelle.SOYADI = TxtSoyad.Text;
                    guncelle.YETKİLİ = TxtYetkili.Text;
                    guncelle.DAHİLİ_1 = TxtDahili1.Text;
                    guncelle.DAHİLİ_2 = TxtDahili2.Text;
                    guncelle.DAHİLİ_3 = TxtDahili3.Text;
                    guncelle.TELEFON = TxtTelefon.Text;
                    guncelle.CEP_TELEFONU = TxtCepTelefonu.Text;
                    guncelle.FAX_NO = TxtFaks.Text;

                    var res = service.RehberGuncelle(guncelle);
                    //var res = db.SaveChanges();
                    if (res)
                    {
                        GridListele();
                        MessageBox.Show("Kişi Başarıyla Güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kişi Güncellenemedi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Kişi Güncellenemedi Güncellemek istediğiniz kişiyi seçin.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Sistem Sunucuya Bağlanamıyor Lütfen Yetkili İle İletişime Geçiniz", "Bağlantı Sorunu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var hata = ex;
            }


        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            try
            {
                GridListele();
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

        public void GridListele()
        {

            GridCntrlRehber.DataSource = service.listele();
        }

        public void Temizle()
        {
            TxtID.Text = "";
            TxtFırmaAd.Text = "";
            TxtLokasyon.Text = "";
            TxtDepartman.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtYetkili.Text = "";
            TxtDahili1.Text = "";
            TxtDahili2.Text = "";
            TxtDahili3.Text = "";
            TxtTelefon.Text = "";
            TxtCepTelefonu.Text = "";
            TxtFaks.Text = "";
        }

        public bool ExportExcel(string filename)
        {
            if (GridWiewRehber.FocusedRowHandle < 0)
            {

            }
            else
            {
                var dialog = new SaveFileDialog();
                dialog.Title = @"Excel Belge Çıkar";
                dialog.FileName = filename;
                dialog.Filter = @"Microsoft Excel|.xlsx";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    GridWiewRehber.ColumnPanelRowHeight = 40;
                    GridWiewRehber.OptionsPrint.AutoWidth = AutoSize;
                    GridWiewRehber.OptionsPrint.ShowPrintExportProgress = true;
                    GridWiewRehber.OptionsPrint.AllowCancelPrintExport = true;

                    ExportSettings.DefaultExportType = ExportType.Default;
                    GridWiewRehber.ExportToXlsx(dialog.FileName);
                    XtraMessageBox.Show("Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return false;
        }

        public bool ExportPdf(string filename)
        {
            if (GridWiewRehber.FocusedRowHandle < 0)
            {

            }
            else
            {
                var dialog = new SaveFileDialog();
                dialog.Title = @"PDF Çıkar";
                dialog.FileName = filename;
                dialog.Filter = @"pdf|.pdf";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    GridWiewRehber.ColumnPanelRowHeight = 40;
                    GridWiewRehber.OptionsPrint.AutoWidth = AutoSize;
                    GridWiewRehber.OptionsPrint.ShowPrintExportProgress = true;
                    GridWiewRehber.OptionsPrint.AllowCancelPrintExport = true;

                    ExportSettings.DefaultExportType = ExportType.Default;
                    GridWiewRehber.ExportToPdf(dialog.FileName);
                    XtraMessageBox.Show("Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return false;
        }

        public bool ExportWord(string filename)
        {
            if (GridWiewRehber.FocusedRowHandle < 0)
            {

            }
            else
            {
                var dialog = new SaveFileDialog();
                dialog.Title = @"Word Belge Çıkar";
                dialog.FileName = filename;
                dialog.Filter = @"Microsoft Word|.docx";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    GridWiewRehber.ColumnPanelRowHeight = 40;
                    GridWiewRehber.OptionsPrint.AutoWidth = AutoSize;
                    GridWiewRehber.OptionsPrint.ShowPrintExportProgress = true;
                    GridWiewRehber.OptionsPrint.AllowCancelPrintExport = true;

                    ExportSettings.DefaultExportType = ExportType.Default;
                    GridWiewRehber.ExportToDocx(dialog.FileName);
                    XtraMessageBox.Show("Başarılı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return false;
        }

        private void ExporttExcel_Click(object sender, EventArgs e)
        {
            ExportExcel("");
        }

        private void ExporttPdf_Click(object sender, EventArgs e)
        {
            ExportPdf("");
        }

        private void ExporttWord_Click(object sender, EventArgs e)
        {
            ExportWord("");
        }

        private void BtnYenile_Click(object sender, EventArgs e)
        {
            try
            {
                GridListele();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Sistem Sunucuya Bağlanamıyor Lütfen Yetkili İle İletişime Geçiniz", "Bağlantı Sorunu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var hata = ex;
            }
        }
    }
}
