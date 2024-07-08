using Hospital.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;

namespace Hospital
{
    public partial class Form1 : Form
    {
        function fn = new function();
        String query;
        DataSet ds;
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://ar-ar.facebook.com/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://myaccount.google.com/");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            query = "select * from Recaptinist";
            ds = fn.GetData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
                {
                    new system().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("UserName OR Password Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                query = "select * from Recaptinist where useName ='" + txtUsername.Text + "' and pass='" + txtPassword.Text + "'";
                ds = fn.GetData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    new system().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("UserName OR Password Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
