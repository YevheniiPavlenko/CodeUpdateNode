using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;

namespace ConfigClassLib
{
    public class ConfigSMB
    {
        /// <summary>
        /// В этой переменой храниться наименование файла XML с конфигурацией.
        /// </summary>
        static string NameFileSMBConfigDefault = "ConfigSMB.xml";
        static string ExceptionFileDelete = "Не возможно получить доступ к файлу и его удалить";

        /// <summary>
        /// Функция создание конфигурационного файла
        /// </summary>
        public static void CreateConfigSMBXML()
        {
            XDocument xCreateDocument = new XDocument();
            
            if (File.Exists(NameFileSMBConfigDefault)) { 
                try { 
                    File.Delete(NameFileSMBConfigDefault);
                }

                catch {
                    Console.WriteLine(ExceptionFileDelete);
                    return;
                }
            }

            xCreateDocument.Declaration = new XDeclaration("1.0", "utf-8", null);
            xCreateDocument.Add(new XComment("Block for copying jobs"));
            xCreateDocument.Add(new XComment("--------------------------------------------"));
            XElement xElementSMBConfig = new XElement("ConfigSMB");
            xCreateDocument.Add(xElementSMBConfig);
            xCreateDocument.Save(NameFileSMBConfigDefault);

            xCreateDocument = null;
        }

        public static void AddJobsForConfigSMBXML(string CdirPatchInput, string CdirPatchOutput)
        {
            if (!File.Exists(NameFileSMBConfigDefault))
            {
               return;
            }

            XDocument xEditDocument = new XDocument();
            xEditDocument = XDocument.Load(NameFileSMBConfigDefault);
            XElement xElementSMBConfig =  xEditDocument.Element("ConfigSMB");
            

            IEnumerable<XElement> xListXElements_JobsSMB =  xElementSMBConfig.XPathSelectElements("JobsSMB");
            int cMaxValueIIN_JobsSMB = xListXElements_JobsSMB.Max(x => Convert.ToInt32(x.Attribute("Id").Value));
            //IEnumerable<char> xMaxValueIIN_JobsSMB =
            //    from ValueINN in xListXElements_JobsSMB
            //    select ValueINN.Attribute("Id").Value.Max();
            //int cMaxValueIIN_JobsSMB = xMaxValueIIN_JobsSMB.Select(Max());

            if (xListXElements_JobsSMB.Count() > 0)
            {
                XElement xElementPatch = new XElement("JobsSMB");
                XAttribute xAtributeId = new XAttribute("Id", cMaxValueIIN_JobsSMB++);
                //xElementPatch.Add();
                xElementPatch.Add(new XAttribute("dirPatchInput", CdirPatchInput));
                xElementPatch.Add(new XAttribute("dirPatchOutput", CdirPatchOutput));
            }

            xEditDocument.Add(xElementSMBConfig);
            xEditDocument.Save(NameFileSMBConfigDefault);
        }

    }
}
