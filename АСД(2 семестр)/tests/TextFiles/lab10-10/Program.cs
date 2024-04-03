using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Дан текстовый файл. Подсчитать число появлений в нем каждой строчной русской буквы и создать строковый файл, элементы которого имеют вид <буква>–<число ее появлений> (например, а–25). Буквы, отсутствующие в тексте, в файл не включать. Строки упорядочить по убыванию числа появлений букв, а при равном числе появлений — по возрастанию кодов букв.

namespace lab10_10
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileStream s = new FileStream("1.txt", FileMode.Open, FileAccess.Read);
            FileStream g = new FileStream("2.txt", FileMode.Create, FileAccess.Write);
            StreamReader Reader = new StreamReader(s);
            StreamWriter Writer = new StreamWriter(g);
            string str = Reader.ReadToEnd();
        }
    }
}
