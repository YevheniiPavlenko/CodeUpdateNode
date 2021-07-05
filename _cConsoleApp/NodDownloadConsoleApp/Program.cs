using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.IO;
using System.Net;
//using HtmlAgilityPack;
using Lib_GetUriDonload;

namespace NodDownloadConsoleApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    //Application.EnableVisualStyles();
        //    //Application.SetCompatibleTextRenderingDefault(false);
        //    //Application.Run(new Form1());
        //}
        static WebClient wc;
        static string[] resultParserUri;
        //static string[] tresDownNup;
        //static string[] resDownNup;

        //-----------------------------------------------------------------------
        //Default param
        //-----------------------------------------------------------------------
        //static Uri xUri = new Uri(@"http://nod.gorod.nu/eset_upd/");
        static Uri xUri = new Uri(@"http://nod.gorod.nu/eset_upd/");
        static string xPatch = AppDomain.CurrentDomain.BaseDirectory + @"New";
        //-----------------------------------------------------------------------

        

        static void Main(string[] args)
        {
            //string RxUri = AllProg.readPatchXMLConfig();--delete
            //string RxUri = AllProg.StatusServerFromListConfig();
            string RxUri = Lib_Config.StatusServerFromListConfig();

            if (RxUri != null)
            { 
                xUri = new Uri(RxUri);
            }


            string xtOpenUri = "no";

            Console.WriteLine($"Запуск парсина Uri({xUri.ToString()}) сервера обновлений Nod...");
            Console.WriteLine("");
            
            if (args.Length != 0)
            {
                if (args[0] == "-r") {

                    for (int xI = 1; xI <= args.Length-1; xI++)
                    {
                        if (args[xI] == "-l") { xtOpenUri = "yes"; }
                    }
                    
                    OpenUrl(xtOpenUri);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Error parameters is this program"); Console.ResetColor();
                Console.WriteLine("\nПри запуске используються следующие параметры:");
                Console.WriteLine("-r - запустить программу на выполнение.");
                Console.WriteLine("-l - отображать список файлов полученых с Uri для скачивания.");
            }
        }

        //Предназначена для чтения и загрузки всех файлов *.NUP и *.VER с доступного Web ресурса
        static void OpenUrl(string xWriteConsoleText)
        {
            //int resCount = 0;
            //int resNUP_Ver = 0;
            //int resVer_Count = 0;
            //string tres;

            wc = new WebClient();
            //HtmlDocument xDoc = new HtmlDocument();
            //xDoc.Load(wc.OpenRead(xUri));
            //tresDownNup = new string[xDoc.DocumentNode.SelectNodes("//a[@href]").Count];

            ////This Block find All tag from exists links
            //foreach (HtmlNode a in xDoc.DocumentNode.SelectNodes("//a[@href]"))
            //{
            //    tresDownNup[resCount] = xUri.ToString() + a.Attributes["href"].Value;
            //    resCount++;

            //    tres = (tresDownNup[resCount - 1].Split('.')[tresDownNup[resCount - 1].Split('.').Length - 1]).ToUpper();
            //    if ((tres == ("nup").ToUpper()) || (tres == ("ver").ToUpper()))
            //    {
            //        resNUP_Ver++;
            //        //Console.WriteLine(tres);
            //        if (tres == ("ver").ToUpper()) { resVer_Count++; }
            //    }
            //}

            //resultParserUri = AllProg.findAllLink(xUri, true);
            resultParserUri = Lib_Config.findAllLink(xUri, true);

            //This Block find from top data, wish generate left Block, data what == ".NUM " Or  == ".VER"
            if (resultParserUri != null)
            {
                //resDownNup = new string[resNUP_Ver];
                //int tmpX = 0;

                //for (int x = 0; x < tresDownNup.Length; x++)
                //{
                //    tres = (tresDownNup[x].Split('.')[tresDownNup[x].Split('.').Length - 1]).ToUpper();
                //    tres = tres.Split('/')[tres.Split('/').Length - 1].ToUpper();

                //    if ((tres == ("nup").ToUpper()) || (tres == ("ver").ToUpper()))
                //    {
                //        resDownNup[tmpX] = tresDownNup[x];
                //        tmpX++;
                //    }
                //}

                //Print for screen list downloade file signature
                // for (int x = 0; x < resDownNup.Length; x++)
                //{
                //    Console.WriteLine((x+1).ToString() + "\t" + resDownNup[x]);
                //}

                if (xWriteConsoleText == "yes")
                {
                    Console.WriteLine($"Сформировано список из {resultParserUri.Length.ToString()} файлов...");
                }

                //--------------------------------------------------------------------------------------------
                //Create Directory from Downloade file signature for last ago...
                //--------------------------------------------------------------------------------------------
                bool IsCreateDirectory = true;

                //Downloads file from exists dyrectory
                if (!Directory.Exists(xPatch))
                {
                    try
                    {
                        Directory.CreateDirectory(xPatch);
                    }
                    //Указанный каталог path является файлом. Имя сети неизвестно.
                    catch (IOException)
                    {
                        if (xWriteConsoleText == "yes")
                        {
                            Console.WriteLine("Create Directory is a file or networks name is not exist.");
                        }
                        IsCreateDirectory = false;
                        return;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        IsCreateDirectory = false;
                    }
                }

                if (xWriteConsoleText == "yes")
                {
                    if (IsCreateDirectory == true) { Console.WriteLine($"Директория {xPatch} создана"); }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Ошибка создания каталога {xPatch}");
                        Console.ResetColor();
                    }
                }
                //--------------------------------------------------------------------------------------------

                if (IsCreateDirectory == true)
                {
                    foreach (FileInfo file in new DirectoryInfo(xPatch).GetFiles())
                    {
                        file.Delete();
                    }
                }

                bool IsFileDownloads = true;
                bool IsAllFilesDownloads = true;
                //Downloade fales from list file signature
                for (int x = 0; x < resultParserUri.Length; x++)
                {
                    IsFileDownloads = true;
                    try
                    {
                        wc.DownloadFileTaskAsync(new Uri(resultParserUri[x]), System.IO.Path.Combine(xPatch, System.IO.Path.GetFileName(resultParserUri[x]))).Wait();
                    }
                    catch (Exception)
                    {
                        IsFileDownloads = false;
                        IsAllFilesDownloads = false;
                    }

                    if (xWriteConsoleText == "yes")
                    {
                        if (IsFileDownloads == true) { Console.WriteLine($"{x + 1}. \t Files Name {resultParserUri[x]} is download... \t {new System.IO.FileInfo(System.IO.Path.Combine(xPatch, System.IO.Path.GetFileName(resultParserUri[x]))).Length}"); }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{x + 1}. \t Files Name {resultParserUri[x]} is not downloads...");
                            Console.ResetColor();
                        }
                    }
                }

                if (xWriteConsoleText == "yes")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (IsAllFilesDownloads == false) { Console.WriteLine("Error Downloads All File signature"); }
                    Console.ResetColor();

                    //Insert Code from copy dataBase *.nup in file share.
                }
            }
            else { Console.WriteLine("Not found file *.ver and *.nup "); }

        }

        static void CopyNUPDataBase(string PatchIn, string PatchOut, string[] FileName)
        {
            //DirectoryInfo NetDyrectoryOut;
            

        }
    }
}
