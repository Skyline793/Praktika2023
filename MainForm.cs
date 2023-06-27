using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktika2023
{

    public partial class MainForm : Form
    {
        public static int DXY = 5;
        public static bool simulation;
        private int numOfCashDesks;
        private int numOfShelves;
        private int simulationCount;
        private int cashiersSpeed;
        private Supermarket supermarket;
        private Rectangle entrance, exit;
        Stopwatch stopwatch;

        public MainForm()
        {
            InitializeComponent();
            exit = new Rectangle(this.pictureBox1.Width / 2 - MainForm.DXY * 20, -MainForm.DXY * 10, MainForm.DXY * 40, MainForm.DXY * 20);
            entrance = new Rectangle(this.pictureBox1.Width / 2 - MainForm.DXY * 20, this.pictureBox1.Height - MainForm.DXY * 10, MainForm.DXY * 40, MainForm.DXY * 20);
            stopwatch = new Stopwatch();
            simulation = false;
            simulationCount = 0;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
            if (supermarket != null)
            {
                DrawObjects(e.Graphics);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.pictureBox1.Invalidate();
            this.supermarket.PickingUp();
            this.supermarket.Shoppings();
            for (int i = supermarket.Customers.Count - 1; i >= 0; i--)
                if (supermarket.Customers[i].Status == CustomerStatus.exited)
                {
                    supermarket.Customers.RemoveAt(i);
                }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int min = 5 - this.numOfCashDesks-this.numOfShelves/2;
            timer2.Interval = Randomizer.Rand(min,10) * 1000;
            this.supermarket.AddCustomer();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
            string DesksShelves = String.Format("{0}/{1}", this.numOfCashDesks, this.numOfShelves);
            double speed = this.cashiersSpeed / 1000.0;
            int totalIncome=supermarket.TotalIncome;
            int averageCheck=supermarket.AverageCheck;
            this.dataGridView1.Rows.Add(Convert.ToString(simulationCount), elapsedTime, DesksShelves, Convert.ToString(speed), 
                Convert.ToString(supermarket.ServedCustomers), Convert.ToString(totalIncome), Convert.ToString(averageCheck));
            StopSimulation();
            this.tabControl1.SelectedIndex = 2;
    
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
            numOfCashDesks = Convert.ToInt32(this.numOfCashDeskComboBox.SelectedItem);
            cashiersSpeed = (int)(Convert.ToDouble(this.cashierSpeedComboBox.SelectedItem)*1000);
            numOfShelves = Convert.ToInt32(this.numOfShelvesComboBox.SelectedItem);
            timer2.Interval = 10000;
            supermarket = new Supermarket(numOfCashDesks, numOfShelves, cashiersSpeed, pictureBox1.Size);
            stopwatch.Start();
            timer1.Start();
            timer2.Start();
            simulation = true;
            simulationCount++;
            new ToolTip().Show("Это касса\nКликните по ней, чтобы узнать,\n сколько в ней денег", this.pictureBox1, supermarket.Desks[0].Form.X - MainForm.DXY * 5, supermarket.Desks[0].Form.Bottom, 10000);
            new ToolTip().Show("Это кассир\nКликните, чтобы узнать\nскорость сканирования", this.pictureBox1, supermarket.Cashiers[0].Body.Right, supermarket.Cashiers[0].Body.Top - MainForm.DXY * 4, 10000);
            new ToolTip().Show("Это полка с товарами\nКликните по ней, чтобы узнать,\nсколько в ней товаров", this.pictureBox1, supermarket.Shelves[0].Form.Right, supermarket.Shelves[0].Form.Top, 10000);
            new ToolTip().Show("Это вход. Отсюда заходят покупатели\nКликните на покупателя, чтобы узнать\nего возраст, список покупок и баланс", this.pictureBox1, this.entrance.X, this.entrance.Top - MainForm.DXY * 15, 10000);
        }

        private void DrawObjects(Graphics g)
        {
            foreach (Customer customer in supermarket.Customers)
                g.FillEllipse(new SolidBrush(customer.Color), customer.Body);
            foreach (Cashier cashier in supermarket.Cashiers)
                g.FillEllipse(new SolidBrush(cashier.Color), cashier.Body);
            foreach (CashDesk desk in supermarket.Desks)
                g.FillRectangle(new SolidBrush(desk.Color), desk.Form);
            foreach (ProductShelf shelf in supermarket.Shelves)
                g.FillRectangle(new SolidBrush(shelf.Color), shelf.Form);
            g.FillPie(new SolidBrush(Color.Brown), entrance, 180, 180);
            g.DrawString("ВХОД", new Font("Arial", 14), new SolidBrush(Color.Black), this.pictureBox1.Width / 2 - 40, this.pictureBox1.Height - 30);
            g.FillPie(new SolidBrush(Color.Brown), exit, 0, 180);
            g.DrawString("ВЫХОД", new Font("Arial", 14), new SolidBrush(Color.Black), this.pictureBox1.Width / 2 - 45, 15);
        }

        private void StopSimulation()
        {
            timer1.Stop();
            timer2.Stop();
            stopwatch.Stop();
            simulation = false;
            foreach (Customer customer in supermarket.Customers)
            {
                if (customer.Thread != null && customer.Thread.IsAlive)
                    customer.Thread.Abort();
            }
            supermarket = null;
            this.pictureBox1.Invalidate();
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (supermarket != null)
                StopSimulation();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.numOfCashDeskComboBox.SelectedIndex = 0;
            this.numOfShelvesComboBox.SelectedIndex = 0;
            this.cashierSpeedComboBox.SelectedIndex = 0;
            this.tabControl1.SelectedIndex = 0;
        }

        private void RepeatButton_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var desk in supermarket.Desks)
            {
                if (desk.Form.Contains(e.Location))
                {
                    toolTip.Show(desk.ToString(), this.pictureBox1, desk.Form.Right, desk.Form.Top, 2000);
                }
            }
            foreach(var shelf in supermarket.Shelves)
            {
                if(shelf.Form.Contains(e.Location))
                {
                    toolTip.Show(shelf.ToString(), this.pictureBox1, shelf.Form.Right, shelf.Form.Top, 2000);
                }
            }
            foreach (var customer in supermarket.Customers)
            {
                if (customer.Body.Contains(e.Location))
                {
                    toolTip.Show(customer.ToString(), this.pictureBox1, customer.Body.Right, customer.Body.Top, 2000);
                }
            }
            foreach(var cashier in supermarket.Cashiers)
            {
                if (cashier.Body.Contains(e.Location))
                {
                    toolTip.Show(cashier.ToString(), this.pictureBox1, cashier.Body.Right, cashier.Body.Top, 2000);
                }
            }
        }
    }
}


