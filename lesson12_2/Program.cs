using System;
using lesson12_2;
using System.IO.Compression;

namespace lesson12
{
    public class Program
    {
        static void Main(string[] args)
        {
            var finalFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Lesson12Homework.txt");
            string information;
            List<Info> info = new List<Info>();
            int i = 0;

            StreamReader sr = new StreamReader(finalFilePath);
            StreamReader sr1 = new StreamReader(sr.ReadLine());
            
            while ((information = sr1.ReadLine()) != null)
            {
                info.Add(new Info(information));
                i++;
            }
            sr.Close();
            sr1.Close();

            Console.WriteLine();

            info.Sort();
            
            foreach (Info info1 in info)
            {
                Console.WriteLine($"{info1.filename} (время последнего редактирования:{info1.filedata})");
            }

        }
    }
}