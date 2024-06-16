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
    public partial class login_page : Form
    {
        public login_page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            if (textBox1.Text == "admin" && textBox2.Text == "1234")
            {
                label3.ForeColor = Color.Green;
                label3.Text = "Login Successful. Welcome!";
                label3.Visible = false;

                this.Hide();

                main_screen main_Screen_Form = new main_screen();
                main_Screen_Form.ShowDialog();
            }
            else
            {
                label3.Text = "Incorrect Credentials Entered. Try Again!";
                label3.ForeColor = Color.Red;
            }
        }
    }
}
