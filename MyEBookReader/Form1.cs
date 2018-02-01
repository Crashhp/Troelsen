using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEBookReader
{
    public partial class Form1 : Form
    {
        private string theEBook;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, eArgs) =>
            {
                theEBook = eArgs.Result;
                txtBook.Text = theEBook;
            };

            wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));
        }

        private void btnGetStats_Click(object sender, EventArgs e)
        {
            // Получить слова из электронной книги.
            string[] words = theEBook.Split(new char[]{ ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' }, StringSplitOptions.RemoveEmptyEntries);
            // Найти 10 наиболее часто встречающихся слов.
            string[] tenMostCommon = null;
            // Получить самое длинное слово.
            string longestWord = string.Empty;

            Parallel.Invoke(() =>
            {
                tenMostCommon = FindTenMostCommon(words);
            },
            ()=>
            {
                longestWord = FindLongestWord(words);
            });            

            StringBuilder bookStats = new StringBuilder("Ten Most Common Words are:\n");
            foreach (string str in tenMostCommon)
            {
                bookStats.AppendLine(str);
            }
            bookStats.AppendFormat("Longest word is: {0}", longestWord);
            bookStats.AppendLine();
            MessageBox.Show(bookStats.ToString(), "Book info");
        }

        private string[] FindTenMostCommon(string[] words)
        {
            var frequencyOrder = words.Where(word => word.Length > 6).GroupBy(word => word).OrderByDescending(g => g.Count()).Select(g => g.Key);
            string[] commonWords = frequencyOrder.Take(10).ToArray();
            return commonWords;
        }

        private string FindLongestWord(string[] words)
        {
            return words.OrderByDescending(word => word.Length).Select(word => word).FirstOrDefault();
        }
    }
}
