using System;
using System.IO;
using System.Net;
using HtmlAgilityPack;


namespace Nup_ConsoleDownloadsFiles
{
    class Program
    {
        static WebClient wc;
        static string[] tresDownNup;
        static string[] resDownNup;

        //-----------------------------------------------------------------------
        //Default param
        //-----------------------------------------------------------------------
        static Uri xUri = new Uri(@"http://nod.gorod.nu/eset_upd/");
        static string xPatch = AppDomain.CurrentDomain.BaseDirectory + @"New";
        //-----------------------------------------------------------------------

        static void Main(string[] args)
        {
            Console.WriteLine($"Запуск парсина Uri({xUri.ToString()}) сервера обновлений Nod...");
            Console.WriteLine("");
            if(args.Length != 0)
            {
                if (args[0] == "-r") { OpenUrl(); }
                else { Console.WriteLine($" {args}"); }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("Error parameters is this program"); Console.ResetColor();
                Console.WriteLine("\nПри запуске используються следующие параметры:");
                Console.WriteLine("-r - запустить программу на выполнение.");
                Console.WriteLine("-l - отображать список файлов полученых с Uri для скачивания.");
            }
        }

        static void OpenUrl()
        {
            int resCount = 0;
            int resNUP_Ver = 0;
            string tres;

            wc = new WebClient();
            HtmlDocument xDoc = new HtmlDocument();
            xDoc.Load(wc.OpenRead(xUri));
            tresDownNup = new string[xDoc.DocumentNode.SelectNodes("//a[@href]").Count];

            //This Block find All tag from exists links
            foreach (HtmlNode a in xDoc.DocumentNode.SelectNodes("//a[@href]"))
            {
                tresDownNup[resCount] = xUri.ToString() + a.Attributes["href"].Value;
                resCount++;

                tres = (tresDownNup[resCount - 1].Split(".")[tresDownNup[resCount - 1].Split(".").Length - 1]).ToUpper();
                if ((tres == ("nup").ToUpper()) || (tres == ("ver").ToUpper()))
                {
                    resNUP_Ver++;
                    //Console.WriteLine(tres);
                }
            }

            //This Block find from top data, wish generate left Block, data what == ".NUM " Or  == ".VER"
            if (resNUP_Ver > 0)
            {
                resDownNup = new string[resNUP_Ver];
                int tmpX = 0;

                for (int x = 0; x < tresDownNup.Length; x++)
                {
                    tres = (tresDownNup[x].Split(".")[tresDownNup[x].Split(".").Length - 1]).ToUpper();
                    tres = tres.Split("/")[tres.Split("/").Length - 1].ToUpper();

                    if ((tres == ("nup").ToUpper()) || (tres == ("ver").ToUpper()))
                    {
                        resDownNup[tmpX] = tresDownNup[x];
                        tmpX++;
                    }
                }

                //Print for screen list downloade file signature
                // for (int x = 0; x < resDownNup.Length; x++)
                //{
                //    Console.WriteLine((x+1).ToString() + "\t" + resDownNup[x]);
                //}

                Console.WriteLine($"Сформировано список из {tmpX} файлов...");

                //--------------------------------------------------------------------------------------------
                //Create Directory from Downloade file signature for last ago...
                //--------------------------------------------------------------------------------------------
                bool IsCreateDirectory = true;

                //Downloads file from exists dyrectory
                if (!Directory.Exists(xPatch))
                {
                    try {
                        Directory.CreateDirectory(xPatch);
                    }
                    //Указанный каталог path является файлом. Имя сети неизвестно.
                    catch (IOException)
                    {
                        Console.WriteLine("Create Directory is a file or networks name is not exist.");
                        IsCreateDirectory = false;
                        return;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        IsCreateDirectory = false;
                    }
                }

                if (IsCreateDirectory == true) { Console.WriteLine($"Директория {xPatch} создана");}
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка создания каталога {xPatch}");
                    Console.ResetColor();
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
                for (int x = 0; x < resDownNup.Length; x++)
                {
                    IsFileDownloads = true;
                    try
                    {
                        wc.DownloadFileTaskAsync(new Uri(resDownNup[x]), System.IO.Path.Combine(xPatch, System.IO.Path.GetFileName(resDownNup[x]))).Wait();
                    }
                    catch (Exception)
                    {
                        IsFileDownloads = false;
                        IsAllFilesDownloads = false;
                    }

                    if (IsFileDownloads == true) { Console.WriteLine($"{x+1}. \t Files Name {resDownNup[x]} is download... \t {new System.IO.FileInfo(System.IO.Path.Combine(xPatch, System.IO.Path.GetFileName(resDownNup[x]))).Length}"); }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{x+1}. \t Files Name {resDownNup[x]} is not downloads...");
                        Console.ResetColor();
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                if (IsAllFilesDownloads == false) { Console.WriteLine("Error Downloads All File signature"); }
                Console.ResetColor();

            }

        }
    }
}
