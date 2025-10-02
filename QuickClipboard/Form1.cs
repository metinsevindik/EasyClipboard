
using Microsoft.SharePoint.Client;
using System.Configuration;
using System.Net;
using System.Collections.Specialized;
using System.Security;
using System.Windows.Forms;
using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp1
{
    public partial class Form1 : System.Windows.Forms.Form
    {

        ClientContext context;
        String ServerPath_FilesFolder;
        String ServerPath_ClipboardFile;
        String ServerPath_RootFolder;

        [System.Obsolete]
        public Form1()
        {
            InitializeComponent();

            var Sharepoint_Domain_Url = ConfigurationSettings.AppSettings["Sharepoint_Domain_Url"];
            var Sharepoint_Library = ConfigurationSettings.AppSettings["Sharepoint_Library"];
            var Domain = ConfigurationSettings.AppSettings["Domain"];
            var Username = ConfigurationSettings.AppSettings["Username"];
            var Password = ConfigurationSettings.AppSettings["Password"];
            var FilesFolder = ConfigurationSettings.AppSettings["FilesFolder"];
            var ClipboardTextFilename = ConfigurationSettings.AppSettings["ClipboardTextFilename"];
            textBox_Domain_Url.Text = Sharepoint_Domain_Url != null ? Sharepoint_Domain_Url : "";
            textBox_library.Text = Sharepoint_Library != null ? Sharepoint_Library : "";
            textBox_clipboardfilesfolder.Text = FilesFolder != null ? FilesFolder : "";
            textBox_clipboardTextFilename.Text = ClipboardTextFilename != null ? ClipboardTextFilename : "";
            textBox_domain.Text = Domain != null ? Domain : "";
            textBox_username.Text = Username != null ? Username : "";
            textBox_password.Text = Password != null ? Password : "";

            ServerPath_RootFolder = textBox_Domain_Url.Text + "/" + textBox_library.Text;
            ServerPath_FilesFolder = textBox_Domain_Url.Text + "/" + textBox_library.Text + "/" + textBox_clipboardfilesfolder.Text;
            ServerPath_ClipboardFile = textBox_Domain_Url.Text + "/" + textBox_library.Text + "/" + textBox_clipboardTextFilename.Text;

            comboBox_UserType.SelectedIndex = 0;
        }
        private void copytoFile_Click(object sender, EventArgs e)
        {
            SendData();
        }
        private void CopyToClipboard_Click(object sender, EventArgs e)
        {
            GetData();
        }
        bool validation()
        {
            if (textBox_clipboardfilesfolder.Text == "")
            {
                MessageBox.Show("ClipboardFilesFolder boþ olamaz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_clipboardfilesfolder.Focus();
                return false;
            }
            label_durum.Text = "";
            if (comboBox_UserType.SelectedIndex == 0)
            {
                try
                {
                    context = new ClientContext(textBox_Domain_Url.Text)
                    {
                        Credentials = CredentialCache.DefaultNetworkCredentials
                    };
                    var web = context.Web;
                    context.Load(web, w => w.Title);
                    context.ExecuteQueryAsync().Wait();

                    label_durum.Text = "Baðlandýn: " + web.Title + "\nKullanýcý: " + System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Baðlanýlamadý !! \n" + textBox_Domain_Url.Text + " adresine kullanýcý adý þifre sormadan baðlanabildiðinizden emin olunuz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                var username = textBox_domain.Text + @"\" + textBox_username.Text;
                var password = textBox_password.Text;
                context = new ClientContext(textBox_Domain_Url.Text)
                {
                    Credentials = new NetworkCredential(username, password)
                };
            }
            var rootfolder = context.Web.GetFolderByServerRelativeUrl(ServerPath_RootFolder);
            try
            {
                context.Load(rootfolder);
                context.ExecuteQueryAsync().Wait();
            }
            catch (Exception)
            {
                MessageBox.Show("Veri aktarýlamadý !! \n" + textBox_Domain_Url.Text + "/" + textBox_library.Text + " adresini kontrol edin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            try
            {
                context.Load(rootfolder.Folders);
                context.ExecuteQueryAsync().Wait();
                bool exist = false;
                foreach (var folder in rootfolder.Folders)
                {
                    if (folder.Name == textBox_clipboardfilesfolder.Text)
                    {
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    rootfolder.AddSubFolder(textBox_clipboardfilesfolder.Text);
                    context.ExecuteQueryAsync().Wait();
                }
            }
            catch (Exception)
            {
                label_durum.Text = "Durum: Bir sorun oluþtu !!... Þu adresi kontrol edin: " + ServerPath_FilesFolder;
                return false;
            }
            return true;
        }

        void GetData()
        {
            textBox_content.Text = "";
            if (validation())
            {

                #region Copy Text from OneDrive
                try
                {
                    var file = context.Web.GetFileByUrl(ServerPath_ClipboardFile);
                    var streamResult = file.OpenBinaryStream();
                    context.ExecuteQueryAsync().Wait();
                    using (var mem = new MemoryStream())
                    {
                        streamResult.Value.CopyTo(mem);
                        string downloadedText = System.Text.Encoding.UTF8.GetString(mem.ToArray());
                        Clipboard.Clear();
                        Clipboard.SetText(downloadedText);
                        textBox_content.Text += downloadedText;
                        label_durum.Text = "Durum: Sharepoint OneDrive'daki metin Pano'ya kaydedildi. Þimdi saðtýk/Yapýþtýr kullanabilirsiniz.";
                    }
                }
                catch (Exception) { }
                #endregion

                #region Remove old temp files
                var fileDropList = new System.Collections.Specialized.StringCollection();
                var tempFolderPath = Path.Combine(Environment.CurrentDirectory, "tempfiles");
                Directory.CreateDirectory(tempFolderPath);
                foreach (var item in Directory.GetFiles(tempFolderPath))
                {
                    System.IO.File.Delete(item);
                }
                #endregion

                #region Copy Files from OneDrive
                try
                {
                    var folderItems = context.Web.GetFolderByServerRelativeUrl(ServerPath_FilesFolder).Files;
                    context.Load(folderItems);
                    context.ExecuteQueryAsync().Wait();
                    if (folderItems.Count > 0)
                    {
                        foreach (var f in folderItems)
                        {
                            var fileinfo = f.OpenBinaryStream();
                            context.ExecuteQueryAsync().Wait();
                            var filepath = Path.Combine(tempFolderPath, f.Name);
                            using (var fileStream = new FileStream(filepath, FileMode.Create))
                            {
                                if (fileinfo.Value != null)
                                {
                                    fileinfo.Value.CopyTo(fileStream);
                                }
                            }
                        }
                    }
                    fileDropList.AddRange(Directory.GetFiles(tempFolderPath));
                    if (fileDropList.Count > 0)
                    {
                        Clipboard.SetFileDropList(fileDropList);
                        System.Collections.Generic.List<string> ls = new List<string>();
                        foreach (var fileDropItem in fileDropList)
                        {
                            ls.Add(" * " + fileDropItem);
                        }
                        textBox_content.Text += "Þu Dosyalar yüklendi:\n" + string.Join("\n", ls);
                        label_durum.Text = "Durum: Sharepoint OneDrive'daki dosyalar Pano'ya kaydedildi. Þimdi saðtýk/Yapýþtýr kullanabilirsiniz.";
                    }
                }
                catch (Exception) { }

                #endregion
            }
        }
        void SendData()
        {
            if (validation())
            {
                #region Send Text to OneDrive
                if (Clipboard.ContainsText())
                {
                    string panoText = Clipboard.GetText();
                    byte[] fileContent = System.Text.Encoding.UTF8.GetBytes(panoText);

                    using (var ms = new MemoryStream(fileContent))
                    {
                        var rootFolder = context.Web.GetFolderByServerRelativeUrl(ServerPath_RootFolder);
                        context.Load(rootFolder);
                        context.ExecuteQueryAsync().Wait();

                        FileCreationInformation newFile = new FileCreationInformation
                        {
                            Url = textBox_clipboardTextFilename.Text,
                            Overwrite = true,
                            ContentStream = ms
                        };

                        var uploadFile = rootFolder.Files.Add(newFile);
                        context.Load(uploadFile);
                        context.ExecuteQueryAsync().Wait();
                        textBox_content.Text = panoText;
                        label_durum.Text = "Durum: Panodaki metin Sharepoint OneDrive'a kaydedildi.";

                    }
                    removeOldFiles();
                }
                #endregion

                #region Send Files To OneDrive
                if (Clipboard.ContainsFileDropList())
                {
                    removeOldFiles();
                    var filedroplist = Clipboard.GetFileDropList();
                    System.Collections.Generic.List<string> filelistStr = new List<string>();
                    foreach (var filePath in filedroplist)
                    {
                        try
                        {
                            uploadFileToSP(filePath);
                            filelistStr.Add(" * " + filePath.ToString());
                        }
                        catch (Exception e)
                        {
                            filelistStr.Add("!! HATA:" + filePath.ToString() + " dosyasýnda hata;" + e.Message);
                        }
                    }
                    textBox_content.Text = "Aþaðýdaki dosyalar þu adrese yüklendi:" + ServerPath_FilesFolder + " \n" + string.Join(",\n", filelistStr);
                    label_durum.Text = "Durum: Panodaki dosyalar Sharepoint OneDrive'a yüklendi.";

                }
                #endregion
            }
        }

        public void removeOldFiles()
        {
            var files = context.Web.GetFolderByServerRelativeUrl(ServerPath_FilesFolder).Files;
            context.Load(files);
            context.ExecuteQueryAsync().Wait();

            if (files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    var file = files[i];
                    file.DeleteObject();
                }
            }
            context.ExecuteQueryAsync().Wait();
        }

        public void uploadFileToSP(string filePath)
        {
            if (validation())
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    FileCreationInformation newfile = new FileCreationInformation
                    {
                        ContentStream = fs,
                        Url = Path.GetFileName(filePath),
                        Overwrite = true
                    };

                    Microsoft.SharePoint.Client.File uploadFile = context.Web.GetFolderByServerRelativeUrl(ServerPath_FilesFolder).Files.Add(newfile);
                    context.Load(uploadFile);
                    context.ExecuteQueryAsync().Wait();
                }
            }
        }

        private void comboBox_UserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox_username.Enabled = ((ComboBox)sender).SelectedIndex != 0;
            textBox_password.Enabled = ((ComboBox)sender).SelectedIndex != 0;
            textBox_domain.Enabled = ((ComboBox)sender).SelectedIndex != 0;
        }

        private void button_clearFolder_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                removeOldFiles();
                label_durum.Text = "Durum: Yükleme klasörü temizlendi";
                textBox_content.Text = "";
            }
        }
    }
}