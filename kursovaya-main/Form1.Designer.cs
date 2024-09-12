
namespace WindowsFormsApp6
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.execute = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.load = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.RichTextBox();
            this.code = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.expr = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // execute
            // 
            this.execute.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.execute.Location = new System.Drawing.Point(831, 108);
            this.execute.Name = "execute";
            this.execute.Size = new System.Drawing.Size(153, 55);
            this.execute.TabIndex = 0;
            this.execute.Text = "Запустить";
            this.execute.UseVisualStyleBackColor = true;
            this.execute.Click += new System.EventHandler(this.execute_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // load
            // 
            this.load.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.load.Location = new System.Drawing.Point(831, 35);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(153, 55);
            this.load.TabIndex = 1;
            this.load.Text = "Загрузить";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(394, 35);
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.Size = new System.Drawing.Size(365, 560);
            this.result.TabIndex = 2;
            this.result.Text = "";
            // 
            // code
            // 
            this.code.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.code.Location = new System.Drawing.Point(12, 35);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(365, 561);
            this.code.TabIndex = 3;
            this.code.Text = "";
            this.code.TextChanged += new System.EventHandler(this.code_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Исходный код на языке C";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(390, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выходные данные";
            // 
            // expr
            // 
            this.expr.Location = new System.Drawing.Point(786, 220);
            this.expr.Name = "expr";
            this.expr.ReadOnly = true;
            this.expr.Size = new System.Drawing.Size(244, 375);
            this.expr.TabIndex = 6;
            this.expr.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(782, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Разбор сложных выражений";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 617);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.expr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.code);
            this.Controls.Add(this.result);
            this.Controls.Add(this.load);
            this.Controls.Add(this.execute);
            this.Name = "Form1";
            this.Text = "Транслятор с языка C";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button execute;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.RichTextBox result;
        private System.Windows.Forms.RichTextBox code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox expr;
        private System.Windows.Forms.Label label3;
    }
}

