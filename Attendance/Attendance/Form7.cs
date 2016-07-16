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
    //Form7: Display "Modify Class Name" form.
    public partial class Form7 : Form
    {
        OleDbConnection DBCon1;
        bool BDept;
        public Form7()
        {
            InitializeComponent();
            //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");            
            //Open DataBase Connection 1
            DBCon1.Open();
            //Set Department Flag to false
            BDept = false;
        }

         ~Form7()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This method will loads department and class list in combobox1 & combox2 respectively  
        private void Form7_Load(object sender, EventArgs e)
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

        //This method will loads class list in combobox1 if another department name is selected.
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

        //This method will modify class name
        private void button1_Click(object sender, EventArgs e)
        {            
            //Modify Class Name
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && string.Compare(textBox1.Text.ToString(), "")!=0)
            {
                OleDbCommand DBCom1 = new OleDbCommand("select * from class where class_name='" + textBox1.Text.ToString() + "' and dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                string SClass_name;
                SClass_name = (string)DBCom1.ExecuteScalar();
                DBCom1.Dispose();
                if (string.Compare(SClass_name, textBox1.Text.ToString()) == 0)
                {
                    MessageBox.Show("Class Name =" + textBox1.Text.ToString() + " is skiped because it is already exist");
                    textBox1.ResetText();
                }
                else
                {
                    OleDbCommand DBCom2 = new OleDbCommand("update class set class_name='" + textBox1.Text + "' where dept_id=" + comboBox1.SelectedValue.ToString() + " and class_id=" + comboBox2.SelectedValue.ToString(), DBCon1);
                    DBCom2.ExecuteNonQuery();
                    DBCom2.Dispose();
                    MessageBox.Show("Class Name is Modified");
                    textBox1.ResetText();


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
            else if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("No Department Name Exsit");
            }
            else if (comboBox2.SelectedValue == null)
            {
                MessageBox.Show("No Class Name Exsit");
            }
            else if (string.Compare(textBox1.Text.ToString(), "") == 0)
            {
                MessageBox.Show("Please Enter New Class Name");
            }
        }
    }
}