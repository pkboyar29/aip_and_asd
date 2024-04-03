using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Работа_с_бинарными_файлами
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream Stream = new FileStream("1.txt", FileMode.Create, FileAccess.Write);
            BinaryWriter Writer = new BinaryWriter(Stream);
            for (int i = 0; i < 5; i++)
                Writer.Write(i);
            Writer.Close();
            Stream.Close();
            FileStream Stream1 = new FileStream("1.txt", FileMode.Open, FileAccess.Read);
            BinaryReader Reader = new BinaryReader(Stream1);
            int s;
            int k = 0;
            while (Reader.PeekChar() != -1)
            {
                s = Reader.ReadInt32();
                if (s % 2 == 0)
                {
                    k++;
                }
            }
            Console.WriteLine(k);
            Reader.Close();
            Stream1.Close();
            Console.ReadKey();
        }
    }
}
