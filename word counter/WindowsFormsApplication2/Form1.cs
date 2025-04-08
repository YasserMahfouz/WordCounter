using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        //SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
        int txtLength = -1;
        int minute = 10;
        int sec = 60;
        //int wrongs = 0;
        Dictionary<int, int> errorLetters = new Dictionary<int, int>();//لتحزين الحروف الخطأ
        Dictionary<int, int> dict = new Dictionary<int, int>();//لتخزين بداية ونهاية الكلمات 
        Dictionary<int, int> wordErrors = new Dictionary<int, int>();//لعد الكلمات الخطأ
        public void wrongs(string str1, string str2) {
           
            for (int i = 0; i < str2.Length; i++)
                if (str1[i] != str2[i])
                    if (errorLetters.ContainsKey(i))
                        errorLetters[i] = 1;
                    else
                        errorLetters.Add(i, 1);
                else if (str1[i] == str2[i])
                    if (errorLetters.ContainsKey(i))
                        errorLetters[i] = 0;
                    else
                        errorLetters.Add(i, 0);
            int start = 0;
            int end = 0;
            string[] arrOfFirst = str1.Split(' ');
            for (int i = 0; i < arrOfFirst.Length; i++)
            {
                end = start + arrOfFirst[i].Length;
                dict.Add(start, end - 1);
                start = end + 1;
            }
            foreach (int key in errorLetters.Keys)
                if (errorLetters[key] > 0)
                    foreach (int indexes in dict.Keys)
                        if (key >= indexes && key <= dict[indexes])
                        {
                            if (wordErrors.ContainsKey(indexes + dict[indexes]))
                                wordErrors[indexes + dict[indexes]] = 1;
                            else
                                wordErrors.Add(indexes + dict[indexes], 1);
                        }
            label3.Text = "عدد الكلمات الخطأ: " + wordErrors.Count;

        }
        public void replace(string str1)                         
        {
            string pattern =
                "[\u064C\u064D\u064E\u064F\u0650\u0651\u0652\u0653\u0657\u0640D\u061b\u201d\u0640\u002c]";
            string replacement = "";
          Regex  rx = new Regex(pattern);
          string  result = rx.Replace(str1, replacement);
             pattern = "\\s+";
             replacement = " ";                      
             rx = new Regex(pattern);
             result = rx.Replace(result, replacement);
            
            rtb1.Text = result;
        }

        public Form1()
        {
            InitializeComponent();
            label3.Text = "";
            label4.Text = "";
            timeBar.ForeColor = Color.LimeGreen;
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            try

            {

                
                int length = rtb2.Text.Length;




                if (rtb2.TextLength <= txtLength)
                {
                    if (txtLength < 40) {
                        for (int i = 0; i < txtLength; i++)
                            if (rtb1.Text[i] != rtb2.Text[i])
                            {
                                string pattern = "[\u0623\u0625\u0626\u0621\u0624\u0622\u064b]";
                                Regex r = new Regex(pattern);
                                Match match = r.Match(rtb1.Text[i].ToString());

                                if (match.Success)
                                {
                                    if (i == 0)
                                    {
                                        rtb1.Select(i, 2);
                                        rtb1.SelectionColor = System.Drawing.Color.Red;

                                    }
                                    else
                                    {
                                        rtb1.Select(i - 1, 2);
                                        rtb1.SelectionColor = System.Drawing.Color.Red;
                                    }
                                }
                                else
                                {
                                    rtb1.Select(i, 1);
                                    rtb1.SelectionColor = System.Drawing.Color.Red;
                                }
                                //if (dict.ContainsKey(length - 1))
                                //    dict[length - 1]=1;
                                //else
                                //    dict.Add(length - 1, 1);
                            }
                            else if (rtb1.Text[i] == rtb2.Text[i])
                            {
                                string pattern = "[\u0623\u0625\u0626\u0621\u0624\u0622\u064b]";
                                Regex r = new Regex(pattern);
                                Match match = r.Match(rtb1.Text[i].ToString());

                                if (match.Success)
                                {
                                    if (i == 0)
                                    {
                                        rtb1.Select(i, 2);
                                        rtb1.SelectionColor = System.Drawing.Color.Green;

                                    }
                                    else
                                    {
                                        rtb1.Select(i, 1);
                                        rtb1.SelectionColor = System.Drawing.Color.Green;
                                    }
                                }
                                else
                                {
                                    rtb1.Select(i, 1);
                                    rtb1.SelectionColor = System.Drawing.Color.Green;
                                }

                                //if (dict.ContainsKey(length - 1))
                                //    dict[length - 1]=0;
                                //else
                                //    dict.Add(length - 1, 0);

                            }
                    }
                    else
                    for (int i = txtLength-40; i < txtLength; i++)
                        if (rtb1.Text[i] != rtb2.Text[i])
                        {
                            string pattern = "[\u0623\u0625\u0626\u0621\u0624\u0622\u064b]";
                            Regex r = new Regex(pattern);
                            Match match = r.Match(rtb1.Text[i].ToString());

                            if (match.Success)
                            {
                                if (i == 0)
                                {
                                    rtb1.Select(i, 2);
                                    rtb1.SelectionColor = System.Drawing.Color.Red;

                                }
                                else
                                {
                                    rtb1.Select(i-1, 2);
                                    rtb1.SelectionColor = System.Drawing.Color.Red;
                                }
                            }
                            else
                            {
                                rtb1.Select(i , 1);
                                rtb1.SelectionColor = System.Drawing.Color.Red;
                            }
                            //if (dict.ContainsKey(length - 1))
                            //    dict[length - 1]=1;
                            //else
                            //    dict.Add(length - 1, 1);
                        }
                        else if (rtb1.Text[i] == rtb2.Text[i])
                        {
                            string pattern = "[\u0623\u0625\u0626\u0621\u0624\u0622\u064b]";
                            Regex r = new Regex(pattern);
                            Match match = r.Match(rtb1.Text[i].ToString());

                            if (match.Success)
                            {
                                if (i == 0)
                                {
                                    rtb1.Select(i, 2);
                                    rtb1.SelectionColor = System.Drawing.Color.Green;

                                }
                                else
                                {
                                    rtb1.Select(i , 1);
                                    rtb1.SelectionColor = System.Drawing.Color.Green;
                                }
                            }
                            else
                            {
                                rtb1.Select(i , 1);
                                rtb1.SelectionColor = System.Drawing.Color.Green;
                            }

                            //if (dict.ContainsKey(length - 1))
                            //    dict[length - 1]=0;
                            //else
                            //    dict.Add(length - 1, 0);

                        }
                }

                

                if (rtb1.Text[length - 1] != rtb2.Text[length - 1])
                    {
                        string pattern = "[\u0623\u0625\u0626\u0621\u0624\u0622\u064b]";
                        Regex r = new Regex(pattern);
                        Match match = r.Match(rtb1.Text[length - 1].ToString());

                        if (match.Success)
                        {
                            if (length == 1)
                            {
                                rtb1.Select(length - 1, 2);
                                rtb1.SelectionColor = System.Drawing.Color.Red;

                            }
                            else
                            {
                                rtb1.Select(length -2, 2);
                                rtb1.SelectionColor = System.Drawing.Color.Red;
                            }
                        }
                        else
                        {
                            rtb1.Select(length - 1, 1);
                            rtb1.SelectionColor = System.Drawing.Color.Red;
                        }
                        //if (dict.ContainsKey(length - 1))
                        //    dict[length - 1]=1;
                        //else
                        //    dict.Add(length - 1, 1);
                    }
                    else if (rtb1.Text[length - 1] == rtb2.Text[length - 1])
                    {
                        string pattern = "[\u0623\u0625\u0626\u0621\u0624\u0622\u064b]";
                        Regex r = new Regex(pattern);
                        Match match = r.Match(rtb1.Text[length - 1].ToString());

                        if (match.Success)
                        {
                            if (length == 1)
                            {
                                rtb1.Select(length - 1, 2);
                                rtb1.SelectionColor = System.Drawing.Color.Green;

                            }
                            else
                            {
                                rtb1.Select(length - 1, 1);
                                rtb1.SelectionColor = System.Drawing.Color.Green;
                            }
                        }
                        else
                        {
                            rtb1.Select(length - 1, 1);
                            rtb1.SelectionColor = System.Drawing.Color.Green;
                        }

                        //if (dict.ContainsKey(length - 1))
                        //    dict[length - 1]=0;
                        //else
                        //    dict.Add(length - 1, 0);
                    }
                //MessageBox.Show(rtb2.Text.Length.ToString());

               
                txtLength = rtb2.Text.Length;

            }
            catch { return; }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        //    minute--;
        //    timeBar.Value = timeBar.Value - 10;
        //    if (timeBar.Value <= 25)
        //        timeBar.ForeColor = Color.Red;
        //    else if (timeBar.Value <= 50)
        //        timeBar.ForeColor = Color.Yellow;
        //    else if (timeBar.Value <= 75)
        //        timeBar.ForeColor = Color.YellowGreen;
        //    if (minute == 0)
        //    { rtb2.Enabled = false;
        //    if (rtb2.Text.Length > rtb1.Text.Length)
        //    {
        //        string str2 = rtb2.Text.Remove(rtb1.Text.Length, rtb2.Text.Length - rtb1.Text.Length);

        //        rtb2.Text = str2;

        //    }
        //    string[] numberOfWords = rtb2.Text.Split(' ');
        //    label1.Text = "عدد الكلمات: " + numberOfWords.Length;
        //    timer1.Enabled = false;
        //    timer2.Enabled = false;
        //    //foreach (int key in dict.Keys)
        //    //    if (dict[key] > 0)
        //    //        wrongs++;
        //    wrongs(rtb1.Text, rtb2.Text);

        //    label4.Text = "الاجمالي: " + (numberOfWords.Length - wordErrors.Count * 10);


           

        //    }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            rtb2.Focus();
            try
            {
                if (Directory.Exists("Papers"))
                {

                    string[] files = Directory.GetFiles("Papers");
                    int index = r.Next(0, files.Length);
                    StreamReader read = new StreamReader(files[index]);
                    string line = read.ReadLine();

                    while (line != null)
                    {
                        rtb1.Text = rtb1.Text + line;
                        line = read.ReadLine();
                    }
                    read.Close();
                    replace(rtb1.Text);
                }
                else
                {
                    Directory.CreateDirectory("Papers");
                    MessageBox.Show("We have created new Folder named Papers please put inside it paragraphs in text files",
                        "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            catch
            {

                return;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            sec--;
            label1.Text = minute.ToString("00") + " : "+ sec.ToString("00");
            if (sec == 0)
            { sec = 60;
                minute--;
                timeBar.Value = timeBar.Value - 10;
                if (timeBar.Value <= 25)
                    timeBar.ForeColor = Color.Red;
                else if (timeBar.Value <= 50)
                    timeBar.ForeColor = Color.Yellow;
                else if (timeBar.Value <= 75)
                    timeBar.ForeColor = Color.YellowGreen;
                if (minute == 0)
                {
                    rtb2.ReadOnly = true;
                    if (rtb2.Text.Length > rtb1.Text.Length)
                    {
                        string str2 = rtb2.Text.Remove(rtb1.Text.Length, rtb2.Text.Length - rtb1.Text.Length);

                        rtb2.Text = str2;

                    }
                    string[] numberOfWords = rtb2.Text.Split(' ');
                    label1.Text = "عدد الكلمات: " + numberOfWords.Length;
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    //foreach (int key in dict.Keys)
                    //    if (dict[key] > 0)
                    //        wrongs++;
                    wrongs(rtb1.Text, rtb2.Text);

                    label4.Text = "الاجمالي: " + (numberOfWords.Length - wordErrors.Count * 10);
                    if (numberOfWords.Length - wordErrors.Count * 10 >= 150)
                        rtb2.BackColor = Color.Green;
                    else
                        rtb2.BackColor = Color.Red;



                }
            }

        }

        private void timeBar_Click(object sender, EventArgs e)
        {

        }

        private void rtb2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.Handled = true;
           

        }

        private void timeBar_Click_1(object sender, EventArgs e)
        {

        }

        private void timeBar_CursorChanged(object sender, EventArgs e)
        {
            
        }

        private void rtb2_KeyPress(object sender, KeyPressEventArgs e)
        {
           

            
                rtb1.Select(rtb2.TextLength, 1);
                rtb1.SelectionColor = System.Drawing.Color.Black
                ;
           

        }
    }
}
