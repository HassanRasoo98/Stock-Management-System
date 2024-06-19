using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Stock_Management_System
{
    public partial class sales_page : Form
    {
        private main_screen main_Screen;
        public sales_page(main_screen temp)
        {
            InitializeComponent();

            main_Screen = temp;

            // to limit text box 5 (CNIC-1) to only accept 5 numbers at a time
            textBox4.KeyPress += TxtNumeric_KeyPress;
            textBox4.TextChanged += TxtNumeric_TextChanged;
            textBox5.KeyPress += TxtNumeric_KeyPress;
            textBox5.TextChanged += TxtNumeric_TextChanged;
            textBox6.KeyPress += TxtNumeric_KeyPress;
            textBox6.TextChanged += TxtNumeric_TextChanged;
            textBox7.KeyPress += TxtNumeric_KeyPress;
            textBox7.TextChanged += TxtNumeric_TextChanged;
            textBox8.KeyPress += TxtNumeric_KeyPress;
            textBox8.TextChanged += TxtNumeric_TextChanged;
        }

        private void TxtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a digit or a control key (like backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ignore the key press
            }
        }

        private void TxtNumeric_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Tag != null)
            {
                int maxLength;
                if (int.TryParse(textBox.Tag.ToString(), out maxLength))
                {
                    if (textBox.Text.Length == maxLength)
                    {
                        SelectNextControl(textBox, true, true, true, true); // Move to the next control in the tab order
                    }
                    if (textBox.Text.Length > maxLength)
                    {
                        textBox.Text = textBox.Text.Substring(0, maxLength); // Trim the text to the max length
                        textBox.SelectionStart = textBox.Text.Length; // Set the cursor to the end of the text
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main_Screen.Show();
            this.Close();
        }

        private void reset_all()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dateTimePicker1.ResetText();
        }

/*        private void customer_visibility_on()
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            dateTimePicker1.Visible = true;
            button5.Visible = true;
        }

        private void customer_visibility_off()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            dateTimePicker1.Visible = false;
            button5.Visible = false;
        }
*/
        private void button2_Click(object sender, EventArgs e)
        {
//            customer_visibility_on();
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
//            customer_visibility_off();
            groupBox1.Visible = false;
            groupBox2.Visible = true;
        }

        private bool validate_data()
        {
            // if any empty fields detected throw error
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 ||
                 textBox4.Text.Length == 0 || textBox5.Text.Length == 0)
            {
                return false;
            }

            // cnic
            if (textBox4.Text.Length != 15)
            {
                // 13 digits + 2 hyphens
                return false; 
            }

            // phone number
            if (textBox5.Text.Length != 12)
            {
                // 11 digits + 1 hyphen
                return false;
            }

            return true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // extract and save customer information to database
            // but first check for errors first
            if (!validate_data())
            {
                return;
            }

            string connectionString = "Data Source=(localDB)\\localDB1;Initial Catalog=Stock_Management_System;Integrated Security=True";
            string query = "INSERT INTO CustomerInformation (Name, FathersName, Address, CNIC, PhoneNumber, [Date]) VALUES (@Name, @FathersName, @Address, @CNIC, @PhoneNumber, @Date)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", textBox1.Text);
                command.Parameters.AddWithValue("@FathersName", textBox2.Text);
                command.Parameters.AddWithValue("@Address", textBox3.Text);
                command.Parameters.AddWithValue("@CNIC", textBox4.Text);
                command.Parameters.AddWithValue("@PhoneNumber", textBox5.Text);
                command.Parameters.AddWithValue("@Date", dateTimePicker1.Value);

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Data saved successfully.");
                        reset_all();
                    }
                    else
                    {
                        MessageBox.Show("Error saving data.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
        }
    }
}
