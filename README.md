"# Software product for creating backups / Програмный продукт для создания бекапов" 

------------------------------------
June 10, 2020, 11:07 p.m.

Added and completed procedures for working with SMB configuration

public static void CreateConfigSMBXML ()
public static void AddJobsForConfigSMBXML (string CdirPatchInput, string CdirPatchOutput, bool ISExDir = false)
public static void RemoveJobsForConfigSMBXML (int IdJObsForConfig, bool IsRepackConfig = true)
public static void RemoveListJobsForConfigSMBXML (List <int> IdJobsForConfig, bool IsRepackConfig = true)
public static void RemoveAllJobsForConfigSMBXML ()
private static void RepackJobsForConfigSMBXML ()

Plan to move on to writing a user interface.
---
10 Июнь 2020, 23:07 часов ночи.

Добавлены и доделаны процедуры для работы с конфигурацией SMB

public static void CreateConfigSMBXML()
public static void AddJobsForConfigSMBXML(string CdirPatchInput, string CdirPatchOutput, bool ISExDir = false)
public static void RemoveJobsForConfigSMBXML(int IdJObsForConfig, bool IsRepackConfig = true)
public static void RemoveListJobsForConfigSMBXML(List<int> IdJobsForConfig, bool IsRepackConfig = true)
public static void RemoveAllJobsForConfigSMBXML()
private static void RepackJobsForConfigSMBXML()

Планируеться перейти к написанию пользовательского интерфейса.

------------------------------------
June 10, 2020, 8:02 p.m.

Added to the ConfigSMB class procedures for creating a configuration (CreateConfigSMBXML) and for editing a configuration file (AddJobsForConfigSMBXML).
At the moment, changes are being added to the function of changing attributes, that is, in the appendix.
---
10 Июнь 2020, 20:02 часов вечера

Добавлено в клас ConfigSMB процедуры для создания конфигурации (CreateConfigSMBXML) и для редактирования конфигурационного файла (AddJobsForConfigSMBXML).
На данный момент добавляются изменения в функции изменения атрибутов, то есть в добавлении.
------------------------------------
June 10, 2020, 9:58 a.m.

Save....
------------------------------------
June 9, 2020, 8:24 p.m.

Save....
------------------------------------
May 04, 2020, 10:20 p.m.

Save....
------------------------------------
May 04, 2020, 04:08 a.m.

Save....
------------------------------------
May 04, 2020, 02:17 a.m.

The results of the test execution of the software product are cleared
---
04 Мая 2020, 02:17 часов ночи

Очищено результаты тестового выполнение програмного продукта
------------------------------------
April 29, 2020, 01:12 a.m.

Fixed bug in OpenUrl procedure (string xWriteConsoleText), which related to incorrect operation of the WebCilent component.

---
29 Апреля 2020, 01:12 часов ночи

Исправлена ошибка в процедурее OpenUrl(string xWriteConsoleText), что касалась неправильной работы компонента WebCilent.
------------------------------------
April 29, 2020

The OpenUrl procedure (string xWriteConsoleText) has been modified, namely, part of the code has been transferred to a separate AllProg class, which was responsible for searching and Gksh the list of files that need to be downloaded from the parsed page.

---
29 Апреля 2020

Модифицирована процедура OpenUrl(string xWriteConsoleText), а именно перенесена часть кода в одельный клас AllProg что отвечала за поиск и Uri списка файлов что нужно закачивать из пропарсеной страницы
------------------------------------