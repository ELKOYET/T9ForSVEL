using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;


namespace T9ForSVEL
{
    public partial class Form1 : Form
    {
        public static ApplicationContext context = new ApplicationContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationContext>());
        // путь к файлу с текстом
        public static string path;
        // набор слов после удаления разделителей
        public static string[] wordArray;
        // набор разделителей
        public static char[] separators = new char[] { ' ', ',', '.', '!', '?', ':', '-', '*', '\r', '\n' };

        public static Dictionary<string, int> repeatedWords = new Dictionary<string, int>();

        private int currentTextLength = 0;
        private string currentWord = "";

        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ListWords_Click(object sender, EventArgs e)
        {
            ListBox box = (sender as ListBox);
            var word = box.SelectedItem.ToString();
            if (textBox1.Text.Contains('.') || textBox1.Text.Contains(','))
            {
                currentWord = textBox1.Text.Substring(0, textBox1.Text.LastIndexOf(' ') + 1) +' ' + word + ' ';
            }
            else
                currentWord = word + " ";
            textBox1.Text = currentWord;
            ListWords.Items.Clear();
            GetWords(currentWord);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (sender as TextBox);

            if (box.Text.Length > 0)
            {
                if (currentTextLength < box.Text.Length)
                {
                    char lastLetter = box.Text[box.Text.Length - 1];
                    if ((lastLetter == ',' || lastLetter == '.') && box.Text[box.Text.Length -2] == ' ' && box.Text[box.Text.Length - 3] != ' ')
                    {
                        box.Text = box.Text.Remove(box.Text.Length - 2, 1) + ' ';
                        box.SelectionStart = box.Text.Length;

                    };
                    if (lastLetter == ' ')
                    {
                        currentWord = "";
                        
                    }
                    else currentWord += lastLetter;
                    if ((box.Text.Contains('.') || box.Text.Contains(',')))
                    {
                        currentWord = box.Text.Substring(box.Text.LastIndexOf(' ') + 1);

                    }

                }
                else if (box.Text.Length < currentTextLength) if (currentWord.Length > 0) currentWord = currentWord.Remove(currentWord.Length - 1, 1);
            }

            else currentWord = "";
            currentTextLength = box.Text.Length;
            ListWords.Items.Clear();
            GetWords(currentWord);
        }

        private void созданиеСловаряToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
            //очищаем БД перед загрузкой нового словаря
            DictionaryClear();
            //цикл для вычисления кол-ва повторений
            foreach (var word in wordArray)
            {
                //если слово короткое, то оно не подходит
                if (word.Length < 3) continue;
                //если встречается чаще трех раз
                int count = wordArray.Count(x => x == word);
                //заносим подходящие слова 
                if (count >= 3 && !repeatedWords.ContainsKey(word))
                {
                    repeatedWords.Add(word, count);
                    context.wordDictionaries.Add(new WordDictionary { Text = word, Count = count });
                }
            }
            context.SaveChanges();
        }

        private void очисткаСловаряToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //уточняем надо ли очищать
            if (MessageBox.Show("Хотите ли вы очистить словарь?", "Очистка словаря", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                DictionaryClear();
        }

        //Метод для очистки БД
        public static void DictionaryClear()
        {
            context.wordDictionaries.RemoveRange(context.wordDictionaries);
            repeatedWords.Clear();
            context.SaveChanges();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE [wordDictionaries]");
        }

        private void обновлениеСловаряToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //открываем файл
            OpenFile();
            foreach (var word in wordArray)
            {
                //если слово короткое, то оно не подходит
                if (word.Length < 3) continue;
                //переменная под существующее слово
                WordDictionary sameword = context.wordDictionaries.FirstOrDefault(x => x.Text == word);
                //если такое слово существует, то
                if (sameword != null)
                {
                    //увеличиваем количество повторений слова
                    sameword.Count++;
                }
                //если нового слова ранее не встречалось
                else
                {
                    //если встречается чаще трех раз
                    int count = wordArray.Count(x => x == word);
                    //заносим подходящие слова 
                    if (count >= 3 && !repeatedWords.ContainsKey(word))
                    {
                        repeatedWords.Add(word, count);
                        context.wordDictionaries.Add(new WordDictionary { Text = word, Count = count });
                    }
                }
            }
            context.SaveChanges();
        }
        //метод на чтение файла
        public static void OpenFile()
        {
            //открываем диалог с выбором файла
            OpenFileDialog openFile = new OpenFileDialog();
            //можем выбирать только ТХТ
            openFile.Filter = "Text files (*.txt)| *.txt";
            //если выбранный файл подходит
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                path = openFile.FileName;
                string rawText = "";
                using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
                {
                    //заносим сырые данные
                    rawText = streamReader.ReadToEnd();
                }
                //получаем массив слов без разделителей
                wordArray = rawText.Trim().Split(separators);
            }
        }

        public void GetWords(string text)
        {
            if (!(string.IsNullOrEmpty(text)) && text.First() != ' ')
                ListWords.Items.AddRange(context.wordDictionaries.Where(x => x.Text.StartsWith(text)).OrderBy(x => x.Text).Take(5).OrderByDescending(x => x.Count).Select(x => x.Text).ToArray());
        }
    }
}
