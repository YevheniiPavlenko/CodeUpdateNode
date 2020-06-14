using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;
using ConfigWindowsFormsControlLib;

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
        /// Функция создания первоначатьного конфигурационного файла
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

        /// <summary>
        /// Функция для добавления заданий в конфигурационый файл, подразумеваеться что файл конфигурационый уже есть.
        /// </summary>
        /// <param name="CdirPatchInput">Путь к директории с которой нужно копировать файлы и каталоги</param>
        /// <param name="CdirPatchOutput">Путь к директори в которую переместяться файлы и каталоги</param>
        /// <param name="ISExDir">Проверка на существование директорий обоих директорий, при указании этого парамерта значением true
        /// будут проверяться каталоги, но а если не указать иль указать в значение false, то проверки не будет</param>
        public static void AddJobsForConfigSMBXML(string CdirPatchInput, string CdirPatchOutput, bool ISExDir = false)
        {
            if (!File.Exists(NameFileSMBConfigDefault))
            {
               return;
            }

            XDocument xEditDocument = new XDocument(); 
            //Обработка исключения при загрузке конфигурационного файла.
            try { xEditDocument = XDocument.Load(NameFileSMBConfigDefault); }
            catch {
                //При возникновении исключения загрузки xml, просто завершиться процедура. Такие исключения могут быть вызваны
                //тем, кто-то мог немного отредактировать сам конфигурационый файл и наруть его.
                return;
            }

            XElement xElementSMBConfig =  xEditDocument.Element("ConfigSMB");
            //Если на найдено выше указаного элемента, то происходит завершение процедуры.
            if (xElementSMBConfig == null) { return; }

            IEnumerable<XElement> xListXElements_JobsSMB =  xElementSMBConfig.XPathSelectElements("JobsSMB");
            int cMaxValueIIN_JobsSMB = 0;
            if (xListXElements_JobsSMB.Select(x => x.Attribute("Id").Value).Count() != 0)
            {
                cMaxValueIIN_JobsSMB = xListXElements_JobsSMB.Max(x => Convert.ToInt32(x.Attribute("Id").Value)) + 1;
            }
            
            XElement xElementPatch = new XElement("JobsSMB");
            xElementPatch.Add(new XAttribute("Id", cMaxValueIIN_JobsSMB));
            if (!Directory.Exists(CdirPatchInput) | !Directory.Exists(CdirPatchOutput) | ISExDir == true) { return; }
            xElementPatch.Add(new XAttribute("dirPatchInput", CdirPatchInput));
            xElementPatch.Add(new XAttribute("dirPatchOutput", CdirPatchOutput));
            xElementSMBConfig.Add(xElementPatch);

            xEditDocument.Save(NameFileSMBConfigDefault);
        }

        /// <summary>
        /// Запись значений из списка PropertyXElementJob 
        /// </summary>
        /// <param name="xpropertyXElementJobsTempate">Списка PropertyXElementJob</param>
        /// <param name="ISExDir">Проверка на существование директорий обоих директорий, при указании этого парамерта значением true
        /// будут проверяться каталоги, но а если не указать иль указать в значение false, то проверки не будет</param>
        public static void AddJobsForConfigSMBXML_forPropertyXElementJob(List<PropertyXElementJob> xpropertyXElementJobsTempate, bool ISExDir = false)
        {
            if (!File.Exists(NameFileSMBConfigDefault))
            {
                return;
            }

            XDocument ReCreateDocument = new XDocument();
            //Обработка исключения при загрузке конфигурационного файла.
            try { ReCreateDocument = XDocument.Load(NameFileSMBConfigDefault); }
            catch
            {
                //При возникновении исключения загрузки xml, просто завершиться процедура. Такие исключения могут быть вызваны
                //тем, кто-то мог немного отредактировать сам конфигурационый файл и наруть его.
                return;
            }

            XElement xElementSMBConfig = ReCreateDocument.Element("ConfigSMB");
            //Если на найдено выше указаного элемента, то происходит завершение процедуры.
            if (xElementSMBConfig == null) { return; }

            IEnumerable<XElement> xListXElements_JobsSMB = xElementSMBConfig.XPathSelectElements("JobsSMB");
            int cMaxValueIIN_JobsSMB = 0;
            if (xListXElements_JobsSMB.Select(x => x.Attribute("Id").Value).Count() != 0)
            {
                cMaxValueIIN_JobsSMB = xListXElements_JobsSMB.Max(x => Convert.ToInt32(x.Attribute("Id").Value)) + 1;
            }

            XElement xElementPatch = new XElement("JobsSMB");

            foreach (PropertyXElementJob txpropertyXElementJobTemp in xpropertyXElementJobsTempate)
            {
                xElementPatch.Add(new XAttribute("Id", cMaxValueIIN_JobsSMB));
                xElementPatch.Add(new XAttribute("dirPatchInput",txpropertyXElementJobTemp._DirInput));
                xElementPatch.Add(new XAttribute("dirPatchOutput", txpropertyXElementJobTemp._DirOutput));

                if (ISExDir == true)
                {
                    if (Directory.Exists(txpropertyXElementJobTemp._DirInput) & Directory.Exists(txpropertyXElementJobTemp._DirOutput)) {
                        cMaxValueIIN_JobsSMB++;
                        xElementSMBConfig.Add(xElementPatch);
                    }
                }
                
            }
            
            ReCreateDocument.Save(NameFileSMBConfigDefault);
        }

        /// <summary>
        /// Удаление конкретного задания из конфигурауции
        /// </summary>
        /// <param name="IdJObsForConfig">передаеться номер задания которое нужно удалить</param>
        /// <param name="IsRepackConfig">Указывает нужно ли перепаковывать конфиг. По умольчанию иль при не указанию 
        /// его, конфиг иперепаковываеться.</param>
        public static void RemoveJobsForConfigSMBXML(int IdJObsForConfig, bool IsRepackConfig = true)
        {
            if (!File.Exists(NameFileSMBConfigDefault))
            {
                return;
            }

            XDocument xRemoveDocument = new XDocument();
            try { xRemoveDocument = XDocument.Load(NameFileSMBConfigDefault); }
            catch
            {
                //При возникновении исключения загрузки xml, просто завершиться процедура. Такие исключения могут быть вызваны
                //тем, кто-то мог немного отредактировать сам конфигурационый файл и наруть его.
                return;
            }

            XElement xElementSMBConfig = xRemoveDocument.Element("ConfigSMB");
            //Если на найдено выше указаного элемента, то происходит завершение процедуры.
            if (xElementSMBConfig == null) { return; }

            IEnumerable<XElement> xListXElements_JobsSMB = xElementSMBConfig.XPathSelectElements("//JobsSMB[@Id="+ IdJObsForConfig.ToString() +"]");
            //Если список пустой то и процедура далее не продолжаеться.
            if (xListXElements_JobsSMB == null) { return;  }
            foreach(XElement xElementForListSearch in xListXElements_JobsSMB)
            {
                xElementForListSearch.Remove();
            }

            xRemoveDocument.Save(NameFileSMBConfigDefault);

            //Если IsRepackConfig == true, то конфиг перепаковываеться
            if (IsRepackConfig == true) { RepackJobsForConfigSMBXML(); }
            
        }

        /// <summary>
        /// Удаление списка номеров заданий из конфигурауции
        /// </summary>
        /// <param name="IdJobsForConfig">Список заданий в виде порядкового индекса заданий</param>
        /// <param name="IsRepackConfig">Указывает нужно ли перепаковывать конфиг. По умольчанию иль при не указанию 
        /// его, конфиг иперепаковываеться.</param>
        public static void RemoveListJobsForConfigSMBXML(List<int> IdJobsForConfig, bool IsRepackConfig = true)
        {
            if (IdJobsForConfig != null) { 
                if (IdJobsForConfig.Count > 0)
                {
                    for (int xI = 0; xI <= IdJobsForConfig.Count - 1; xI++)
                    {
                        RemoveJobsForConfigSMBXML(IdJobsForConfig[xI], false);
                    }

                    if (IsRepackConfig == true) { RepackJobsForConfigSMBXML(); }
                }
            }
        }
        
        /// <summary>
        /// Удаление всех заданий
        /// </summary>
        public static void RemoveAllJobsForConfigSMBXML()
        {
            if (!File.Exists(NameFileSMBConfigDefault))
            {
                return;
            }

            XDocument xRemoveAllDocument = new XDocument();
            try { xRemoveAllDocument = XDocument.Load(NameFileSMBConfigDefault); }
            catch
            {
                //При возникновении исключения загрузки xml, просто завершиться процедура. Такие исключения могут быть вызваны
                //тем, кто-то мог немного отредактировать сам конфигурационый файл и наруть его.
                return;
            }

            XElement xElementSMBConfig = xRemoveAllDocument.Element("ConfigSMB");
            //Если на найдено выше указаного элемента, то происходит завершение процедуры.
            if (xElementSMBConfig == null) { return; }

            IEnumerable<XElement> xListXElements_JobsSMB = xElementSMBConfig.XPathSelectElements("JobsSMB");
            //Если список пустой то и процедура далее не продолжаеться.
            if (xListXElements_JobsSMB == null) { return; }
            xListXElements_JobsSMB.Remove();
            //foreach (XElement xElementForListSearch in xListXElements_JobsSMB)
            //{
            //    xElementForListSearch.Remove();
            //}

            xRemoveAllDocument.Save(NameFileSMBConfigDefault);
        }

        /// <summary>
        /// Данная процедура нужна для перепаковки, то есть пересортировки по порядку списка списка заданий в конфигурации.
        /// Эта процедра свойством private огринаичивает видимость ее. Она видна только в самом класе.
        /// </summary>
        private static void RepackJobsForConfigSMBXML()
        {
            if (!File.Exists(NameFileSMBConfigDefault))
            {
                return;
            }

            XDocument xRepackDocument = new XDocument();
            try { xRepackDocument = XDocument.Load(NameFileSMBConfigDefault); }
            catch
            {
                //При возникновении исключения загрузки xml, просто завершиться процедура. Такие исключения могут быть вызваны
                //тем, кто-то мог немного отредактировать сам конфигурационый файл и наруть его.
                return;
            }

            XElement xElementSMBConfig = xRepackDocument.Element("ConfigSMB");
            //Если на найдено выше указаного элемента, то происходит завершение процедуры.
            if (xElementSMBConfig == null) { return; }

            IEnumerable<XElement> xListXElements_JobsSMB = xElementSMBConfig.XPathSelectElements("JobsSMB").OrderBy(x => x.Attribute("Id").Value);
            if (xListXElements_JobsSMB == null) { return; }

            int NumForList = 0;

            foreach(XElement xElement in xListXElements_JobsSMB)
            {
                if((int)(xElement.Attribute("Id")) != NumForList)
                {
                    xElement.Attribute("Id").Value = NumForList.ToString();
                }
                NumForList++;
            }

            xRepackDocument.Save(NameFileSMBConfigDefault);
        }

        /// <summary>
        /// Функция возвращает параметры по заднию, для каждого Id
        /// </summary>
        /// <param name="tNumJobsForConfig">Номер задания Id</param>
        /// <returns>Вернет задания Id в виде ProprtyXElementJob</returns>
        public static PropertyXElementJob getInfo_XElementJobForList(int tIdJobsForConfig)
        {
            //PropertyXElementJob xProprtyXElementJob = new PropertyXElementJob(-1, "", "");
            PropertyXElementJob xProprtyXElementJob = new PropertyXElementJob();

            if (!File.Exists(NameFileSMBConfigDefault))
            {
                return xProprtyXElementJob;
            }

            XDocument xReadDocument = new XDocument();
            try { xReadDocument = XDocument.Load(NameFileSMBConfigDefault); }
            catch
            {
                //При возникновении исключения загрузки xml, просто завершиться процедура. Такие исключения могут быть вызваны
                //тем, кто-то мог немного отредактировать сам конфигурационый файл и наруть его.
                return xProprtyXElementJob;
            }

            XElement xElementSMBConfig = xReadDocument.Element("ConfigSMB");
            //Если на найдено выше указаного элемента, то происходит завершение процедуры.
            if (xElementSMBConfig == null) { return xProprtyXElementJob; }

            IEnumerable<XElement> xListXElements_JobsSMB = xElementSMBConfig.XPathSelectElements("JobsSMB").Where(x => x.Attribute("Id").Value.Equals(tIdJobsForConfig.ToString()));
            if (xListXElements_JobsSMB == null) { return xProprtyXElementJob; }

            XElement xElement = xListXElements_JobsSMB.First();
            xProprtyXElementJob.Set(Convert.ToInt32(xElement.Attribute("Id").Value), xElement.Attribute("dirPatchInput").Value, xElement.Attribute("dirPatchOutput").Value);

            return xProprtyXElementJob;
        }

        /// <summary>
        /// Функция возвращает параметры по всем заданиям
        /// </summary>
        /// <returns>Вернет список всех заданий в виде List<ProprtyXElementJob></returns>
        public static List<PropertyXElementJob> getInfo_XElemetJobForListAll()
        {
            List<PropertyXElementJob> xProprtyXElementJobAll;

            if (!File.Exists(NameFileSMBConfigDefault))
            {
                return null;
            }

            XDocument xReadDocument = new XDocument();
            try { xReadDocument = XDocument.Load(NameFileSMBConfigDefault); }
            catch
            {
                //При возникновении исключения загрузки xml, просто завершиться процедура. Такие исключения могут быть вызваны
                //тем, кто-то мог немного отредактировать сам конфигурационый файл и наруть его.
                return null;
            }

            XElement xElementSMBConfig = xReadDocument.Element("ConfigSMB");
            //Если на найдено выше указаного элемента, то происходит завершение процедуры.
            if (xElementSMBConfig == null) { return null; }

            IEnumerable<XElement> xListXElements_JobsSMB = xElementSMBConfig.XPathSelectElements("JobsSMB");
            if (xListXElements_JobsSMB == null) { return null; }

            //XElement xElement = xListXElements_JobsSMB.First();
            //xProprtyXElementJobAll.Set(Convert.ToInt32(xElement.Attribute("Id").Value), xElement.Attribute("dirPatchInput").Value, xElement.Attribute("dirPatchOutput").Value);

            xProprtyXElementJobAll = new List<PropertyXElementJob>();

            PropertyXElementJob propertyXElementJobTemplate;
            foreach (XElement xElementTemplate in xListXElements_JobsSMB)
            {
                propertyXElementJobTemplate = new PropertyXElementJob();
                propertyXElementJobTemplate.Set(Convert.ToInt32(xElementTemplate.Attribute("Id").Value),
                    xElementTemplate.Attribute("dirPatchInput").Value, xElementTemplate.Attribute("dirPatchOutput").Value);
                xProprtyXElementJobAll.Add(propertyXElementJobTemplate);
            }

            return xProprtyXElementJobAll;
        }
    }
}