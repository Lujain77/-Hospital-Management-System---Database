using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test;
using static System.Windows.Forms.AxHost;

namespace Hospital
{
    public partial class NursUpdate : Form

    {
        function fn = new function();
        String query;
        public NursUpdate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NID.Text != "")
            {
                query = "select * from Nurse where N_ID = '" + NID.Text + "'";
                DataSet ds = fn.GetData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    Nmail.Text = ds.Tables[0].Rows[0][1].ToString();
                    NAddres.Text = ds.Tables[0].Rows[0][2].ToString();
                    NPhone.Text = ds.Tables[0].Rows[0][3].ToString();
                    NName.Text = ds.Tables[0].Rows[0][4].ToString();

                }
                else
                {
                    MessageBox.Show("No Nurse with ID: " + NID.Text + " was found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                ClearAll();
            }
        }

        private void ClearAll()
        {
            Nmail.Clear();
            NAddres.Clear();
            NPhone.Clear();
            NName.Clear();
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
                String Nmaial = Nmail.Text;
                String Nadress = NAddres.Text;
                String Nphone = NPhone.Text;
                String nname = NName.Text;
              
                query = "update Nurse set N_email = '" + Nmaial + "',N_address='" + Nadress + "',N_phone=" + Nphone + ",Nurse_Name='" + nname + "'where N_ID = '" + NID.Text + "' ";
                fn.SetData(query, "Update sucsesfully");
            } 
    }
}
