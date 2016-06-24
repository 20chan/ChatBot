using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatBot;

namespace ChatbotDebugger
{
    public partial class Form1 : Form
    {
        private CBR _cbr;
        private Pen _pen;

        public Form1()
        {
            InitializeComponent();
            _cbr = new CBR();
            _pen = new Pen(Color.Black);

            this.CreateGraphics().SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Init();
        }

        private void Init()
        {
            Add("what is your name", "My name is Roy.");
            Add("that is pretty name", "Thank you.");
            Add("what are you doing now", "I'm thinking of you.");
            //Add("do you know 1+1", "Don't test me.");
        }

        private void Add(string A, string B)
        {
            _cbr.AddEnglishConversation(A, B);
        }

        int unit_x = 80, unit_y = 150, gap_y = 50;
        int unitWidth = 30, unitHeight = 30;

        int l_unit_x = 500;

        private void Visualize()
        {
            this.CreateGraphics().Clear(this.BackColor);

            int y = unit_y;
            foreach (string s in _cbr.Table.table.Keys)
            {
                DrawUnit(unit_x, y, s);
                foreach(int i in _cbr.Table.table[s])
                {
                    int index = 1 + _cbr.Table.corpuses.IndexOf(_cbr.Table.corpuses[i]);
                    DrawSynaps(unit_x, y, l_unit_x, unit_y * index, _cbr.Table.corpuses[i].RWeight);
                    DrawUnit(l_unit_x, unit_y * index, _cbr.Table.corpuses[i].Sentence);
                }
                y += gap_y;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = _cbr.Eval(textBox1.Text, Parser.ParseEnglish(textBox1.Text));
            button1_Click(null, null);
            textBox1.Clear();
            textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button2_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visualize();
        }

        private void DrawUnit(int x, int y, string text)
        {
            this.CreateGraphics().DrawEllipse(_pen, x - unitWidth * 0.5f, y - unitHeight * 0.5f, unitWidth, unitHeight);
            this.CreateGraphics().DrawString(text, this.Font, Brushes.Black, x-20, y-15);
        }

        private void DrawSynaps(int fx, int fy, int tx, int ty, int r_weight)
        {
            this.CreateGraphics().DrawLine(_pen, fx, fy, tx, ty);
            this.CreateGraphics().DrawString("1/" + r_weight.ToString(), this.Font, Brushes.Black, (fx + tx) / 2, (fy + ty) / 2 - 10);
        }
    }
}
