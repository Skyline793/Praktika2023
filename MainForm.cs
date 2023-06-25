using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktika2023
{

    public partial class MainForm : Form
    {
        public static int DXY = 5;
        public static bool flag;
        private int numOfCashDesks;
        private int numOfShelves;
        private int cashiersSpeed;
        private Supermarket supermarket;
        private Rectangle entrance, exit;
        public MainForm()
        {
            InitializeComponent();
            exit = new Rectangle(this.pictureBox1.Width / 2 - MainForm.DXY*20, -MainForm.DXY * 10, MainForm.DXY * 40, MainForm.DXY * 20);
            entrance = new Rectangle(this.pictureBox1.Width / 2 - MainForm.DXY * 20, this.pictureBox1.Height - MainForm.DXY * 10, MainForm.DXY * 40, MainForm.DXY * 20);
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
            this.supermarket.Shoppings();
            //foreach (CashDesk desk in supermarket.Desks)
            //    if (desk.Status == DeskStatus.open)
            //        desk.Shopping();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = Randomizer.Rand(2, 7) * 1000;
            this.supermarket.AddCustomer();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            StopSimulation();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            numOfCashDesks = 3;
            cashiersSpeed = 2000;
            numOfShelves = 2;
            try
            {
                supermarket = new Supermarket(numOfCashDesks, numOfShelves, cashiersSpeed, pictureBox1.Size);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            timer1.Start();
            timer2.Interval = 1000;
            timer2.Start();
            flag = true;
        }

        private void DrawObjects(Graphics g)
        {
            foreach (Customer customer in supermarket.Customers)
                g.FillEllipse(new SolidBrush(customer.Color), customer.Body);
            foreach(Cashier cashier in supermarket.Cashiers)
                g.FillEllipse(new SolidBrush(cashier.Color), cashier.Body);
            foreach (CashDesk desk in supermarket.Desks)
                g.FillRectangle(new SolidBrush(desk.Color), desk.Form);
            foreach(ProductShelf shelf in supermarket.Shelves)
                g.FillRectangle(new SolidBrush(shelf.Color), shelf.Form);
            g.FillPie(new SolidBrush(Color.Brown), entrance, 180, 180);
            g.DrawString("ЗОНА КАСС", new Font("Arial", 14), new SolidBrush(Color.Black), this.pictureBox1.Width / 2 - 65, this.pictureBox1.Height - 30);
           g.FillPie(new SolidBrush(Color.Brown), exit, 0, 180);
            g.DrawString("ВЫХОД", new Font("Arial", 14), new SolidBrush(Color.Black), this.pictureBox1.Width / 2 - 45, 15);
        }

        private void StopSimulation()
        {
            timer1.Stop();
            timer2.Stop();
            foreach (Customer customer in supermarket.Customers)
            {
                if (customer.Thread!=null && customer.Thread.IsAlive)
                    customer.Thread.Abort();
            }
            foreach(CashDesk desk in supermarket.Desks)
            {
                if(desk.Thread!= null && desk.Thread.IsAlive)
                    desk.Thread.Abort();
            }
            flag = false;
            supermarket = null;
            this.pictureBox1.Invalidate();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(supermarket!=null)
                StopSimulation();
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
            foreach (var customer in supermarket.Customers)
            {
                if (customer.Body.Contains(e.Location))
                {
                    toolTip.Show(customer.ToString(), this.pictureBox1, customer.Body.Right, customer.Body.Top, 2000);
                }
            }
        }
    }
}


