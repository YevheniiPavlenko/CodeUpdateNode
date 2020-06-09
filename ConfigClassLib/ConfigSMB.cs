using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConfigClassLib
{
    public class ConfigSMB
    {
        /// <summary>
        /// В этой переменой храниться наименование файла XML с конфигурацией.
        /// </summary>
        string NameFileSMBConfigDefault = "ConfigSMB.xml";
        string ExceptionFileDelete = "Не возможно получить доступ к файлу и его удалить";

        /// <summary>
        /// Функция создание конфигурационного файла
        /// </summary>
        public void CreateConfigSMBXML()
        {
            XDocument xDocument = new XDocument();
            
            if (File.Exists(NameFileSMBConfigDefault)) { 
                try { 
                    File.Delete(NameFileSMBConfigDefault);
                }

                catch {
                    Console.WriteLine(ExceptionFileDelete);
                    return;
                }
            }

            xDocument.Declaration.Encoding = "UTF-8";
            xDocument.Declaration.Version = "1.0";
            xDocument.Save(NameFileSMBConfigDefault);
        }


    }
}
