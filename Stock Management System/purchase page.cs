using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Management_System
{
    public partial class purchase_page : Form
    {
        private main_screen main;
        public purchase_page(main_screen temp)
        {
            InitializeComponent();

            main = temp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.Show();

            this.Close();
        }
    }
}
