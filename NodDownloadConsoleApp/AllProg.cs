using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Net;

namespace NodDownloadConsoleApp
{
    class AllProg
    {
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
            else if (xServerResult1 !=  false)
            {
                return xServer1.ToString();
            } else
            {
                return null;
            }
        }

        static public string readPatchXMLConfig()
        {
            string resURi = "";

            if(File.Exists("Config.xml")){
                XmlDocument xxmlDataDocument = new XmlDocument();
                xxmlDataDocument.Load("Config.xml");

                foreach (XmlNode xXmlNode in xxmlDataDocument.SelectNodes("/DataPatch"))
                {
                    resURi = xXmlNode.SelectSingleNode("Patch_DFiles").InnerText;
                    //Console.WriteLine("Uri: {0}", resURi);
                }
                return resURi;
            } else
            {
                return null;
            }
        }

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

    }
}
