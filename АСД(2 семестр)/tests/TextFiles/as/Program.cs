using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace @as
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream von = new FileStream("1.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(von);
            for (int i = 0; i < 20; i++)
            {
                sw.WriteLine(2);
                //sw.Write(" ");
            }
            sw.Close();
            von.Close();
            
        }
    }
}
