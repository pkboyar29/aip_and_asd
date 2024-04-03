using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Дана строка S, состоящая из 10 цифр, и файл с русским текстом. Зашифровать файл, выполнив циклическую замену каждой русской буквы, стоящей на K-й позиции строки, на букву того же регистра, расположенную в алфавите на SK-месте после шифруемой буквы (для K = 11 снова используется смещениеS1 и т. д.). Знаки препинания и пробелы не изменять.

namespace lab11
{
    public class Program
    {
        static void Encrypt(string S, ref string text)
        {
            char[] textArray = text.ToCharArray();
            for (int K = 0; K < textArray.Length; K++)
            {
                if ((textArray[K] >= 'а' && textArray[K] <= 'я') || (textArray[K] >= 'А' && textArray[K] <= 'Я'))
                {
                    int I;
                    int p;
                    if (K >= 10) I = K % 10; 
                    else I = K;
                    // num - это сдвиг вправо, который берётся из строки S
                    int num = int.Parse(S[I].ToString());
                    // для маленьких букв
                    if (textArray[K] >= 'а' && textArray[K] <= 'я')
                    {
                        if (textArray[K] + num > 'я')
                        {
                            p = (textArray[K] + num) - 'я' - 1;
                            textArray[K] = (char)('а' + p);
                        } else textArray[K] = (char)(textArray[K] + num);
                    }
                    // для больших букв
                    else if (textArray[K] >= 'А' && textArray[K] <= 'Я')
                    {
                        if (textArray[K] + num > 'Я')
                        {
                            p = (textArray[K] + num) - 'Я' - 1;
                            textArray[K] = (char)('А' + p);
                        }
                        else textArray[K] = (char)(textArray[K] + num);
                    }
                }
            }
            text = new string(textArray);
        }
        static void Main(string[] args)
        {
            string S = "2234567892";
            FileStream s = new FileStream("1.txt", FileMode.Open, FileAccess.Read);
            FileStream g = new FileStream("2.txt", FileMode.Create, FileAccess.Write);
            StreamReader reader = new StreamReader(s);
            StreamWriter writer = new StreamWriter(g);
            string fileText = reader.ReadToEnd();
            Encrypt(S, ref fileText);
            writer.WriteLine(fileText);
            writer.Close();
            reader.Close();
            s.Close();
            g.Close();
            Console.ReadLine();
        }
    }
}
