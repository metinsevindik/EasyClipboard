using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CopyToClipboard = new System.Windows.Forms.Button();
            this.copytoFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_domain = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_durum = new System.Windows.Forms.Label();
            this.textBox_content = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_library = new System.Windows.Forms.TextBox();
            this.textBox_Domain_Url = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_clipboardfilesfolder = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_clipboardTextFilename = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_UserType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button_clearFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CopyToClipboard
            // 
            this.CopyToClipboard.Cursor = System.Windows.Forms.Cursors.PanSouth;
            this.CopyToClipboard.Font = new System.Drawing.Font("Segoe UI", 19F);
            this.CopyToClipboard.Location = new System.Drawing.Point(151, 259);
            this.CopyToClipboard.Name = "CopyToClipboard";
            this.CopyToClipboard.Size = new System.Drawing.Size(129, 97);
            this.CopyToClipboard.TabIndex = 8;
            this.CopyToClipboard.Text = "AL";
            this.CopyToClipboard.UseVisualStyleBackColor = true;
            this.CopyToClipboard.Click += new System.EventHandler(this.CopyToClipboard_Click);
            // 
            // copytoFile
            // 
            this.copytoFile.Cursor = System.Windows.Forms.Cursors.PanNorth;
            this.copytoFile.Font = new System.Drawing.Font("Segoe UI", 19F);
            this.copytoFile.Location = new System.Drawing.Point(15, 259);
            this.copytoFile.Name = "copytoFile";
            this.copytoFile.Size = new System.Drawing.Size(129, 97);
            this.copytoFile.TabIndex = 7;
            this.copytoFile.Tag = "";
            this.copytoFile.Text = "GÖNDER";
            this.copytoFile.UseVisualStyleBackColor = true;
            this.copytoFile.Click += new System.EventHandler(this.copytoFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(82, 167);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(198, 20);
            this.textBox_username.TabIndex = 0;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(82, 196);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(198, 20);
            this.textBox_password.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parola";
            // 
            // textBox_domain
            // 
            this.textBox_domain.Location = new System.Drawing.Point(82, 142);
            this.textBox_domain.Name = "textBox_domain";
            this.textBox_domain.Size = new System.Drawing.Size(198, 20);
            this.textBox_domain.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Domain";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(11, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1147, 248);
            this.label4.TabIndex = 8;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // label_durum
            // 
            this.label_durum.Location = new System.Drawing.Point(409, 49);
            this.label_durum.Name = "label_durum";
            this.label_durum.Size = new System.Drawing.Size(739, 63);
            this.label_durum.TabIndex = 9;
            this.label_durum.Text = "Durum: Bekleme";
            // 
            // textBox_content
            // 
            this.textBox_content.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_content.Location = new System.Drawing.Point(301, 118);
            this.textBox_content.Name = "textBox_content";
            this.textBox_content.Size = new System.Drawing.Size(847, 238);
            this.textBox_content.TabIndex = 9;
            this.textBox_content.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(854, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "SharePont Library";
            // 
            // textBox_library
            // 
            this.textBox_library.Location = new System.Drawing.Point(951, 20);
            this.textBox_library.Name = "textBox_library";
            this.textBox_library.Size = new System.Drawing.Size(197, 20);
            this.textBox_library.TabIndex = 3;
            // 
            // textBox_Domain_Url
            // 
            this.textBox_Domain_Url.Location = new System.Drawing.Point(85, 20);
            this.textBox_Domain_Url.Name = "textBox_Domain_Url";
            this.textBox_Domain_Url.Size = new System.Drawing.Size(733, 20);
            this.textBox_Domain_Url.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Domain Url";
            // 
            // textBox_clipboardfilesfolder
            // 
            this.textBox_clipboardfilesfolder.Location = new System.Drawing.Point(143, 49);
            this.textBox_clipboardfilesfolder.Name = "textBox_clipboardfilesfolder";
            this.textBox_clipboardfilesfolder.Size = new System.Drawing.Size(137, 20);
            this.textBox_clipboardfilesfolder.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Dosya Yükleme Klasörü";
            // 
            // textBox_clipboardTextFilename
            // 
            this.textBox_clipboardTextFilename.Location = new System.Drawing.Point(143, 72);
            this.textBox_clipboardTextFilename.Name = "textBox_clipboardTextFilename";
            this.textBox_clipboardTextFilename.Size = new System.Drawing.Size(137, 20);
            this.textBox_clipboardTextFilename.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Metin Dosyası Adı";
            // 
            // comboBox_UserType
            // 
            this.comboBox_UserType.FormattingEnabled = true;
            this.comboBox_UserType.Items.AddRange(new object[] {
            "Otomatik Windows Login Kullanıcısı",
            "Manuel Kullanıcı Adı - Şifre"});
            this.comboBox_UserType.Location = new System.Drawing.Point(82, 115);
            this.comboBox_UserType.Name = "comboBox_UserType";
            this.comboBox_UserType.Size = new System.Drawing.Size(198, 21);
            this.comboBox_UserType.TabIndex = 18;
            this.comboBox_UserType.Text = "Seçiniz";
            this.comboBox_UserType.SelectedIndexChanged += new System.EventHandler(this.comboBox_UserType_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Kullanıcı Tipi";
            // 
            // button_clearFolder
            // 
            this.button_clearFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_clearFolder.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.button_clearFolder.Location = new System.Drawing.Point(277, 47);
            this.button_clearFolder.Name = "button_clearFolder";
            this.button_clearFolder.Size = new System.Drawing.Size(82, 23);
            this.button_clearFolder.TabIndex = 20;
            this.button_clearFolder.Text = "Clear Folder";
            this.button_clearFolder.UseVisualStyleBackColor = true;
            this.button_clearFolder.Click += new System.EventHandler(this.button_clearFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 630);
            this.Controls.Add(this.button_clearFolder);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox_UserType);
            this.Controls.Add(this.textBox_clipboardfilesfolder);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_clipboardTextFilename);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_Domain_Url);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_content);
            this.Controls.Add(this.label_durum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_domain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_library);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.copytoFile);
            this.Controls.Add(this.CopyToClipboard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Sharepoint ile Pano (Clipboard) Arası Hızlı Veri Aktarım Uygulaması";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button CopyToClipboard;
        private Button copytoFile;
        private Label label1;
        private TextBox textBox_username;
        private TextBox textBox_password;
        private Label label2;
        private TextBox textBox_domain;
        private Label label3;
        private Label label4;
        private Label label_durum;
        private RichTextBox textBox_content;
        private Label label5;
        private TextBox textBox_library;
        private TextBox textBox_Domain_Url;
        private Label label6;
        private TextBox textBox_clipboardfilesfolder;
        private Label label7;
        private TextBox textBox_clipboardTextFilename;
        private Label label8;
        private ComboBox comboBox_UserType;
        private Label label9;
        private Button button_clearFolder;
    }
}