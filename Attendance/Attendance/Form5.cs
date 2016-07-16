using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Attendance
{
    //Form5: Display "Display Department Names" form.
    public partial class Form5 : Form
    {
        OleDbConnection DBCon1; // Database Connection 1
        public Form5()
        {
            InitializeComponent();
            
            //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");

            //Open DataBase Connection 1
            DBCon1.Open();
        }

        ~Form5()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This Method will load department list in datagridview1
        private void Form5_Load(object sender, EventArgs e)
        {
            //Load List of Department in Combobox1
                //Get DataBase Adapter
                OleDbDataAdapter DBAdapter1 = new OleDbDataAdapter("select * from department", DBCon1);
                //Declare Data Set1
                DataSet DS1 = new DataSet();
                //Intialise IRecordCount to 0; IRecordCount is use to store no. of record afected
                int IRecordCount = 0;
                //Fill DataBase Adapter1 and set IRecordCount
                IRecordCount = DBAdapter1.Fill(DS1, "Department");
                //Set Data Table1
                DataTable DT1 = DS1.Tables["Department"];
                //Set Data View1
                DataView DV1 = DT1.DefaultView;
                //set DataGridView Data source to Data View 1
                dataGridView1.DataSource = DV1;
                //Set DataGridView Column Name
                dataGridView1.Columns[0].HeaderText = "Department ID";
                dataGridView1.Columns[1].HeaderText = "Department Name";
                dataGridView1.Columns[1].Width = 225;            
                //Dispose DataTable1, DataSet1, DataBase Adapter 1 
                DT1.Dispose();
                DS1.Dispose();
                DBAdapter1.Dispose();
        }
    }
}