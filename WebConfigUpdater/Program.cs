using System;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Xml.Linq;

namespace WebConfigUpdater
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allfiles = Directory.GetFiles(ConfigurationManager.AppSettings["rootApplicationPath"], "web.config", SearchOption.AllDirectories);

           foreach(var objfilepath in allfiles)
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
                Console.WriteLine("The WebConfig has been updated successfully.");
            }
        }
    }
}
