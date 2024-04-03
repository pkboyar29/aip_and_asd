using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Дан текстовый файл f. Записать в файл g с сохранением порядка следования те символы файла f, вслед за которыми в файле идет буква а.
// должно быть 4; j; l (так и есть)

namespace lab10_15
{
    public class Program
    {
        static string Before_a(string str)
        {
            string strRes = "";
            char[] vs = str.ToCharArray();
            for (int i = 1; i < vs.Length; i++)
            {
                if (vs[i] == 'a')
                    strRes += vs[i - 1];
            }
            return strRes;
        }
        static void Main(string[] args)
        {
            FileStream f = new FileStream("f.txt", FileMode.Open, FileAccess.Read);
            FileStream g = new FileStream("g.txt", FileMode.Create, FileAccess.Write);
            StreamReader Reader = new StreamReader(f);
            string str = Reader.ReadToEnd();
            string strRes = Before_a(str);
            StreamWriter Writer = new StreamWriter(g);
            for (int i = 0; i < strRes.Length; i++)
            {
                Writer.Write(strRes[i]);
            }
            Writer.Close();
            Reader.Close();
            f.Close();
            g.Close();
        }
    }
}
