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
    //Form21: Display "Display Student Names" form
    public partial class Form21 : Form
    {
        OleDbConnection DBCon1;
        bool BDept;
        static bool BClass;

        public Form21()
        {
            InitializeComponent();

            //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");

            //Set Depatment Flag to false
            BDept = false;

           
            //Open DataBase Connection 1
            DBCon1.Open();
        }

        ~Form21()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This method will load department, class and student list in combobox1, comboboc2 and datagridview1 respectively 
        private void Form21_Load(object sender, EventArgs e)
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

            //Set Class Flag to false
            BClass = false;


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
                //Dispose DataTable2, DataSet2, DataBase Adapter 2 
                DT2.Dispose();
                DS2.Dispose();
                DBAdapter2.Dispose();
            }

            //Set Class Flag to true
            BClass = true;
            //Set Department Flag to true
            BDept = true;

            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null)
            {
                OleDbDataAdapter DBAdapter3 = new OleDbDataAdapter("select student_id, student_name from student where dept_id =" + comboBox1.SelectedValue.ToString() + "and class_id=" + comboBox2.SelectedValue.ToString(), DBCon1);
                //Declare Data Set3
                DataSet DS3 = new DataSet();
                //Intialise IRecordCount3 to 0; IRecordCount is use to store no. of record afected
                int IRecordCount3 = 0;
                //Fill DataBase Adapter3 and set IRecordCount3
                IRecordCount3 = DBAdapter3.Fill(DS3, "Student");
                //Set Data Table3
                DataTable DT3 = DS3.Tables["Student"];
                //Set Data View3
                DataView DV3 = DT3.DefaultView;

                //Set Data in Data Grid View 1

                dataGridView1.DataSource = DV3;
                dataGridView1.Columns[0].HeaderText = "Student Roll No.";
                dataGridView1.Columns[1].HeaderText = "Student Name";

                dataGridView1.Columns[0].Width = 150;
                dataGridView1.Columns[1].Width = 225;

                //Dispose DataTable3, DataSet3, DataBase Adapter3 
                DT3.Dispose();
                DS3.Dispose();
                DBAdapter3.Dispose();
                
            }
        }

        //This method will load class and student list in comboboc2 and datagridview1 respectively if another department is selected
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set Class Flag to false
            BClass = false;

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
            else if (comboBox1.SelectedValue == null && BDept == true)
            {
                MessageBox.Show("No Department Exist");
            }

            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && BDept == true)
            {
                OleDbDataAdapter DBAdapter3 = new OleDbDataAdapter("select student_id, student_name from student where dept_id =" + comboBox1.SelectedValue.ToString() + "and class_id=" + comboBox2.SelectedValue.ToString(), DBCon1);
                //Declare Data Set3
                DataSet DS3 = new DataSet();
                //Intialise IRecordCount3 to 0; IRecordCount is use to store no. of record afected
                int IRecordCount3 = 0;
                //Fill DataBase Adapter3 and set IRecordCount3
                IRecordCount3 = DBAdapter3.Fill(DS3, "Student");
                //Set Data Table3
                DataTable DT3 = DS3.Tables["Student"];
                //Set Data View3
                DataView DV3 = DT3.DefaultView;

                //Set Data in Data Grid View 1

                dataGridView1.DataSource = DV3;
                dataGridView1.Columns[0].HeaderText = "Student Roll No.";
                dataGridView1.Columns[1].HeaderText = "Student Name";

                dataGridView1.Columns[0].Width = 150;
                dataGridView1.Columns[1].Width = 225;

                //Dispose DataTable3, DataSet3, DataBase Adapter3 
                DT3.Dispose();
                DS3.Dispose();
                DBAdapter3.Dispose();

            }
            
            BClass = true;
        }

        //This method will load student list in  datagridview1 if another class is selected
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BClass == true && comboBox1.SelectedValue != null && comboBox2.SelectedValue != null)
            {
                OleDbDataAdapter DBAdapter3 = new OleDbDataAdapter("select student_id, student_name from student where dept_id =" + comboBox1.SelectedValue.ToString() + "and class_id=" + comboBox2.SelectedValue.ToString(), DBCon1);
                //Declare Data Set3
                DataSet DS3 = new DataSet();
                //Intialise IRecordCount3 to 0; IRecordCount is use to store no. of record afected
                int IRecordCount3 = 0;
                //Fill DataBase Adapter3 and set IRecordCount3
                IRecordCount3 = DBAdapter3.Fill(DS3, "Student");
                //Set Data Table3
                DataTable DT3 = DS3.Tables["Student"];
                //Set Data View3
                DataView DV3 = DT3.DefaultView;

                //Set Data in Data Grid View 1

                dataGridView1.DataSource = DV3;
                dataGridView1.Columns[0].HeaderText = "Student Roll No.";
                dataGridView1.Columns[1].HeaderText = "Student Name";

                dataGridView1.Columns[0].Width = 150;
                dataGridView1.Columns[1].Width = 225;

                //Dispose DataTable3, DataSet3, DataBase Adapter3 
                DT3.Dispose();
                DS3.Dispose();
                DBAdapter3.Dispose();
            }
        }
    }
}