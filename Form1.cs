using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITCan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin" && textBox2.Text == "1")
            {
                Form2 adminForm = new Form2();
                adminForm.Show();
                this.Owner = adminForm;
                adminForm.Show();
                this.Hide();

            }
            if (textBox1.Text == "Master" && textBox2.Text == "201")
            {
                Form2 adminForm = new Form2();
                adminForm.Show();
                this.Owner = adminForm;
                adminForm.Show();
                this.Hide();
            }
            if (textBox1.Text == "IT" && textBox2.Text == "301")
            {
                Form3 userForm = new Form3();
                userForm.Show();
                this.Owner = userForm;
                userForm.Show();
                this.Hide();
            }
        }
    }
}
