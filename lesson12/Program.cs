using System;
using System.IO.Compression;

namespace lesson12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myString = "Hello World!";
            var filePath = Path.Combine("C:", "Users", "alvio", "source", "repos", "lesson12", "lesson12","bin", "Debug", "net6.0");
            var finalFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Lesson12Homework.txt");

            //Создаем директории для работы
            Directory.CreateDirectory(filePath + "\\myFolder");
            Directory.CreateDirectory(filePath + "\\taskFolder");
            
            //Создаём файл для последующей архивации
            FileStream fs = new FileStream(filePath + "\\myFolder\\helloworld.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(myString);
            sw.Close();
            fs.Close();

            //Архивируем и извлекаем из архива подготовленные файлы
            ZipFile.CreateFromDirectory(filePath + "\\myFolder", filePath + "\\taskFolder\\archive.zip");
            ZipFile.ExtractToDirectory(filePath + "\\taskFolder\\archive.zip", filePath + "\\taskFolder");

            //записываем информацию о созданных файлах
            fs = new FileStream(filePath + "\\taskFolder\\task.csv", FileMode.OpenOrCreate);
            sw = new StreamWriter(fs);
            foreach (string str in Directory.GetDirectories(filePath + "\\taskFolder"))
            {
                FileInfo fi = new FileInfo(str);
                sw.WriteLine("folder\t" + fi.Name + "\t" + fi.LastWriteTime);
            }
            foreach (string str in Directory.GetFiles(filePath + "\\taskFolder"))
            {
                FileInfo fi = new FileInfo(str);
                sw.WriteLine("file\t" + fi.Name + "\t" + fi.LastWriteTime);
            }
            sw.Close();
            fs.Close();

            //удаляем созданные ранее файлы и папки
            File.Delete(filePath + "\\taskFolder\\archive.zip");
            File.Delete(filePath + "\\taskFolder\\helloworld.txt");
            File.Delete(filePath + "\\myFolder\\helloworld.txt");
            Directory.Delete(filePath + "\\myFolder");

            //записываем информацию в файл %AppData%/Lesson12Homework.txt
            fs = new FileStream(finalFilePath, FileMode.OpenOrCreate);
            sw = new StreamWriter(fs);
            foreach (string str in Directory.GetFiles(filePath + "\\taskFolder"))
            {
                sw.WriteLine(str);
            }
            sw.Close();
            fs.Close();

        }
    }
}