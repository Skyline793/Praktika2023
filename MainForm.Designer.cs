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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ResultsButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maxFrequencyLabel = new System.Windows.Forms.Label();
            this.maxFrequencytrackBar = new System.Windows.Forms.TrackBar();
            this.minFrequencyLabel = new System.Windows.Forms.Label();
            this.minFrequencytrackBar = new System.Windows.Forms.TrackBar();
            this.startButton = new System.Windows.Forms.Button();
            this.numOfShelvesLabel = new System.Windows.Forms.Label();
            this.cashierSpeedLabel = new System.Windows.Forms.Label();
            this.numOfCashDesksLabel = new System.Windows.Forms.Label();
            this.cashierSpeedComboBox = new System.Windows.Forms.ComboBox();
            this.numOfShelvesComboBox = new System.Windows.Forms.ComboBox();
            this.numOfCashDeskComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Resumebutton = new System.Windows.Forms.Button();
            this.Pausebutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.stopButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxFrequencytrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minFrequencytrackBar)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // RepeatButton
            // 
            this.RepeatButton.BackColor = System.Drawing.Color.LightGreen;
            this.RepeatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RepeatButton.Location = new System.Drawing.Point(1084, 806);
            this.RepeatButton.Name = "RepeatButton";
            this.RepeatButton.Size = new System.Drawing.Size(173, 41);
            this.RepeatButton.TabIndex = 1;
            this.RepeatButton.Text = "Начать заново";
            this.RepeatButton.UseVisualStyleBackColor = false;
            this.RepeatButton.Click += new System.EventHandler(this.RepeatButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LightGreen;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num_column,
            this.timeColumn,
            this.Column1,
            this.Column2,
            this.customerNumColumn,
            this.totalIncomeColumn,
            this.averageCheckColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(9, 36);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1248, 764);
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
            this.customerNumColumn.HeaderText = "Обслужено покупателей";
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
            this.tabControl1.Size = new System.Drawing.Size(1273, 867);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Controls.Add(this.RepeatButton);
            this.tabPage3.Location = new System.Drawing.Point(4, 7);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1265, 856);
            this.tabPage3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(480, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Результаты симуляций";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.BackgroundImage = global::Praktika2023.Properties.Resources.fon1;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.ResultsButton);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 7);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1265, 856);
            this.tabPage1.TabIndex = 0;
            // 
            // ResultsButton
            // 
            this.ResultsButton.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ResultsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultsButton.Location = new System.Drawing.Point(1052, 794);
            this.ResultsButton.Margin = new System.Windows.Forms.Padding(2);
            this.ResultsButton.Name = "ResultsButton";
            this.ResultsButton.Size = new System.Drawing.Size(208, 57);
            this.ResultsButton.TabIndex = 10;
            this.ResultsButton.Text = "Смотреть результаты симуляций";
            this.ResultsButton.UseVisualStyleBackColor = false;
            this.ResultsButton.Click += new System.EventHandler(this.ResultsButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Linen;
            this.groupBox1.Controls.Add(this.maxFrequencyLabel);
            this.groupBox1.Controls.Add(this.maxFrequencytrackBar);
            this.groupBox1.Controls.Add(this.minFrequencyLabel);
            this.groupBox1.Controls.Add(this.minFrequencytrackBar);
            this.groupBox1.Controls.Add(this.startButton);
            this.groupBox1.Controls.Add(this.numOfShelvesLabel);
            this.groupBox1.Controls.Add(this.cashierSpeedLabel);
            this.groupBox1.Controls.Add(this.numOfCashDesksLabel);
            this.groupBox1.Controls.Add(this.cashierSpeedComboBox);
            this.groupBox1.Controls.Add(this.numOfShelvesComboBox);
            this.groupBox1.Controls.Add(this.numOfCashDeskComboBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(348, 183);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(598, 588);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Начальные параметры";
            // 
            // maxFrequencyLabel
            // 
            this.maxFrequencyLabel.AutoSize = true;
            this.maxFrequencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maxFrequencyLabel.Location = new System.Drawing.Point(5, 396);
            this.maxFrequencyLabel.Name = "maxFrequencyLabel";
            this.maxFrequencyLabel.Size = new System.Drawing.Size(567, 20);
            this.maxFrequencyLabel.TabIndex = 9;
            this.maxFrequencyLabel.Text = "Выберите минимальную границу частоты появления нового покупателя: ";
            // 
            // maxFrequencytrackBar
            // 
            this.maxFrequencytrackBar.Location = new System.Drawing.Point(142, 448);
            this.maxFrequencytrackBar.Maximum = 9;
            this.maxFrequencytrackBar.Minimum = 1;
            this.maxFrequencytrackBar.Name = "maxFrequencytrackBar";
            this.maxFrequencytrackBar.Size = new System.Drawing.Size(283, 45);
            this.maxFrequencytrackBar.TabIndex = 8;
            this.maxFrequencytrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.maxFrequencytrackBar.Value = 1;
            this.maxFrequencytrackBar.Scroll += new System.EventHandler(this.maxFrequencytrackBar_Scroll);
            // 
            // minFrequencyLabel
            // 
            this.minFrequencyLabel.AutoSize = true;
            this.minFrequencyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minFrequencyLabel.Location = new System.Drawing.Point(5, 297);
            this.minFrequencyLabel.Name = "minFrequencyLabel";
            this.minFrequencyLabel.Size = new System.Drawing.Size(567, 20);
            this.minFrequencyLabel.TabIndex = 7;
            this.minFrequencyLabel.Text = "Выберите минимальную границу частоты появления нового покупателя: ";
            // 
            // minFrequencytrackBar
            // 
            this.minFrequencytrackBar.Location = new System.Drawing.Point(142, 338);
            this.minFrequencytrackBar.Minimum = 1;
            this.minFrequencytrackBar.Name = "minFrequencytrackBar";
            this.minFrequencytrackBar.Size = new System.Drawing.Size(283, 45);
            this.minFrequencytrackBar.TabIndex = 6;
            this.minFrequencytrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.minFrequencytrackBar.Value = 1;
            this.minFrequencytrackBar.Scroll += new System.EventHandler(this.minFrequencytrackBar_Scroll);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.startButton.Location = new System.Drawing.Point(171, 527);
            this.startButton.Margin = new System.Windows.Forms.Padding(2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(242, 57);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Запустить симуляцию";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // numOfShelvesLabel
            // 
            this.numOfShelvesLabel.AutoSize = true;
            this.numOfShelvesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfShelvesLabel.Location = new System.Drawing.Point(135, 125);
            this.numOfShelvesLabel.Name = "numOfShelvesLabel";
            this.numOfShelvesLabel.Size = new System.Drawing.Size(317, 20);
            this.numOfShelvesLabel.TabIndex = 5;
            this.numOfShelvesLabel.Text = "Выберите количество полок с товарами\r\n";
            // 
            // cashierSpeedLabel
            // 
            this.cashierSpeedLabel.AutoSize = true;
            this.cashierSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cashierSpeedLabel.Location = new System.Drawing.Point(88, 205);
            this.cashierSpeedLabel.Name = "cashierSpeedLabel";
            this.cashierSpeedLabel.Size = new System.Drawing.Size(436, 20);
            this.cashierSpeedLabel.TabIndex = 4;
            this.cashierSpeedLabel.Text = "Выберите скорость сканирования товара (сек на товар)\r\n";
            // 
            // numOfCashDesksLabel
            // 
            this.numOfCashDesksLabel.AutoSize = true;
            this.numOfCashDesksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfCashDesksLabel.Location = new System.Drawing.Point(138, 43);
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
            this.cashierSpeedComboBox.Location = new System.Drawing.Point(230, 242);
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
            this.numOfShelvesComboBox.Location = new System.Drawing.Point(230, 160);
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
            this.numOfCashDeskComboBox.Location = new System.Drawing.Point(230, 79);
            this.numOfCashDeskComboBox.Name = "numOfCashDeskComboBox";
            this.numOfCashDeskComboBox.Size = new System.Drawing.Size(124, 32);
            this.numOfCashDeskComboBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tabPage2.BackgroundImage = global::Praktika2023.Properties.Resources.fon;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.Resumebutton);
            this.tabPage2.Controls.Add(this.Pausebutton);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.stopButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 7);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1265, 856);
            this.tabPage2.TabIndex = 1;
            // 
            // Resumebutton
            // 
            this.Resumebutton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Resumebutton.Enabled = false;
            this.Resumebutton.Image = global::Praktika2023.Properties.Resources.start;
            this.Resumebutton.Location = new System.Drawing.Point(559, 803);
            this.Resumebutton.Name = "Resumebutton";
            this.Resumebutton.Size = new System.Drawing.Size(50, 50);
            this.Resumebutton.TabIndex = 5;
            this.Resumebutton.UseVisualStyleBackColor = false;
            this.Resumebutton.Click += new System.EventHandler(this.Resumebutton_Click);
            // 
            // Pausebutton
            // 
            this.Pausebutton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Pausebutton.Image = global::Praktika2023.Properties.Resources.pause1;
            this.Pausebutton.Location = new System.Drawing.Point(615, 803);
            this.Pausebutton.Name = "Pausebutton";
            this.Pausebutton.Size = new System.Drawing.Size(50, 50);
            this.Pausebutton.TabIndex = 4;
            this.Pausebutton.UseVisualStyleBackColor = false;
            this.Pausebutton.Click += new System.EventHandler(this.Pausebutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(554, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Симуляция";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(8, 38);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1250, 750);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.stopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stopButton.Image = global::Praktika2023.Properties.Resources.stop;
            this.stopButton.Location = new System.Drawing.Point(670, 803);
            this.stopButton.Margin = new System.Windows.Forms.Padding(2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(50, 50);
            this.stopButton.TabIndex = 2;
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1272, 861);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1288, 900);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1288, 844);
            this.Name = "MainForm";
            this.Text = "Симулятор работы магазина";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxFrequencytrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minFrequencytrackBar)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox numOfCashDeskComboBox;
        private System.Windows.Forms.ComboBox numOfShelvesComboBox;
        private System.Windows.Forms.ComboBox cashierSpeedComboBox;
        private System.Windows.Forms.Label numOfCashDesksLabel;
        private System.Windows.Forms.Label numOfShelvesLabel;
        private System.Windows.Forms.Label cashierSpeedLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button RepeatButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn num_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerNumColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalIncomeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn averageCheckColumn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar minFrequencytrackBar;
        private System.Windows.Forms.Label minFrequencyLabel;
        private System.Windows.Forms.Label maxFrequencyLabel;
        private System.Windows.Forms.TrackBar maxFrequencytrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ResultsButton;
        private System.Windows.Forms.Button Resumebutton;
        private System.Windows.Forms.Button Pausebutton;
    }
}