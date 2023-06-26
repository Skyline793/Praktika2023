namespace Praktika2023
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.stopButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numOfShelvesLabel = new System.Windows.Forms.Label();
            this.cashierSpeedLabel = new System.Windows.Forms.Label();
            this.numOfCashDesksLabel = new System.Windows.Forms.Label();
            this.cashierSpeedComboBox = new System.Windows.Forms.ComboBox();
            this.numOfShelvesComboBox = new System.Windows.Forms.ComboBox();
            this.numOfCashDeskComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RepeatButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.num_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerNumColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalIncomeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.averageCheckColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.startButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(5, 27);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 550);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 2000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(414, 583);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(111, 57);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Стоп";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.startButton);
            this.groupBox1.Controls.Add(this.numOfShelvesLabel);
            this.groupBox1.Controls.Add(this.cashierSpeedLabel);
            this.groupBox1.Controls.Add(this.numOfCashDesksLabel);
            this.groupBox1.Controls.Add(this.cashierSpeedComboBox);
            this.groupBox1.Controls.Add(this.numOfShelvesComboBox);
            this.groupBox1.Controls.Add(this.numOfCashDeskComboBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(269, 94);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(482, 377);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Начальные параметры";
            // 
            // numOfShelvesLabel
            // 
            this.numOfShelvesLabel.AutoSize = true;
            this.numOfShelvesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfShelvesLabel.Location = new System.Drawing.Point(24, 125);
            this.numOfShelvesLabel.Name = "numOfShelvesLabel";
            this.numOfShelvesLabel.Size = new System.Drawing.Size(317, 20);
            this.numOfShelvesLabel.TabIndex = 5;
            this.numOfShelvesLabel.Text = "Выберите количество полок с товарами\r\n";
            // 
            // cashierSpeedLabel
            // 
            this.cashierSpeedLabel.AutoSize = true;
            this.cashierSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cashierSpeedLabel.Location = new System.Drawing.Point(24, 205);
            this.cashierSpeedLabel.Name = "cashierSpeedLabel";
            this.cashierSpeedLabel.Size = new System.Drawing.Size(436, 20);
            this.cashierSpeedLabel.TabIndex = 4;
            this.cashierSpeedLabel.Text = "Выберите скорость сканирования товара (сек на товар)\r\n";
            // 
            // numOfCashDesksLabel
            // 
            this.numOfCashDesksLabel.AutoSize = true;
            this.numOfCashDesksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfCashDesksLabel.Location = new System.Drawing.Point(24, 43);
            this.numOfCashDesksLabel.Name = "numOfCashDesksLabel";
            this.numOfCashDesksLabel.Size = new System.Drawing.Size(303, 20);
            this.numOfCashDesksLabel.TabIndex = 3;
            this.numOfCashDesksLabel.Text = "Выберите количество касс в магазине";
            // 
            // cashierSpeedComboBox
            // 
            this.cashierSpeedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cashierSpeedComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cashierSpeedComboBox.FormattingEnabled = true;
            this.cashierSpeedComboBox.Items.AddRange(new object[] {
            "1",
            "1,5",
            "2",
            "2,5",
            "3"});
            this.cashierSpeedComboBox.Location = new System.Drawing.Point(28, 241);
            this.cashierSpeedComboBox.Name = "cashierSpeedComboBox";
            this.cashierSpeedComboBox.Size = new System.Drawing.Size(124, 32);
            this.cashierSpeedComboBox.TabIndex = 2;
            // 
            // numOfShelvesComboBox
            // 
            this.numOfShelvesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numOfShelvesComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfShelvesComboBox.FormattingEnabled = true;
            this.numOfShelvesComboBox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.numOfShelvesComboBox.Location = new System.Drawing.Point(28, 161);
            this.numOfShelvesComboBox.Name = "numOfShelvesComboBox";
            this.numOfShelvesComboBox.Size = new System.Drawing.Size(124, 32);
            this.numOfShelvesComboBox.TabIndex = 1;
            // 
            // numOfCashDeskComboBox
            // 
            this.numOfCashDeskComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numOfCashDeskComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfCashDeskComboBox.FormattingEnabled = true;
            this.numOfCashDeskComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.numOfCashDeskComboBox.Location = new System.Drawing.Point(28, 80);
            this.numOfCashDeskComboBox.Name = "numOfCashDeskComboBox";
            this.numOfCashDeskComboBox.Size = new System.Drawing.Size(124, 32);
            this.numOfCashDeskComboBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Controls.Add(this.RepeatButton);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(37, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(905, 645);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Результаты симуляций";
            // 
            // RepeatButton
            // 
            this.RepeatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RepeatButton.Location = new System.Drawing.Point(752, 586);
            this.RepeatButton.Name = "RepeatButton";
            this.RepeatButton.Size = new System.Drawing.Size(147, 39);
            this.RepeatButton.TabIndex = 1;
            this.RepeatButton.Text = "Начать заново";
            this.RepeatButton.UseVisualStyleBackColor = true;
            this.RepeatButton.Click += new System.EventHandler(this.RepeatButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num_column,
            this.timeColumn,
            this.Column1,
            this.Column2,
            this.customerNumColumn,
            this.totalIncomeColumn,
            this.averageCheckColumn});
            this.dataGridView1.Location = new System.Drawing.Point(3, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(896, 555);
            this.dataGridView1.TabIndex = 0;
            // 
            // num_column
            // 
            this.num_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.num_column.HeaderText = "№";
            this.num_column.Name = "num_column";
            this.num_column.ReadOnly = true;
            this.num_column.Width = 47;
            // 
            // timeColumn
            // 
            this.timeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.timeColumn.HeaderText = "Время работы";
            this.timeColumn.Name = "timeColumn";
            this.timeColumn.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Число касс/полок";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Скорость сканирования, сек. на товар";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // customerNumColumn
            // 
            this.customerNumColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.customerNumColumn.HeaderText = "Всего покупателей";
            this.customerNumColumn.Name = "customerNumColumn";
            this.customerNumColumn.ReadOnly = true;
            // 
            // totalIncomeColumn
            // 
            this.totalIncomeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.totalIncomeColumn.HeaderText = "Общий доход, руб.";
            this.totalIncomeColumn.Name = "totalIncomeColumn";
            this.totalIncomeColumn.ReadOnly = true;
            // 
            // averageCheckColumn
            // 
            this.averageCheckColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.averageCheckColumn.HeaderText = "Средний чек, руб.";
            this.averageCheckColumn.Name = "averageCheckColumn";
            this.averageCheckColumn.ReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.ItemSize = new System.Drawing.Size(2, 3);
            this.tabControl1.Location = new System.Drawing.Point(-1, -5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1069, 717);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 7);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1061, 706);
            this.tabPage1.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(180, 316);
            this.startButton.Margin = new System.Windows.Forms.Padding(2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(111, 57);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Начать";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 7);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1061, 698);
            this.tabPage2.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 7);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1061, 698);
            this.tabPage3.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Controls.Add(this.stopButton);
            this.groupBox3.Controls.Add(this.pictureBox1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(75, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(914, 645);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Симуляция";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1068, 708);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Симулятор работы магазина";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox numOfCashDeskComboBox;
        private System.Windows.Forms.ComboBox numOfShelvesComboBox;
        private System.Windows.Forms.ComboBox cashierSpeedComboBox;
        private System.Windows.Forms.Label numOfCashDesksLabel;
        private System.Windows.Forms.Label numOfShelvesLabel;
        private System.Windows.Forms.Label cashierSpeedLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNumColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalIncomeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn averageCheckColumn;
        private System.Windows.Forms.Button RepeatButton;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}