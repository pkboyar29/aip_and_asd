using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// Дан текстовый файл содержащий в том числе информацию об автомобильных номерах в формате хYYYхх, где х — это буква, y – цифра. Выбрать данные, заданные в корректном формате и вывести на экран.

namespace musatov_lab10
{
    public class Program
    {
        static bool CheckCarNumber(string carNumber)
        {
            if (carNumber.Length != 6) return false;
            if (!Char.IsLetter(carNumber[0])) return false;
            if (!Char.IsNumber(carNumber[1])) return false;
            if (!Char.IsNumber(carNumber[2])) return false;
            if (!Char.IsNumber(carNumber[3])) return false;
            if (!Char.IsLetter(carNumber[4])) return false;
            if (!Char.IsLetter(carNumber[5])) return false;

            return true;
        }
        static string[] CarNumbers(string[] str)
        {
            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < str.Length; i++)
            {
                if (CheckCarNumber(str[i]))
                {
                    queue.Enqueue(str[i]);
                }
            }

            string[] carsNumbers = queue.ToArray();
            
            return carsNumbers;
        } 
        static void Main(string[] args)
        {
            FileStream s = new FileStream("1.txt", FileMode.Open, FileAccess.Read);
            FileStream g = new FileStream("2.txt", FileMode.Create, FileAccess.Write);
            StreamReader reader = new StreamReader(s);
            StreamWriter writer = new StreamWriter(g);
            string str = reader.ReadToEnd();
            string[] strList = str.Split(' ');
            string[] carNumbers = CarNumbers(strList);
            for (int i = 0; i < carNumbers.Length; i++)
            {
                writer.WriteLine(carNumbers[i]);
            }
            writer.Close();
            reader.Close();
            s.Close();
            g.Close();
            Console.ReadLine();
        }
    }
}
