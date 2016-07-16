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
    //Form8: Display "Delete Class Name" form.
    public partial class Form8 : Form
    {
        OleDbConnection DBCon1;
        bool BDept;
        public Form8()
        {
            InitializeComponent();

            //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");

            //Open DataBase Connection 1
            DBCon1.Open();

            //Set Department Flag to false
            BDept = false;
        }

         ~Form8()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This method will load departemnt and class list in combobox1 and combobox2 respectively.
        private void Form8_Load(object sender, EventArgs e)
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
                OleDbDataAdapter DBAdapter2 = new OleDbDataAdapter("select * from Class where dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                //Declare Data Set2
                DataSet DS2 = new DataSet();
                //Intialise IRecordCount to 0; IRecordCount is use to store no. of record afected
                int IRecordCount2 = 0;
                //Fill DataBase Adapter1 and set IRecordCount
                IRecordCount2 = DBAdapter2.Fill(DS2, "Class");
                //Set Data Table1
                DataTable DT2 = DS2.Tables["Class"];
                //Set Data View1
                DataView DV2 = DT2.DefaultView;
                //set Combobox Data source to Data View 1
                comboBox2.DataSource = DV2;
                //Set DisplayMember and ValueMember of Combobox1
                comboBox2.DisplayMember = "CLASS_NAME";
                comboBox2.ValueMember = "CLASS_ID";
                //Dispose DataTable1, DataSet1, DataBase Adapter 1 
                DT2.Dispose();
                DS2.Dispose();
                DBAdapter2.Dispose();
            }
        }

        //This method will delete class name from database.
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null)
            {
                OleDbCommand DBCom1 = new OleDbCommand("Delete from class where dept_id=" + comboBox1.SelectedValue.ToString() + " and class_id=" + comboBox2.SelectedValue.ToString(), DBCon1);
                DBCom1.ExecuteNonQuery();
                DBCom1.Dispose();
                MessageBox.Show("Class Name is Deleted");

                //Load List of Class in Combobox2
                if (comboBox1.SelectedValue != null)
                {
                    //Get DataBase Adapter2
                    OleDbDataAdapter DBAdapter2 = new OleDbDataAdapter("select * from Class where dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                    //Declare Data Set2
                    DataSet DS2 = new DataSet();
                    //Intialise IRecordCount to 0; IRecordCount is use to store no. of record afected
                    int IRecordCount2 = 0;
                    //Fill DataBase Adapter1 and set IRecordCount
                    IRecordCount2 = DBAdapter2.Fill(DS2, "Class");
                    //Set Data Table1
                    DataTable DT2 = DS2.Tables["Class"];
                    //Set Data View1
                    DataView DV2 = DT2.DefaultView;
                    //set Combobox Data source to Data View 1
                    comboBox2.DataSource = DV2;
                    //Set DisplayMember and ValueMember of Combobox1
                    comboBox2.DisplayMember = "CLASS_NAME";
                    comboBox2.ValueMember = "CLASS_ID";
                    //Dispose DataTable1, DataSet1, DataBase Adapter 1 
                    DT2.Dispose();
                    DS2.Dispose();
                    DBAdapter2.Dispose();
                }
            }
            else if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("No Department Name Exsit");
            }
            else if (comboBox2.SelectedValue == null)
            {
                MessageBox.Show("No Class Name Exsit");
            }
        }

        //This method will load Class list in combobox2 if department name is changed
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load List of Class in Combobox2 after filling combobox1 with list of department 
            if (comboBox1.SelectedValue != null && BDept == true)
            {
                //Get DataBase Adapter2
                OleDbDataAdapter DBAdapter2 = new OleDbDataAdapter("select * from Class where dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                //Declare Data Set2
                DataSet DS2 = new DataSet();
                //Intialise IRecordCount to 0; IRecordCount is use to store no. of record afected
                int IRecordCount2 = 0;
                //Fill DataBase Adapter1 and set IRecordCount
                IRecordCount2 = DBAdapter2.Fill(DS2, "Class");
                //Set Data Table1
                DataTable DT2 = DS2.Tables["Class"];
                //Set Data View1
                DataView DV2 = DT2.DefaultView;
                //set Combobox Data source to Data View 1
                comboBox2.DataSource = DV2;
                //Set DisplayMember and ValueMember of Combobox1
                comboBox2.DisplayMember = "CLASS_NAME";
                comboBox2.ValueMember = "CLASS_ID";
                //Dispose DataTable1, DataSet1, DataBase Adapter 1 
                DT2.Dispose();
                DS2.Dispose();
                DBAdapter2.Dispose();
            }
        }
    }
}