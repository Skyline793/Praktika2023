using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace Praktika2023
{
    /// <summary>главного окна приложения</summary>
    public partial class MainForm : Form
    {
        /// <summary>Коэффициент масштаба при отрисовке</summary>
        public static int DXY = 7;
        /// <summary>Объект класса Супермаркет</summary>
        private Supermarket supermarket;
        /// <summary>Флаг паузы симуляции</summary>
        public bool simulationPaused;
        /// <summary>Число касс</summary>
        private int numOfCashDesks;
        /// <summary>Число полок</summary>
        private int numOfShelves;
        /// <summary>Счетчик симуляций</summary>
        private int simulationCount;
        /// <summary>Скорость сканирования одного товара</summary>
        private int cashiersSpeed;
        /// <summary>Прямоугольники, соответствующие входу, выходу и двери к складу</summary>
        private Rectangle entrance, exit, warehouse;
        /// <summary>Секундомер</summary>
        Stopwatch stopwatch;

        //Конструктор формы
        public MainForm()
        {
            InitializeComponent();
            this.exit = new Rectangle(this.pictureBox1.Width / 2 - MainForm.DXY * 15, -MainForm.DXY * 5, MainForm.DXY * 30, MainForm.DXY * 10);
            this.entrance = new Rectangle(this.pictureBox1.Width / 2 - MainForm.DXY * 15, this.pictureBox1.Height - MainForm.DXY * 10, MainForm.DXY * 30, MainForm.DXY * 20);
            this.warehouse = new Rectangle(this.pictureBox1.Width / 4, this.pictureBox1.Height - MainForm.DXY * 2, MainForm.DXY * 10, MainForm.DXY * 2);
            this.stopwatch = new Stopwatch();
            this.simulationCount = 0;
            this.numOfCashDeskComboBox.SelectedIndex = 0;
            this.numOfShelvesComboBox.SelectedIndex = 0;
            this.cashierSpeedComboBox.SelectedIndex = 0;
            this.tabControl1.SelectedIndex = 0;
            this.minFrequencyLabel.Text = String.Format("Выберите минимальную частоту появления нового покупателя: {0} c", minFrequencytrackBar.Value);
            this.maxFrequencyLabel.Text = String.Format("Выберите максимальную частоту появления нового покупателя: {0} c", maxFrequencytrackBar.Value);
            this.minFrequencytrackBar.Minimum = minFrequencytrackBar.Value;
            this.maxFrequencytrackBar.Maximum += minFrequencytrackBar.Value;
        }

        //Обработчик события Paint у picturebox, на котром рисуется симуляция
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (supermarket == null) return;
            foreach (Customer customer in supermarket.Customers) //отрисовка покупателей
                e.Graphics.FillEllipse(new SolidBrush(customer.Color), customer.Body);
            foreach (Cashier cashier in supermarket.Cashiers) //отрисовка кассиров
                e.Graphics.FillEllipse(new SolidBrush(cashier.Color), cashier.Body);
            foreach (CashDesk desk in supermarket.Desks) //отрисовка касс
                e.Graphics.FillRectangle(new SolidBrush(desk.Color), desk.Form);
            foreach (ProductShelf shelf in supermarket.Shelves) //отрисовка полок
                e.Graphics.FillRectangle(new SolidBrush(shelf.Color), shelf.Form);
            e.Graphics.FillEllipse(new SolidBrush(supermarket.Manager.Color), supermarket.Manager.Body); //отрисовка менеджера
            e.Graphics.FillPie(new SolidBrush(Color.SlateGray), entrance, 180, 180); //отрисовка входа
            e.Graphics.FillRectangle(new SolidBrush(Color.SlateGray), exit); //отрисовка выхода
            e.Graphics.DrawString("ВХОД", new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold), new SolidBrush(Color.LightGreen), this.pictureBox1.Width / 2 - MainForm.DXY * 5, entrance.Top + MainForm.DXY * 5);
            e.Graphics.DrawString("ВЫХОД", new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold), new SolidBrush(Color.LightGreen), exit.Left + exit.Width / 2 - MainForm.DXY * 6, exit.Bottom - exit.Height / 2 + MainForm.DXY);
            e.Graphics.FillRectangle(new SolidBrush((Color.Black)), warehouse); //отрисовка двери на склад
        }

        //тик первого таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.pictureBox1.Invalidate(); //перерисовать сцену
            this.supermarket.PickingUp(); //метод выбора товаров у полок
            this.supermarket.Shoppings(); //метод оплаты товаров у касс
            this.supermarket.TopUpTheShelves(); //метод пополнения запасов полок
            if (this.supermarket.IsOverFull()) //если магазин переполнен
            {
                stopButton_Click(sender, e); //завершаем симуляцию
                MessageBox.Show("Ой-ой, кажется, магазин оказался перегружен! На этом симуляцию придется остановить. Попробуйте снова c другими параметрами!", "Магазин переполнен!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //тик второго таймера
        private void timer2_Tick(object sender, EventArgs e)
        {
            //удаляем из списка покупателей тех, кто ушел
            this.supermarket.Customers.RemoveAll(x =>x.Status==CustomerStatus.exited);
            this.timer2.Interval = Randomizer.Rand(this.maxFrequencytrackBar.Value, this.maxFrequencytrackBar.Value) * 1000; //изменяем интервал таймера
            this.supermarket.AddCustomer(); //добавляем покупателя в магазин
        }

        //Нажатие на кнопку начать симуляцию
        private void startButton_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1; //переключаемся на вкладку с симуляцией
            numOfCashDesks = Convert.ToInt32(this.numOfCashDeskComboBox.SelectedItem);
            cashiersSpeed = (int)(Convert.ToDouble(this.cashierSpeedComboBox.SelectedItem) * 1000);
            numOfShelves = Convert.ToInt32(this.numOfShelvesComboBox.SelectedItem);
            timer2.Interval = 10000;
            supermarket = new Supermarket(numOfCashDesks, numOfShelves, cashiersSpeed, pictureBox1.Size, warehouse, entrance, exit); //инициализируем объект супермаркет
            stopwatch.Start(); //запускаем секундомер
            timer1.Start(); //запускаем первый таймер
            timer2.Start(); //запускаем второй таймер
            simulationPaused = false;
            simulationCount++;
            //выводим информационные подсказки
            new ToolTip().Show("Это касса\nКликните по ней, чтобы узнать\nколичество обслуженных покупателей\nи собранную сумму", this.pictureBox1, supermarket.Desks[0].Form.X - MainForm.DXY * 5, supermarket.Desks[0].Form.Bottom, 10000);
            new ToolTip().Show("Это кассир\nКликните, чтобы узнать\nскорость сканирования", this.pictureBox1, supermarket.Cashiers[0].Body.Right, supermarket.Cashiers[0].Body.Top - MainForm.DXY * 4, 10000);
            new ToolTip().Show("Это полка с товарами\nКликните по ней, чтобы узнать,\nсколько в ней разных товаров и их цену", this.pictureBox1, supermarket.Shelves[0].Form.Right, supermarket.Shelves[0].Form.Top, 10000);
            new ToolTip().Show("Это вход. Отсюда заходят покупатели\nКликните на покупателя, чтобы узнать\nего возраст, список покупок и баланс", this.pictureBox1, this.entrance.X, this.entrance.Top - MainForm.DXY * 10, 10000);
            new ToolTip().Show("Это дверь на склад\nКогда на полках мало товаров,\nотсюда выходит менеджер\n и пополняет их", this.pictureBox1, this.warehouse.X - this.warehouse.Width, this.warehouse.Top - MainForm.DXY * 10, 10000);
        }

        //нажатие кнопки остановки симуляции
        private void stopButton_Click(object sender, EventArgs e)
        {
            //останавливаем таймеры и секундомер
            timer1.Stop();
            timer2.Stop();
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
            string DesksShelves = String.Format("{0}/{1}", this.numOfCashDesks, this.numOfShelves);
            string interval = string.Format("[{0},{1}]", this.minFrequencytrackBar.Value, this.maxFrequencytrackBar.Value);
            double speed = this.cashiersSpeed / 1000.0;
            //добавляем в таблицу результатов симуляций данные
            this.dataGridView1.Rows.Add(simulationCount.ToString(), elapsedTime, DesksShelves, speed.ToString(), interval,
                supermarket.ServedCustomers.ToString(), supermarket.TotalIncome.ToString(), supermarket.AverageCheck.ToString());
            StopSimulation(); //метод остановки симуляции
            this.tabControl1.SelectedIndex = 2; //переключаемся на вкладку с таблицей результатов
        }

        //метод остановки симуляции
        private void StopSimulation()
        {
            if (simulationPaused) //если симуляция на паузе, возобновляем симуляции
            {
                Resumebutton_Click(Owner, EventArgs.Empty);
                timer1.Stop();
                timer2.Stop();
            }
            //останавливаем все живые потоки
            foreach (CashDesk desk in supermarket.Desks)
                if (desk.Thread != null && desk.Thread.IsAlive)
                    desk.Thread.Abort();
            foreach (ProductShelf shelf in supermarket.Shelves)
                if (shelf.Thread != null && shelf.Thread.IsAlive)
                    shelf.Thread.Abort();
            foreach (Customer customer in supermarket.Customers)
                if (customer.Thread != null && customer.Thread.IsAlive)
                    customer.Thread.Abort();
            if(supermarket.Manager.Thread!=null && supermarket.Manager.Thread.IsAlive)
                supermarket.Manager.Thread.Abort();
            supermarket = null; //обнуляем ссылку на магазин
            this.pictureBox1.Invalidate();
        }

        //при закрытии формы
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (supermarket != null) //останавливаем симуляцию, если она идет
                StopSimulation(); 
            Application.Exit();
        }

        //нажатие кнопки паузы симуляции
        private void Pausebutton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            this.simulationPaused = true;
            this.Pausebutton.Enabled = false;
            this.Resumebutton.Enabled = true;
            //приостанавливаем все живые потоки
            foreach (CashDesk desk in supermarket.Desks)
                if (desk.Thread != null && desk.Thread.IsAlive)
                    desk.Thread.Suspend();
            foreach (ProductShelf shelf in supermarket.Shelves)
                if (shelf.Thread != null && shelf.Thread.IsAlive)
                    shelf.Thread.Suspend();
            foreach (Customer customer in supermarket.Customers)
                if (customer.Thread != null && customer.Thread.IsAlive)
                    customer.Thread.Suspend();
            if (supermarket.Manager.Thread != null && supermarket.Manager.Thread.IsAlive)
                supermarket.Manager.Thread.Suspend();
        }

        //нажатие кнопки возобновления симуляции
        private void Resumebutton_Click(object sender, EventArgs e)
        {
            this.simulationPaused = false;
            this.Pausebutton.Enabled = true;
            this.Resumebutton.Enabled = false;
            //возобновляем остановленные потоки
            foreach (CashDesk desk in supermarket.Desks)
                if (desk.Thread != null && desk.Thread.IsAlive)
                    desk.Thread.Resume();
            foreach (ProductShelf shelf in supermarket.Shelves)
                if (shelf.Thread != null && shelf.Thread.IsAlive)
                    shelf.Thread.Resume();
            foreach (Customer customer in supermarket.Customers)
                if (customer.Thread != null && customer.Thread.IsAlive)
                    customer.Thread.Resume();
            if (supermarket.Manager.Thread != null && supermarket.Manager.Thread.IsAlive)
                supermarket.Manager.Thread.Resume();
            timer1.Start();
            timer2.Start();
        }

        //При перемещении ползунка трекбара минимальной частоты появления нового покупателя
        private void minFrequencytrackBar_Scroll(object sender, EventArgs e)
        {
            this.minFrequencyLabel.Text = String.Format("Выберите минимальную частоту появления нового покупателя: {0} c", minFrequencytrackBar.Value);
            this.maxFrequencytrackBar.Minimum = minFrequencytrackBar.Value;
            this.maxFrequencytrackBar.Value = maxFrequencytrackBar.Minimum;
            this.maxFrequencyLabel.Text = String.Format("Выберите максимальную частоту появления нового покупателя: {0} c", maxFrequencytrackBar.Value);
            this.maxFrequencytrackBar.Maximum = 10 + minFrequencytrackBar.Value;
        }

        //При перемещении ползунка трекбара максимальной частоты появления нового покупателя
        private void maxFrequencytrackBar_Scroll(object sender, EventArgs e)
        {
            this.maxFrequencyLabel.Text = String.Format("Выберите максимальную частоту появления нового покупателя: {0} c", maxFrequencytrackBar.Value);
        }

        //нажатие кнопки просмотра результатов
        private void ResultsButton_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 2;
        }

        //нажатие кнопки сохранения результатов в файл
        private void Savebutton_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "(*.txt)|*.txt";
            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(save.FileName, false);
                    sw.WriteLine("№ | Время | Число касс/полок | Скорость сканирования | Интервал появления покупателей | Обслужено покупателей | Общий доход | Средний чек\n");
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                       sw.WriteLine(String.Format("{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7}\n", dataGridView1.Rows[i].Cells[0].Value, dataGridView1.Rows[i].Cells[1].Value,dataGridView1.Rows[i].Cells[2].Value, dataGridView1.Rows[i].Cells[3].Value, dataGridView1.Rows[i].Cells[4].Value, dataGridView1.Rows[i].Cells[5].Value,dataGridView1.Rows[i].Cells[6].Value, dataGridView1.Rows[i].Cells[7].Value));
                    sw.Close();       
                    MessageBox.Show("Результаты успешно сохранены в файл", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Возникла ошибка при сохранении результатов в файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //нажатие кнопки повтора симуляции
        private void RepeatButton_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
        }

        //клик мыши по picturebox
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //выводим подсказку с информацией об объекте симуляции при нажатии на него
            foreach (var desk in supermarket.Desks)
                if (desk.Form.Contains(e.Location))
                    toolTip.Show(desk.ToString(), this.pictureBox1, desk.Form.Right, desk.Form.Top, 2000);
            foreach (var shelf in supermarket.Shelves)
                if (shelf.Form.Contains(e.Location))
                    toolTip.Show(shelf.ToString(), this.pictureBox1, shelf.Form.Right, shelf.Form.Top, 6000);
            foreach (var customer in supermarket.Customers)
                if (customer.Body.Contains(e.Location))
                    toolTip.Show(customer.ToString(), this.pictureBox1, customer.Body.Right, customer.Body.Top, 3000);
            foreach (var cashier in supermarket.Cashiers)
                if (cashier.Body.Contains(e.Location))
                    toolTip.Show(cashier.ToString(), this.pictureBox1, cashier.Body.Right, cashier.Body.Top, 2000);
            if (supermarket.Manager.Body.Contains(e.Location))
                toolTip.Show(supermarket.Manager.ToString(), this.pictureBox1, supermarket.Manager.Body.Right, supermarket.Manager.Body.Top, 2000);
        }
    }
}


