using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using PrintShipmentOrder;
using Printer;
using Yb.StmsWeight.App;
namespace Printer
{
    public partial class MainForm : Form
    {

        private PrintShipmentOrderForm fahuoWindows;
        private PrintForm shouhuoWindows;

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            fahuoWindows = new PrintShipmentOrderForm();
            shouhuoWindows = new PrintForm();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            fahuoWindows.Show();
            this.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            shouhuoWindows.Show();
            this.Hide();
        }
    }
}
