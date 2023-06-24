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
        public static bool flag;
        private int numOfCashDesks;
        private int cashiersSpeed;
        private Supermarket supermarket;
        private Rectangle exit;
        public MainForm()
        {
            InitializeComponent();
            exit = new Rectangle(this.pictureBox1.Width / 2 - 100, -50, 200, 100);
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
            foreach (CashDesk desk in supermarket.Desks)
                if(desk.Status == DeskStatus.open)
                    desk.Shopping();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.supermarket.AddCustomer();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            flag = false;
            supermarket = null;
            this.pictureBox1.Invalidate();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            numOfCashDesks = 2;
            cashiersSpeed = 2000;
            try
            {
                supermarket = new Supermarket(numOfCashDesks, 1, 20, 10, 1500, cashiersSpeed, pictureBox1.Size);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            timer1.Start();
            timer2.Start();
            flag = true;
        }

        public void DrawObjects(Graphics g)
        {
            foreach (Customer customer in supermarket.Customers)
                g.FillEllipse(new SolidBrush(customer.Color), customer.Body);
            foreach(Cashier cashier in supermarket.cashiers)
                g.FillEllipse(new SolidBrush(cashier.Color), cashier.Body);
            foreach (CashDesk desk in supermarket.Desks)
                g.FillRectangle(new SolidBrush(desk.Color), desk.Form);
            g.FillPie(new SolidBrush(Color.Brown), new Rectangle(this.pictureBox1.Width / 2 - 100, this.pictureBox1.Height - 50, 200, 100), 180, 180);
            g.DrawString("ЗОНА КАСС", new Font("Arial", 14), new SolidBrush(Color.Black), this.pictureBox1.Width / 2 - 65, this.pictureBox1.Height - 30);
           g.FillPie(new SolidBrush(Color.Brown), exit, 0, 180);
            g.DrawString("ВЫХОД", new Font("Arial", 14), new SolidBrush(Color.Black), this.pictureBox1.Width / 2 - 45, 15);
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


