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
    //Form4: Display "Delete Departemnt Name" form.
    public partial class Form4 : Form
    {
        OleDbConnection DBCon1; // Database Connection 1

        //This Constructor inititalse database connection 
        public Form4()
        {
            InitializeComponent();
            
            //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");

            //Open DataBase Connection 1
            DBCon1.Open();
        }
         
        //This destructor closes Database Connection 1
        ~Form4()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This method loads department list in combobox1
        private void Form4_Load(object sender, EventArgs e)
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
        }

        //This method will delete department name (which selected from combobox1)
        private void button1_Click(object sender, EventArgs e)
        {
            //Check if Existing Department Name Exist or not
            if (comboBox1.SelectedValue != null)
            {
                // set DataBase Command1 
                OleDbCommand DBCom1 = new OleDbCommand("delete from department where dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);

                //Execute Database Command1 
                DBCom1.ExecuteNonQuery();

                //Delete DataBase Command1
                DBCom1.Dispose();

                //Show Messasge for Successful Deletion
                MessageBox.Show("Department Name is Deleted");

                //Load Modified List of Department in Combobox1

                //Get DataBase Adapter
                OleDbDataAdapter DBAdapter2 = new OleDbDataAdapter("select * from department", DBCon1);

                //Declare Data Set2
                DataSet DS2 = new DataSet();

                //Intialise IRecordCount to 0; IRecordCount is use to store no. of record afected
                int IRecordCount = 0;

                //Fill DataBase Adapter2 and set IRecordCount
                IRecordCount = DBAdapter2.Fill(DS2, "Department");

                //Set Data Table1
                DataTable DT2 = DS2.Tables["Department"];

                //Set Data View1
                DataView DV2 = DT2.DefaultView;

                //set Combobox Data source to Data View 2
                comboBox1.DataSource = DV2;

                //Set DisplayMember and ValueMember of Combobox1
                comboBox1.DisplayMember = "DEPT_NAME";
                comboBox1.ValueMember = "DEPT_ID";

                //Dispose DataTable2, DataSet2, DataBase Adapter2 
                DT2.Dispose();
                DS2.Dispose();
                DBAdapter2.Dispose();
            }
            else
            {
                MessageBox.Show("No Department Name Exist To Delete");
            }
        }
    }
}