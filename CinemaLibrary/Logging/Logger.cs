using System;
using System.IO;

namespace CinemaLibrary.Logging
 {
     /// <summary>
     /// Базовый класс для логгеров в проекте
     /// </summary>
     public class Logger
     {
         /// <summary>
         /// Показывает, записывается лог в файл или stdout
         /// </summary>
         protected readonly bool ToFile;

         /// <summary>
         /// Имя файла с логом
         /// </summary>
         protected readonly string Filename;

         /// <summary>
         /// Создание логгера с привязкой к файлу/консоли
         /// </summary>
         /// <param name="path">Путь к файлу. Если пуст/null - вывод пойдёт в консоль</param>
         public Logger(string path=null)
         {
             ToFile = !string.IsNullOrEmpty(path);
             if (!ToFile) return;
             Filename = path;
             if (!File.Exists(Filename))
             {
                 File.Create(Filename).Close();
             }
         }

         /// <summary>
         /// Получение ссылка на файл либо консоль, в зависимости от ToFile
         /// </summary>
         /// <returns>Нужный TextWriter</returns>
         public TextWriter GetOutput()
         {
             return ToFile ? File.AppendText(Filename) : Console.Out;
         }
     }
 }