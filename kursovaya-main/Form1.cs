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

namespace WindowsFormsApp6
{

    public partial class Form1 : Form
    {
        List<Token> value;
        public Form1()
        {
            InitializeComponent();
        }
        private void clear_fields()
        {
            result.Clear();
            expr.Clear();
        }
        private void execute_Click(object sender, EventArgs e)
        {
            clear_fields();
            string code = this.code.Text;

            try
            {
                LexicalAnalyzer analyzer = new LexicalAnalyzer();
                value = analyzer.Analyze(code);
                FillOutput(value);
                MessageBox.Show( $"Лекический разбор успешно завершен", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

                
            }
            catch (Exception ex)
            {
                ShowErrorDialog(ex, "лексическом анализаторе");
            }
            try
            {
                LR lR = new LR(value);
                lR.Run();
                MessageBox.Show($"Синтаксический разбор успешно завершен", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //SyntaxAnalyzer syntax = new SyntaxAnalyzer(value, expr);
                //syntax.Program();
                //MessageBox.Show($"Синтаксический разбор успешно завершен", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                ShowErrorDialog(ex, "синтаксическом анализаторе");
            }
            try
            {
                Bauer bauer = new Bauer(value);
                expr.Text = bauer.Info();
            }
            catch (Exception ex)
            {
                ShowErrorDialog(ex, "арифметическом анализаторе");
            }
        }

        private void FillOutput(List<Token> output)
        {
            for (int i = 0; i < output.Count; i++)
            {
                result.AppendText(output[i].ToString() + "\n");
            }
        }

        private static void ShowErrorDialog(Exception ex, string analyzer_type)
        {
            string errorMessage = $"Произошла ошибка:\n\n{ex.Message}";
            MessageBox.Show(errorMessage, $"Ошибка в {analyzer_type}", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void load_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Получаем путь к выбранному файлу
                    string filePath = openFileDialog.FileName;
                    string input_text = File.ReadAllText(filePath);
                    code.Text = input_text;
                }
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            execute.Enabled = false;
            
        }

        private void code_TextChanged(object sender, EventArgs e)
        {
            if(code.Text.Length > 0)
            {
                execute.Enabled = true;
            }
            else
            {
                execute.Enabled = false;
            }
        }
    }

}
