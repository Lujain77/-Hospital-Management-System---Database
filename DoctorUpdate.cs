using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;
using static QRCoder.PayloadGenerator;

namespace Hospital
{

    public partial class DoctorUpdate : Form
    {
        function fn = new function();
        String query;
        public DoctorUpdate()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dID.Text != "")
            {
                query = "select * from Doctor where doc_ID = '" + dID.Text + "'";
                DataSet ds = fn.GetData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Dname.Text = ds.Tables[0].Rows[0][0].ToString();
                    Dgender.Text = ds.Tables[0].Rows[0][1].ToString();
                    dSpical.Text = ds.Tables[0].Rows[0][2].ToString();
                    dADD.Text = ds.Tables[0].Rows[0][4].ToString();
                    DPhone.Text = ds.Tables[0].Rows[0][5].ToString();

                }
                else
                {
                    MessageBox.Show("No Doctor with ID: " + dID.Text + " was found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                ClearAll();
            }
        }

        private void ClearAll()
        {
            Dname.Clear();
            Dgender.Clear();
            dSpical.Clear();
            dADD.Clear();
            DPhone.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String dnames = Dname.Text;
            String dgenders = Dgender.Text;
            String dspicals = dSpical.Text;
            String daddress = dADD.Text;
            String dphone = DPhone.Text;
            query = "update Doctor set doc_Name = '" + dnames + "',doc_Gender='" + dgenders + "',specialisation='" + dspicals + "',doc_Address='" + daddress + "',doc_Phone='" + dphone + "' where doc_ID = '" + dID.Text + "' ";
            fn.SetData(query, "Update sucsesfully");
        }
    }
}
