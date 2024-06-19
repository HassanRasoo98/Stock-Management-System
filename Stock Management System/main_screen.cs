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
    //    string connection_url = "Data Source=(localdb)\localDB1;Initial Catalog=STOCK_MANAGEMENT_SYSTEM;Integrated Security=True"; // desktop
    //    string connection_url = "Data Source=(localDB)\\localDB1;Initial Catalog=Stock_Management_System;Integrated Security=True"; // laptop
    public partial class main_screen : Form
    {
        public main_screen()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sales_page sales = new sales_page(this);
            this.Hide();

            sales.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            purchase_page purchase = new purchase_page(this);
            this.Hide(); purchase.Show();   
        }

    }
}
