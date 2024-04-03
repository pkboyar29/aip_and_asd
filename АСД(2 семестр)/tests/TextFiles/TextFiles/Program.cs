using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFiles
{
    public class Program
    {
        static void Main(string[] args)
        {
            // запись в текстовый файл с помощью класса StreamWriter   
            // создаём новый текстовый файл 1.txt; fileaccess.write - это значит, что файл только для записи
            FileStream Stream = new FileStream("1.txt", FileMode.Create, FileAccess.Write);
            Random n = new Random();
            StreamWriter w = new StreamWriter(Stream, Encoding.UTF8);
            for (int i = 0; i < 10; i++)
            {
                w.WriteLine((char)n.Next((int)'А', (int)'я' + 1));
            }
            w.Close();
            Stream.Close();

            // encoding.default - сам класс будет разбираться с кодировкой файла
            StreamReader sr = new StreamReader("1.txt", System.Text.Encoding.Default);
            string line;
            //line = sr.ReadLine();
            //Console.WriteLine(line);
            while ((line = sr.ReadLine()) != null)
                Console.WriteLine(line);
            sr.Close();

            // чтение блоками или полностью из текстового файла
            // fileaccess.read значит, что мы не будем ничего записывать в файл;
            FileStream Stream1 = new FileStream("2.txt", FileMode.Open, FileAccess.Read);
            StreamReader r = new StreamReader(Stream1);
            // считывание блоками (считали просто в массив символов)
            char[] array = new char[4];
            r.Read(array, 0, 2);
            // считывание всего файла (так можно считать всё содержимое файла в строчку и дальше с этим работать)
            string str = r.ReadToEnd();
            Console.WriteLine(str);
            r.Close();
            Console.ReadLine();
        }
    }
}
