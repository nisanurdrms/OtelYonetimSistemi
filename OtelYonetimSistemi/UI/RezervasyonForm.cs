using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OtelYonetimSistemi.UI
{
    public partial class RezervasyonForm : Form
    {
        public RezervasyonForm()
        {
            InitializeComponent();
        }

        

        private void btnRezervasyonYap_Click(object sender, EventArgs e)
        {
            
            DateTime checkInDate = dtpGirisTarihi.Value;
            DateTime checkOutDate = dtpCikisTarihi.Value;

           
            string odaTipi = cmbOdaTipi.SelectedItem?.ToString() ?? "Belirtilmedi";
            string adSoyad = txtAdSoyad.Text;
            string telNumarasi = txtTelNumarasi.Text;

            
            if (checkOutDate <= checkInDate)
            {
                MessageBox.Show("Çıkış tarihi giriş tarihinden sonra olmalıdır.");
                return;
            }

            
            string rezervasyonOzeti = $"Misafir: {adSoyad}\n" +
                                        $"Telefon: {telNumarasi}\n" +
                                        $"Oda Tipi: {odaTipi}\n" +
                                        $"Giriş Tarihi: {checkInDate.ToShortDateString()}\n" +
                                        $"Çıkış Tarihi: {checkOutDate.ToShortDateString()}";

           
            rtbOzet.Text = rezervasyonOzeti;

            MessageBox.Show("Rezervasyon başarıyla oluşturuldu!");
        }
    }
    
}
