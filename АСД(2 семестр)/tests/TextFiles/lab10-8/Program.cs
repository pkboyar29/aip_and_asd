using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// Дан текстовый файл. Переписать в файл g все компоненты исходного файла с заменой в них символа 0 на символ 1 и наоборот

namespace lab10_8
{
    public class Program
    {
        static string ChangeOneToZero(string str)
        {
            char[] charArr = str.ToCharArray();
            for (int i = 0; i < charArr.Length; i++)
            {
                if (charArr[i] == '0')
                {
                    charArr[i] = '1';
                }
                else if (charArr[i] == '1')
                {
                    charArr[i] = '0';
                }
            }
            string strResult = new string(charArr);
            return strResult;
        }
        static void Main(string[] args)
        {
            FileStream s = new FileStream("1.txt", FileMode.Open, FileAccess.Read);
            FileStream g = new FileStream("g.txt", FileMode.Create, FileAccess.Write);
            StreamReader Reader = new StreamReader(s);
            string sStr = Reader.ReadToEnd();
            Reader.Close();
            sStr = ChangeOneToZero(sStr);
            StreamWriter Writer = new StreamWriter(g);
            for (int i = 0; i < sStr.Length; i++)
            {
                Writer.Write(sStr[i]);
            }
            Writer.Close();
            s.Close();
            g.Close();
            Console.ReadLine();
        }
    }
}
