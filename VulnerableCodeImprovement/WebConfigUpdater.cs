using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace VulnerableCodeImprovement
{
    public partial class WebConfigUpdater : Form
    {
        public WebConfigUpdater()
        {
            InitializeComponent();
        }
        public static string filePath = string.Empty; 
        private void btn_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            filePath= folderDlg.SelectedPath;
            if (result == DialogResult.OK)
            {
                txt_Browse.Text = folderDlg.SelectedPath;
                string[] allfiles = Directory.GetFiles(folderDlg.SelectedPath, "web.config", SearchOption.AllDirectories);
                if (allfiles != null && allfiles.Count() == 0)
                {
                    MessageBox.Show("Please select folder path to select *.config files.");
                    txt_Browse.Text =string.Empty;
                }
                else
                {
                    foreach (var objfilepath in allfiles)
                    {
                        string[] arr = new string[2];
                        ListViewItem itm;
                        //add items to ListView
                        arr[0] = Path.GetFileName(objfilepath);
                        arr[1] =Path.GetFullPath(objfilepath);

                        itm = new ListViewItem(arr);
                        listView_Browse.Items.Add(itm);
                    }
                    btn_Process.Visible = true;
                }
            }

          
        }

        private void btn_Process_Click(object sender, EventArgs e)
        {
            string[] allfiles = Directory.GetFiles(filePath, "web.config", SearchOption.AllDirectories);
            int totalcount = allfiles.Count();
            int i = 1;
            foreach (var objfilepath in allfiles)
            {
                // Option1: Using SetAttributeValue()
                XDocument xmlDoc = XDocument.Load(objfilepath);
                // Update Element value  
                var items = from item in xmlDoc.Descendants("pages")
                            where item.Attribute("validateRequest").Value == "false"
                            select item;

                foreach (XElement itemElement in items)
                {
                    itemElement.SetAttributeValue("validateRequest", "true");
                }

                xmlDoc.Save(objfilepath);
                webConfigProgressBar.Minimum = 0;
                webConfigProgressBar.Maximum = totalcount;
                webConfigProgressBar.Value = i++;
            }
            MessageBox.Show("The WebConfig has been updated successfully.");
            lbl_message.Text = "The WebConfig has been updated successfully.";
            lbl_message.Visible = true;
        }
    }
}
