using System;
/*Дана строка-предложение на русском языке и число K (0 < K < 10).
Зашифровать строку, выполнив циклическую замену каждой буквы на
букву того же регистра, расположенную в алфавите на K-й позиции после
шифруемой буквы (например, для K = 2 «А» перейдет в «В», «а» — в «в»,
«Б» — в «Г», «я» — в «б» и т. д.). Букву «ё» в алфавите не учитывать,
знаки препинания и пробелы не изменять. */
namespace Musatov_lab13_7
{
    class Program
    {
        static string kright(string s, int k)
        {
            string res = "";
            s = s.Trim();
            int n;
            string[] words = s.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                char[] abc = words[i].ToCharArray();
                for (int j = 0; j < abc.Length; j++)
                {
                    // 1103 - я; 1072 - а
                    if ((char)((int)abc[j] + k) > 1103 && (int)abc[j] >= 1072 && (int)abc[j] <= 1103) // для маленьких букв
                    {
                        n = k - ('я' - abc[j]);
                        res = res + (char)('а' + n - 1);
                    } else if ((char)((int)abc[j] + k) > 1071 && (int)abc[j] >= 1040 && (int)abc[j] <= 1071) // для заглавных букв
                    {
                        n = k - ('Я' - abc[j]);
                        res = res + (char)('А' + n - 1);
                    } else
                    {
                        res = res + (char)((int)abc[j] + k);
                    }
                }
                res += ' ';
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.Write("Введите k: ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Введите строку-предложение на русском языке: ");
            string txt = Console.ReadLine();
            Console.WriteLine("Строка после изменений: {0}",kright(txt, k));
        }
    }
}
