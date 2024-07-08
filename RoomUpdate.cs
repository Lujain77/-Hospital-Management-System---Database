using System;
using System.Collections;
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
     
    public partial class RoomUpdate : Form
    {
        function fn = new function();
        String query;
        public RoomUpdate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RNum.Text != "")
            {
                query = "select * from Room where Room_ID = '" + RNum.Text + "'";
                DataSet ds = fn.GetData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    RTypew.Text = ds.Tables[0].Rows[0][1].ToString();
                 

                }
                else
                {
                    MessageBox.Show("No Nurse with ID: " + RNum.Text + " was found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                ClearAll();
            }
        }

        private void ClearAll()
        {
            RTypew.Clear();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String RTYPe = RTypew.Text;
            query = "update Room set room_Type = '" + RTYPe + "' where Room_ID = '" + RNum.Text + "' ";
            fn.SetData(query, "Update sucsesfully");
        }
    }
    
}
