private void InitializeComponent()
{
    this.menuStrip1 = new System.Windows.Forms.MenuStrip();
    this.menuOdaYonetimi = new System.Windows.Forms.ToolStripMenuItem();
    
    // Add the MenuStrip to the form
    this.Controls.Add(this.menuStrip1);
    
    // Configure the menu item
    this.menuOdaYonetimi.Name = "menuOdaYonetimi";
    this.menuOdaYonetimi.Text = "Oda Yönetimi";
    this.menuOdaYonetimi.Click += new System.EventHandler(this.menuOdaYonetimi_Click);
    
    // Add the menu item to the MenuStrip
    this.menuStrip1.Items.Add(this.menuOdaYonetimi);
    
    // MenuStrip properties
    this.menuStrip1.Location = new System.Drawing.Point(0, 0);
    this.menuStrip1.Name = "menuStrip1";
    this.menuStrip1.Size = new System.Drawing.Size(800, 24);
    this.menuStrip1.TabIndex = 0;
    this.menuStrip1.Text = "menuStrip1";
    
    // MainForm properties
    this.MainMenuStrip = this.menuStrip1;
    // ... rest of the form initialization
}

private System.Windows.Forms.MenuStrip menuStrip1;
private System.Windows.Forms.ToolStripMenuItem menuOdaYonetimi; 