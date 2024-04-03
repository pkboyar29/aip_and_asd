using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

/* 12.Даны два текстовых файла, содержащих прайс-листы в формате
«Наименование товара цена», в наименовании товара пробелы
отсутствуют. С использованием коллекции Dictionary написать
программу, позволяющую объединить два прайс-листа в один. При этом
для одинакового наименования товара в итоговый прайс-лист должна
войти большая стоимость. Вывести полученный прайс-лист на экран. */

namespace lab11_musatov
{
    internal class Program
    {
        static Dictionary<string, int> CreateDic(string[] PriceList)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();

            for (int i = 0; i < PriceList.Length; i++)
            {
                string[] line = PriceList[i].Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
                dic.Add(line[0], int.Parse(line[1]));
            }

            return dic;
        }

        static Dictionary<string, int> CombinePriceLists(Dictionary<string, int> dic1, Dictionary<string, int> dic2)
        {

            foreach (KeyValuePair<string, int> x in dic2)
            {
                if (dic1.ContainsKey(x.Key))
                {
                    int valueFrom1dic;
                    dic1.TryGetValue(x.Key, out valueFrom1dic);
                    if (x.Value > valueFrom1dic)
                    {
                        dic1.Remove(x.Key);
                        dic1.Add(x.Key, x.Value);
                    }
                }
                else dic1.Add(x.Key, x.Value);
            }

            return dic1;
        }

        static void DicOutput(Dictionary<string, int> dic)
        {
            foreach (KeyValuePair<string, int> x in dic)
                Console.WriteLine("{0} - {1}", x.Key, x.Value);
        }
        static void Main(string[] args)
        {
            try
            {
                string[] PriceList1 = File.ReadAllLines("1.txt");
                string[] PriceList2 = File.ReadAllLines("2.txt");

                Dictionary<string, int> DicPriceList1 = CreateDic(PriceList1);
                Dictionary<string, int> DicPriceList2 = CreateDic(PriceList2);

                Dictionary<string, int> FinalPriceList = CombinePriceLists(DicPriceList1, DicPriceList2);

                DicOutput(FinalPriceList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
