namespace Analyzer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.inputTitle = new System.Windows.Forms.Label();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.infoButton = new System.Windows.Forms.Button();
            this.resultTitle = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.variableListView = new System.Windows.Forms.ListView();
            this.constantListView = new System.Windows.Forms.ListView();
            this.variableTitle = new System.Windows.Forms.Label();
            this.constantTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputTextBox.BackColor = System.Drawing.Color.White;
            this.inputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputTextBox.Location = new System.Drawing.Point(9, 72);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(1061, 30);
            this.inputTextBox.TabIndex = 0;
            // 
            // analyzeButton
            // 
            this.analyzeButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.analyzeButton.BackColor = System.Drawing.Color.White;
            this.analyzeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.analyzeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.analyzeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.analyzeButton.Location = new System.Drawing.Point(6, 226);
            this.analyzeButton.Margin = new System.Windows.Forms.Padding(2);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(121, 37);
            this.analyzeButton.TabIndex = 2;
            this.analyzeButton.Text = "Анализ";
            this.analyzeButton.UseVisualStyleBackColor = false;
            this.analyzeButton.Click += new System.EventHandler(this.analyzeButton_Click);
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.title.BackColor = System.Drawing.Color.Gray;
            this.title.Font = new System.Drawing.Font("Palatino Linotype", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(1079, 37);
            this.title.TabIndex = 3;
            this.title.Text = "Анализатор оператора Case Of языка Turbo Pascal";
            this.title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // inputTitle
            // 
            this.inputTitle.AutoSize = true;
            this.inputTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputTitle.Location = new System.Drawing.Point(9, 46);
            this.inputTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.inputTitle.Name = "inputTitle";
            this.inputTitle.Size = new System.Drawing.Size(267, 24);
            this.inputTitle.TabIndex = 4;
            this.inputTitle.Text = "Введите строку для анализа";
            // 
            // resultTextBox
            // 
            this.resultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultTextBox.BackColor = System.Drawing.Color.White;
            this.resultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultTextBox.Location = new System.Drawing.Point(9, 147);
            this.resultTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.ReadOnly = true;
            this.resultTextBox.Size = new System.Drawing.Size(1061, 30);
            this.resultTextBox.TabIndex = 5;
            // 
            // infoButton
            // 
            this.infoButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.infoButton.BackColor = System.Drawing.Color.White;
            this.infoButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.infoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.infoButton.Location = new System.Drawing.Point(6, 343);
            this.infoButton.Margin = new System.Windows.Forms.Padding(2);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(120, 37);
            this.infoButton.TabIndex = 6;
            this.infoButton.Text = "Справка";
            this.infoButton.UseVisualStyleBackColor = false;
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // resultTitle
            // 
            this.resultTitle.AutoSize = true;
            this.resultTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultTitle.Location = new System.Drawing.Point(9, 121);
            this.resultTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resultTitle.Name = "resultTitle";
            this.resultTitle.Size = new System.Drawing.Size(180, 24);
            this.resultTitle.TabIndex = 7;
            this.resultTitle.Text = "Результат анализа";
            // 
            // clearButton
            // 
            this.clearButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.clearButton.BackColor = System.Drawing.Color.White;
            this.clearButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearButton.Location = new System.Drawing.Point(6, 285);
            this.clearButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(121, 37);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Очистить строки";
            this.clearButton.UseVisualStyleBackColor = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // variableListView
            // 
            this.variableListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.variableListView.BackColor = System.Drawing.Color.White;
            this.variableListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.variableListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F);
            this.variableListView.HideSelection = false;
            this.variableListView.Location = new System.Drawing.Point(141, 223);
            this.variableListView.Margin = new System.Windows.Forms.Padding(2);
            this.variableListView.Name = "variableListView";
            this.variableListView.Size = new System.Drawing.Size(368, 361);
            this.variableListView.TabIndex = 9;
            this.variableListView.UseCompatibleStateImageBehavior = false;
            this.variableListView.View = System.Windows.Forms.View.List;
            // 
            // constantListView
            // 
            this.constantListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.constantListView.BackColor = System.Drawing.Color.White;
            this.constantListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.constantListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F);
            this.constantListView.HideSelection = false;
            this.constantListView.Location = new System.Drawing.Point(513, 223);
            this.constantListView.Margin = new System.Windows.Forms.Padding(2);
            this.constantListView.Name = "constantListView";
            this.constantListView.Size = new System.Drawing.Size(557, 364);
            this.constantListView.TabIndex = 10;
            this.constantListView.UseCompatibleStateImageBehavior = false;
            this.constantListView.View = System.Windows.Forms.View.List;
            // 
            // variableTitle
            // 
            this.variableTitle.AutoSize = true;
            this.variableTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.variableTitle.Location = new System.Drawing.Point(248, 197);
            this.variableTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.variableTitle.Name = "variableTitle";
            this.variableTitle.Size = new System.Drawing.Size(193, 24);
            this.variableTitle.TabIndex = 11;
            this.variableTitle.Text = "Список переменных";
            // 
            // constantTitle
            // 
            this.constantTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.constantTitle.AutoSize = true;
            this.constantTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.constantTitle.Location = new System.Drawing.Point(756, 197);
            this.constantTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.constantTitle.Name = "constantTitle";
            this.constantTitle.Size = new System.Drawing.Size(162, 24);
            this.constantTitle.TabIndex = 12;
            this.constantTitle.Text = "Список констант";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1079, 597);
            this.Controls.Add(this.constantTitle);
            this.Controls.Add(this.variableTitle);
            this.Controls.Add(this.constantListView);
            this.Controls.Add(this.variableListView);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.resultTitle);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.inputTitle);
            this.Controls.Add(this.title);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(this.inputTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Analyzer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label inputTitle;
        private System.Windows.Forms.TextBox resultTextBox;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.Label resultTitle;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ListView variableListView;
        private System.Windows.Forms.ListView constantListView;
        private System.Windows.Forms.Label variableTitle;
        private System.Windows.Forms.Label constantTitle;
    }
}

