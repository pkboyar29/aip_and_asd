using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace lab12
{
    public partial class Form1 : Form
    {
        string _text;
        string _word;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            labelError.Text = "";
            try
            {
                FileStream s = new FileStream(txtFile.Text, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(s);
                _text = reader.ReadToEnd();
                s.Close();
                reader.Close();
            } catch
            {
                labelError.Text = "Неправильный путь к файлу";
            }
            _word = txtValue.Text;
            if (_word.Length > _text.Length || _word == "")
            {
                labelError.Text = "Длина подстроки больше количества символов в файле, либо подстрока пустая";
            } else
            {
                Mur(_text, _word, label3);
                if (label3.Text == _text) label3.Text = "Подстрока не найдена";
            }
        }


        static Dictionary<string, int> SuffixTable(string word)
        {
            Dictionary<string, int> D = new Dictionary<string, int>();
            for (int i = 1; i <= word.Length; i++)
            {
                string wsub = word.Substring(word.Length - i);
                if (word.LastIndexOf(wsub) == word.IndexOf(wsub))
                    D.Add(wsub, word.Length);
                else
                {
                    D.Add(wsub, (word.Length) - (word.Substring(0, word.Length - i).LastIndexOf(wsub) + i));
                }
            }
            return D;
        }

        static void Mur(string text, string word, Label lb)
        {
            Dictionary<string, int> D = new Dictionary<string, int>();
            D = SuffixTable(word);
            lb.Text = text;
            int x = 0;
            // y - колво символов в суффиксе (если суффиксы совпадают, увеличиваем на единицу)
            int y = 1;
            int xword = x + word.Length;
            int yword = word.Length - y;
            while (x + word.Length <= text.Length)
            {
                // длина слова над ( берём длину слова над + x (смещение))
                xword = x + word.Length;
                // длина суффикса в слове под; с каждым разом она увеличивается, и мы захватываем больший суффикс (сначала 1, потом 2 и тд)
                yword = word.Length - y;
                // если суффиксы совпадают
                if (text.Substring(xword - y, y) == word.Substring(yword) && y < word.Length)
                    y++;
                else
                {
                    if (y == word.Length)
                        lb.Text += " ( позиция слова в тексте " + x + ") ";

                    x += D[word.Substring(yword)];
                    y = 1;
                }
            }
        }
    }
}
