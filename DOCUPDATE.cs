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
    public partial class DOCUPDATE : Form
    {
        function fn = new function();
        String query;
        public DOCUPDATE()
        {
            InitializeComponent();
        }

        private void SearchpID_Click(object sender, EventArgs e)
        {
            if (p_ID.Text != "")
            {
                query = "select * from treatment where patient_ID = '" + p_ID.Text + "'";
                DataSet ds = fn.GetData(query);
                if (ds.Tables[0].Rows.Count != 0)
                {
                    pName.Text = ds.Tables[0].Rows[0][6].ToString();
                    Doc_ID.Text= ds.Tables[0].Rows[0][0].ToString();
                    fDrug.Text= ds.Tables[0].Rows[0][2].ToString();
                    SecDrug.Text= ds.Tables[0].Rows[0][3].ToString();
                    DocCOm.Text= ds.Tables[0].Rows[0][4].ToString();
                    DoName.Text= ds.Tables[0].Rows[0][5].ToString();
                }
                else
                {
                    MessageBox.Show("No Patient with ID: " + p_ID.Text + " was found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                ClearAll();
            }
        }
        private void ClearAll()
        {
            pName.Clear();
            DoName.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Int64 pID = Int64.Parse(p_ID.Text);
            Int64 dId = Int64.Parse(Doc_ID.Text);
            String pname = pName.Text;
            String dIDoNamed = DoName.Text;
            String Fdr = fDrug.Text;
            String Sdrug = SecDrug.Text;
            String comm = DocCOm.Text;
            query= "update treatment set doctor_Id = " + dId + ",patient_ID=" + pID + ",F_drug='" + Fdr + "',S_drug='" + Sdrug + "',Doc_comm='" + comm + "',Doc_name='" + dIDoNamed + "',Patiant_name='" + pname + "'where patient_ID = '" + p_ID.Text + "' ";
            fn.SetData(query, "Update sucsesfully");
        }
    }
}
