using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Directory(Info) *****\n");
            ShowWindowsDirectoryInfo();
            DisplayImageFiles();
            FunWithDirectoryType();
            Console.ReadLine();
        }

        static void ShowWindowsDirectoryInfo()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("***** Directory Info *****");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent); // родительский каталог
            Console.WriteLine("Creation: {0}", dir.CreationTime); // время создания
            Console.WriteLine("Attributes : {0}", dir.Attributes); // атрибуты
            Console.WriteLine("Root: {0}", dir.Root); // корневой каталог
            Console.WriteLine("***************************\n");
        }

        static void DisplayImageFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");
            // Получить все файлы с расширением *. jpg.
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            // Сколько файлов найдено?
            Console.WriteLine("Found {0} *.jpg files\n", imageFiles.Length);
            // Вывести информацию о каждом файле.
            foreach (FileInfo f in imageFiles)
            {
                Console.WriteLine("***************************");
                Console.WriteLine("File name: {0}", f.Name); // имя файла
                Console.WriteLine("File size: {0}", f.Length); // размер
                Console.WriteLine("Creation: {0}", f.CreationTime); // время создания
                Console.WriteLine("Attributes: {0}", f.Attributes); // атрибуты
                Console.WriteLine("***************************\n");
            }
        }

        static void FunWithDirectoryType()
        {
            // Вывести список всех дисковых устройств текущего компьютера.
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here are your drives:");
            foreach (string s in drives)
                Console.WriteLine("— > {0} ", s);
            // Удалить то, что было ранее создано.
            Console.WriteLine("Press Enter to delete directories");
            Console.ReadLine();
            try
            {
                Directory.Delete(@"C:\MyFolder");
                // Второй параметр указывает, нужно ли удалять подкаталоги.
                Directory.Delete(@"С:\MyFolder2", true);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
