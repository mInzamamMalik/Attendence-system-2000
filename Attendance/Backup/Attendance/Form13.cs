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
    //Form 13: Display " Display Lecturer Name form".
    public partial class Form13 : Form
    {
        OleDbConnection DBCon1;
        bool BDept;

        public Form13()
        {
            InitializeComponent();

            //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");

            //Open DataBase Connection 1
            DBCon1.Open();

            //Set Department Flag to false
            BDept = false;
        }

        ~Form13()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This method will oads Department and Lecturer list in combobox1 and datagridview1 resectively.
        private void Form13_Load(object sender, EventArgs e)
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
            //set Combobox Data source to Data View 1
            comboBox1.DataSource = DV1;
            //Set DisplayMember and ValueMember of Combobox1
            comboBox1.DisplayMember = "DEPT_NAME";
            comboBox1.ValueMember = "DEPT_ID";
            //Dispose DataTable1, DataSet1, DataBase Adapter 1 
            DT1.Dispose();
            DS1.Dispose();
            DBAdapter1.Dispose();

            //Set Department Flag to true
            BDept = true;

            //Load List of Class in Combobox2
            if (comboBox1.SelectedValue != null)
            {
                //Get DataBase Adapter2
                OleDbDataAdapter DBAdapter2 = new OleDbDataAdapter("select Lect_name from Lecturer where dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                //Declare Data Set2
                DataSet DS2 = new DataSet();
                //Intialise IRecordCount to 0; IRecordCount is use to store no. of record afected
                int IRecordCount2 = 0;
                //Fill DataBase Adapter1 and set IRecordCount
                IRecordCount2 = DBAdapter2.Fill(DS2, "Lecturer");
                //Set Data Table1
                DataTable DT2 = DS2.Tables["Lecturer"];
                //Set Data View1
                DataView DV2 = DT2.DefaultView;
                
                //Fill Data Grid View1
                dataGridView1.DataSource = DV2;
                dataGridView1.Columns[0].HeaderText = "Lecturer Name";
                dataGridView1.Columns[0].Width = 225;
                //Dispose DataTable1, DataSet1, DataBase Adapter 1 
                DT2.Dispose();
                DS2.Dispose();
                DBAdapter2.Dispose();
            }
        }

        //This method will loads Lecturer list in Datagridview1 if department name is changed.
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load List of Class in Combobox2
            if (comboBox1.SelectedValue != null && BDept == true)
            {
                //Get DataBase Adapter2
                OleDbDataAdapter DBAdapter2 = new OleDbDataAdapter("select Lect_name from Lecturer where dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                //Declare Data Set2
                DataSet DS2 = new DataSet();
                //Intialise IRecordCount to 0; IRecordCount is use to store no. of record afected
                int IRecordCount2 = 0;
                //Fill DataBase Adapter1 and set IRecordCount
                IRecordCount2 = DBAdapter2.Fill(DS2, "Lecturer");
                //Set Data Table1
                DataTable DT2 = DS2.Tables["Lecturer"];
                //Set Data View1
                DataView DV2 = DT2.DefaultView;

                //Fill Data Grid View1
                dataGridView1.DataSource = DV2;
                dataGridView1.Columns[0].HeaderText = "Lecturer Name";
                dataGridView1.Columns[0].Width = 225;
                //Dispose DataTable1, DataSet1, DataBase Adapter 1 
                DT2.Dispose();
                DS2.Dispose();
                DBAdapter2.Dispose();
            }

        }
    }
}