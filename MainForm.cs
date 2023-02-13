using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Analyzer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void analyzeButton_Click(object sender, EventArgs e)
        {   
            variableListView.Clear();
            constantListView.Clear();
            try
            {
                StringParser sp = new StringParser(inputTextBox.Text);
                sp.ParseString();
                variableListView.Items.AddRange(sp.variables.Select(x => new ListViewItem(x.ToString())).ToArray());
                constantListView.Items.AddRange(sp.constants.Select(x => new ListViewItem(x.ToString())).ToArray());
                resultTextBox.Text = "Строка принадлежит языку";
            }
            catch (KeyNotFoundException ex)
            {
                resultTextBox.Text = ex.Message;
            }
            catch (ArgumentException ex)
            {
                HighlightErrorSymbol(StringParser.pos, 1);
                resultTextBox.Text = ex.Message;
            }
            catch (FormatException ex)
            {
                HighlightErrorSymbol(StringParser.pos, 1);
                resultTextBox.Text = ex.Message;
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Идентификатор языка Turbo Pascal, начинается с буквы или знака подчеркивания, далее " +
                            "могут следовать буквы, цифры и знаки подчеркивания.\n Ограничения:\n" +
                            "– имеет длину не более 8 символов;\n" +
                            "– не является зарезервированным словом: case, of, else, end, div, mod.\n Целые числа в диапазоне - 32768 – 32767.");
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            inputTextBox.Text = String.Empty;
            resultTextBox.Text = String.Empty;
            variableListView.Clear();
            constantListView.Clear();

        }

        private void HighlightErrorSymbol(int i, int errorLength)
        {
            errorLength = 0;
            inputTextBox.SelectionStart = i - errorLength;

            inputTextBox.SelectionLength = errorLength;// - (errorLength == 1 ? 0 : 1);
            inputTextBox.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
