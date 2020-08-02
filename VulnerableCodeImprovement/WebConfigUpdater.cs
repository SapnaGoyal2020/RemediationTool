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

                #region validateRequest
                // Update Element value  
                var items = from item in xmlDoc.Descendants("pages")
                            where item.Attribute("validateRequest").Value == "false"
                            select item;

                foreach (XElement itemElement in items)
                {
                    itemElement.SetAttributeValue("validateRequest", "true");
                }
                #endregion

                #region compilation
                // Update Element value  
                var items_compilation = from item in xmlDoc.Descendants("compilation")
                           // where item.Attribute("debug").Value == "true"
                            select item;
                if (items_compilation != null && items_compilation.Count() > 0)
                {
                    foreach (XElement itemElement in items_compilation)
                    {
                        itemElement.SetAttributeValue("debug","false");
                    }
                }
                else
                {
                    // Option2: Using Add() method 
                   // XDocument doc = XDocument.Parse(tempXml);
                    XElement root = new XElement("compilation");
                    root.Add(new XAttribute("debug", "false"));
                    root.Add(new XAttribute("targetFramework", "4.5"));
                    xmlDoc.Element("configuration").Element("system.web").Add(root);
                    //doc.Save(Console.Out);

                }

                #endregion

                #region requireSSL
                // Update Element value  
                var items_httpCookies = from item in xmlDoc.Descendants("httpCookies")
                                            // where item.Attribute("debug").Value == "true"
                                        select item;
                if (items_httpCookies != null && items_httpCookies.Count() > 0)
                {
                    foreach (XElement itemElement in items_httpCookies)
                    {
                        itemElement.SetAttributeValue("requireSSL", "true");
                    }
                }
                else
                {
                    // Option2: Using Add() method 
                    // XDocument doc = XDocument.Parse(tempXml);
                    XElement root = new XElement("httpCookies");
                    root.Add(new XAttribute("requireSSL", "true"));
                    root.Add(new XAttribute("httpOnlyCookies", "true"));
                    xmlDoc.Element("configuration").Element("system.web").Add(root);
                    //doc.Save(Console.Out);

                }

                #endregion

                #region httpProtocol-Strict-Transport-Security
                // Update Element value  
                var items_httpProtocol_hsts = from item in xmlDoc.Descendants("httpProtocol")
                                            // where item.Attribute("debug").Value == "true"
                                        select item;
                if (items_httpProtocol_hsts != null && items_httpProtocol_hsts.Count() > 0)
                {
                    foreach (XElement itemElement in items_httpCookies)
                    {
                        itemElement.SetAttributeValue("requireSSL", "true");
                    }
                }
                else
                {
                    // Option2: Using Add() method 
                    // XDocument doc = XDocument.Parse(tempXml);
                    XElement root = new XElement("add");
                    XElement parent_root = new XElement("httpProtocol", new XElement("customHeaders", root));
                   
                    
                   root.Add(new XAttribute("name", "Strict-Transport-Security"));
                    root.Add(new XAttribute("value", "max-age=31536000"));
                    xmlDoc.Element("configuration").Element("system.webServer").Add(parent_root);
                    //doc.Save(Console.Out);

                }

                #endregion

                #region traceenabled 
                // Update Element value  
                var items_traceenabled = from item in xmlDoc.Descendants("trace")
                                            // where item.Attribute("debug").Value == "true"
                                        select item;
                if (items_traceenabled != null && items_traceenabled.Count() > 0)
                {
                    foreach (XElement itemElement in items_traceenabled)
                    {
                        itemElement.SetAttributeValue("enabled", "false");
                    }
                }
                else
                {
                    // Option2: Using Add() method 
                    // XDocument doc = XDocument.Parse(tempXml);
                    XElement root = new XElement("trace");
                    root.Add(new XAttribute("enabled", "false"));
                    root.Add(new XAttribute("localOnly", "true"));
                    xmlDoc.Element("configuration").Element("system.web").Add(root);
                    //doc.Save(Console.Out);

                }

                #endregion

                #region sessionState 
                // Update Element value  
                var items_sessionState = from item in xmlDoc.Descendants("sessionState")
                                             // where item.Attribute("debug").Value == "true"
                                         select item;
                if (items_sessionState != null && items_sessionState.Count() > 0)
                {
                    foreach (XElement itemElement in items_sessionState)
                    {
                        itemElement.SetAttributeValue("cookieless", "UseCookies");
                    }
                }
                else
                {
                    // Option2: Using Add() method 
                   
                    XElement root = new XElement("sessionState");
                    root.Add(new XAttribute("cookieless", "UseCookies"));
                    xmlDoc.Element("configuration").Element("system.web").Add(root);
                    //doc.Save(Console.Out);

                }

                #endregion

                #region customErrors 
                // Update Element value  
                var items_customErrors = from item in xmlDoc.Descendants("customErrors")
                                             // where item.Attribute("debug").Value == "true"
                                         select item;
                if (items_customErrors != null && items_customErrors.Count() > 0)
                {
                    foreach (XElement itemElement in items_customErrors)
                    {
                        itemElement.SetAttributeValue("mode", "RemoteOnly");
                    }
                }
                else
                {
                    // Option2: Using Add() method 
                    // XDocument doc = XDocument.Parse(tempXml);
                    XElement root = new XElement("customErrors");
                    root.Add(new XAttribute("mode", "RemoteOnly"));
                    root.Add(new XAttribute("defaultRedirect", "YourErrorPage.htm"));
                    xmlDoc.Element("configuration").Element("system.web").Add(root);
                    //doc.Save(Console.Out);

                }

                #endregion

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
