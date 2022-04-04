using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixSubstitution
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            languageComboBox.Items.Add("Български");
            languageComboBox.Items.Add("Английски");
            languageComboBox.SelectedItem = "Български";

            actionComboBox.Items.Add("Шифроване");
            actionComboBox.Items.Add("Дешифриране");
            actionComboBox.SelectedItem = "Шифроване";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            messageTextBox.Text = messageTextBox.Text.ToLower();
            keyTextBox.Text = keyTextBox.Text.ToLower();
            resultTextBox.Text = "";

            char[] offset = new char[keyTextBox.Text.Length];

            for (int i = 0; i < offset.Length; i++)
            {
                offset[i] = (char)(keyTextBox.Text[i] - (languageComboBox.SelectedItem.ToString() == "Български" ? 'а' : 'a'));
            }

            if (actionComboBox.SelectedItem.ToString() == "Шифроване")
            {
                for (int i = 0; i < messageTextBox.Text.Length; i++)
                {
                    resultTextBox.Text += (char)((messageTextBox.Text[i] + offset[i % keyTextBox.Text.Length]) <= (languageComboBox.SelectedItem.ToString() == "Български" ? 1103 : 122) ?
                        (messageTextBox.Text[i] + offset[i % keyTextBox.Text.Length]) :
                        (messageTextBox.Text[i] + offset[i % keyTextBox.Text.Length]) - (languageComboBox.SelectedItem.ToString() == "Български" ? 32 : 26));
                }
            }
            else
                for (int i = 0; i < messageTextBox.Text.Length; i++)
                {
                    resultTextBox.Text += (char)((messageTextBox.Text[i] - offset[i % keyTextBox.Text.Length]) >= (languageComboBox.SelectedItem.ToString() == "Български" ? 1072 : 97) ?
                        (messageTextBox.Text[i] - offset[i % keyTextBox.Text.Length]) :
                        (messageTextBox.Text[i] - offset[i % keyTextBox.Text.Length]) + (languageComboBox.SelectedItem.ToString() == "Български" ? 32 : 26));
                    if ((messageTextBox.Text[i] < 97 || messageTextBox.Text[i] > 122 && messageTextBox.Text[i]<1072 || messageTextBox.Text[i]>1103)&&resultTextBox.Text[i]!=' ')
                    {
                        resultTextBox.Text = resultTextBox.Text.Remove(i, 1);
                        resultTextBox.Text += ' ';
                    }
                }
            }

        private void actionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Text = actionComboBox.SelectedItem.ToString();

            if (actionComboBox.SelectedItem.ToString() == "Шифроване")
            {
                actionLabel.Text = "Въведете явен текст:";
                resultLabel.Text = "Криптограма:";
            }
            else
            {
                actionLabel.Text = "Въведете криптограма:";
                resultLabel.Text = "Явен текст:";
            }
        }

        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (languageComboBox.SelectedItem.ToString() == "Български")
            {
                allowedSymbolsLabel.Text = "Позволено символно множество: А - Я, интервал";
            }
            else
            {
                allowedSymbolsLabel.Text = "Позволено символно множество: A - Z, интервал";
            }
        }
    }
    }
