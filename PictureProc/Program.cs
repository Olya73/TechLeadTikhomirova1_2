using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PictureProc
{
    class Program
    {
        static void Main(string[] args)
        {
            Run(args, path =>
            {              
                Picture picture = new Picture(path);
                Bitmap bmp = picture.ChangePicture();
                string newName = $"{Path.GetFileNameWithoutExtension(path)}-res.jpg";
                bmp.Save(newName);
                Console.WriteLine($"{newName} сохранен в директории");
            });

        }
        public static void Run(string[] args, Action<string> consolePrint)
        {

            string path;
            if (args.Length == 0)
            {
                Console.Write("Введите имя файла: ");
                path = Console.ReadLine();
            }
            else
                path = args[0];
            try
            {
                consolePrint(path);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Ошибка: {ex} файл не найден");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex} недопустимое расширение");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex}");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
