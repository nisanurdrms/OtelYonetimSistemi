using System;
using System.Windows.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        // Add the event handler in the constructor
        menuOdaYonetimi.Click += MenuOdaYonetimi_Click;

        Button btnOda = new Button();
        btnOda.FlatStyle = FlatStyle.Flat;
        btnOda.FlatAppearance.BorderSize = 0;
        btnOda.Click += new EventHandler(btnOda_Click);
        flpOdalar.Controls.Add(btnOda);
    }

    private void MenuOdaYonetimi_Click(object sender, EventArgs e)
    {
        try
        {
            // Önce bağlantıyı test edelim
            using (var connection = dbBaglanti.BaglantiGetir())
            {
                if (connection != null)
                {
                    OdaDetayForm odaDetayForm = new OdaDetayForm();
                    odaDetayForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Veritabanına bağlanılamadı!", "Bağlantı Hatası",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Form açılırken hata oluştu: {ex.Message}", "Hata",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnOda_Click(object sender, EventArgs e)
    {
        // btnOda_Click event handler implementation
    }
} 