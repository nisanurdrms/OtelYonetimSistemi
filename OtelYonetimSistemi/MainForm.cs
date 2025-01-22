using System;
using System.Windows.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        // Add the event handler in the constructor
        menuOdaYonetimi.Click += MenuOdaYonetimi_Click;
    }

    private void MenuOdaYonetimi_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Test"); // First test if click works
        try
        {
            OdaDetayForm odaDetayForm = new OdaDetayForm();
            odaDetayForm.ShowDialog();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Hata: " + ex.Message);
        }
    }
} 