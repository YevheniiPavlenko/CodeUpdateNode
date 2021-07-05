using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.IO;
using System.Xml;

namespace Lib_GetUriDonload
{
    public class Lib_Config
    {
        /// <summary>
        /// Initial Application Configuration List
        /// </summary>
        /// <returns>
        /// An initial list of application configuration, or rather a list of servers from which to download ESET updates
        /// </returns>
        static public string StatusServerFromListConfig()
        {
            Uri xServer0 = new Uri(readPatchXMLConfig("Patch_DFiles"));
            Uri xServer1 = new Uri(readPatchXMLConfig("Patch_DFilesOld"));

            bool xServerResult = false;
            try
            {
                HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create(xServer0.ToString());

                HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
                if (HttpStatusCode.OK == rspFP.StatusCode)
                {
                    // Connect is OK
                    rspFP.Close();
                    xServerResult = true;
                }
                else
                {
                    // Error
                    rspFP.Close();
                    xServerResult = false;
                }
            }
            catch (WebException)
            {
                //Error connect
                xServerResult = false;
            }

            bool xServerResult1 = false;

            if (xServerResult == false)
            {
                try
                {
                    HttpWebRequest reqFP = (HttpWebRequest)HttpWebRequest.Create(xServer1.ToString());

                    HttpWebResponse rspFP = (HttpWebResponse)reqFP.GetResponse();
                    if (HttpStatusCode.OK == rspFP.StatusCode)
                    {
                        // Connect is OK
                        rspFP.Close();
                        xServerResult1 = true;
                    }
                    else
                    {
                        // Error
                        rspFP.Close();
                        xServerResult1 = false;
                    }
                }
                catch (WebException)
                {
                    //Error connect
                    xServerResult1 = false;
                }

            }

            if (xServerResult != false)
            {
                return xServer0.ToString();
            }
            else if (xServerResult1 != false)
            {
                return xServer1.ToString();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Reading the default configuration
        /// </summary>
        /// <returns>
        /// Reading the default configuration, without specifying the path where the configuration file is located.
        /// </returns>
        static public string readPatchXMLConfig()
        {
            string resURi = "";

            if (File.Exists("Config.xml"))
            {
                XmlDocument xxmlDataDocument = new XmlDocument();
                xxmlDataDocument.Load("Config.xml");

                foreach (XmlNode xXmlNode in xxmlDataDocument.SelectNodes("/DataPatch"))
                {
                    resURi = xXmlNode.SelectSingleNode("Patch_DFiles").InnerText;
                    //Console.WriteLine("Uri: {0}", resURi);
                }
                return resURi;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tXmlNode"></param>
        /// <returns></returns>
        static public string readPatchXMLConfig(string tXmlNode)
        {
            string resURi = "";

            if (File.Exists("Config.xml"))
            {
                XmlDocument xxmlDataDocument = new XmlDocument();
                xxmlDataDocument.Load("Config.xml");

                foreach (XmlNode xXmlNode in xxmlDataDocument.SelectNodes("/DataPatch"))
                {
                    resURi = xXmlNode.SelectSingleNode(tXmlNode).InnerText;
                    //Console.WriteLine("Uri: {0}", resURi);
                }
                return resURi;
            }
            else
            {
                return null;
            }
        }

        static public string[] findAllLink(Uri x_uri, bool downloadAll = false)
        {
            WebClient x_wc;
            string[] tresDownNup;
            string[] resDownNup;
            int resCount = 0;
            int resNUP_Ver = 0;
            int resVer_Count = 0;
            string tres;

            x_wc = new WebClient();
            HtmlDocument xDoc = new HtmlDocument();
            xDoc.Load(x_wc.OpenRead(x_uri));
            tresDownNup = new string[xDoc.DocumentNode.SelectNodes("//a[@href]").Count];

            //This Block find All tag from exists links
            foreach (HtmlNode a in xDoc.DocumentNode.SelectNodes("//a[@href]"))
            {
                tresDownNup[resCount] = x_uri.ToString() + a.Attributes["href"].Value;
                resCount++;

                tres = (tresDownNup[resCount - 1].Split('.')[tresDownNup[resCount - 1].Split('.').Length - 1]).ToUpper();
                if ((tres == ("nup").ToUpper()) || (tres == ("ver").ToUpper()))
                {
                    resNUP_Ver++;
                    //Console.WriteLine(tres);
                    if (tres == ("ver").ToUpper()) { resVer_Count++; }
                }
            }

            if (((resNUP_Ver > 0) && (resVer_Count > 0)) || (downloadAll = true))
            {
                resDownNup = new string[resNUP_Ver];
                int tmpX = 0;

                for (int x = 0; x < tresDownNup.Length; x++)
                {
                    tres = (tresDownNup[x].Split('.')[tresDownNup[x].Split('.').Length - 1]).ToUpper();
                    tres = tres.Split('/')[tres.Split('/').Length - 1].ToUpper();

                    if ((tres == ("nup").ToUpper()) || (tres == ("ver").ToUpper()))
                    {
                        resDownNup[tmpX] = tresDownNup[x];
                        tmpX++;
                    }
                }

                return resDownNup;
            }
            else
            {
                return null;
            }
        }

    }
}
