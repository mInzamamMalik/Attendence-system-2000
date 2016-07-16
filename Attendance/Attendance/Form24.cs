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
    //Form24: Display "Display List of registered subject in semester" form
    public partial class Form24 : Form
    {
        OleDbConnection DBCon1;
        bool BDept;
        bool BClass;
        bool BSem;
      

        public Form24()
        {
            InitializeComponent();

            //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");

            //Open DataBase Connection 1
            DBCon1.Open();
        }
         
        ~Form24()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This method will load Department , class and semester list in combobox1, combobox2 and combobox3 respectively.
        // Also loads registered subject and lecturer list in datagrigview1
        private void Form24_Load(object sender, EventArgs e)
        {
            //Load List of Department in Combobox1
            BDept = false;
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

            //Load Semester List in Combobox3
            BSem = false;
            //Get DataBase Adapter
            OleDbDataAdapter DBAdapter3 = new OleDbDataAdapter("select * from Semester", DBCon1);
            //Declare Data Set3
            DataSet DS3 = new DataSet();
            //Intialise IRecordCount3 to 0; IRecordCount3 is use to store no. of record afected
            int IRecordCount3 = 0;
            //Fill DataBase Adapter3 and set IRecordCount3
            IRecordCount3 = DBAdapter3.Fill(DS3, "Semester");
            //Set Data Table3
            DataTable DT3 = DS3.Tables["Semester"];
            //Set Data View3
            DataView DV3 = DT3.DefaultView;
            //set Combobox Data source to Data View 3
            comboBox3.DataSource = DV3;
            //Set DisplayMember and ValueMember of Combobox3
            comboBox3.DisplayMember = "SEM_NAME";
            comboBox3.ValueMember = "SEM_ID";
            //Dispose DataTable3, DataSet3, DataBase Adapter3 
            DT3.Dispose();
            DS3.Dispose();
            DBAdapter3.Dispose();
            //set Semester Flag to True
            BSem = true;

            //Load List of Class in Combobox2
            BClass = false;

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
            //set BClass to true

            BClass = true;

            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null)
            {
                OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("SELECT SUBJECT.SUB_NAME, LECTURER.LECT_NAME FROM ((REG_LECT INNER JOIN SUBJECT ON REG_LECT.SUB_IND = SUBJECT.SUB_IND) INNER JOIN LECTURER ON REG_LECT.LECT_ID = LECTURER.LECT_ID AND SUBJECT.DEPT_ID = LECTURER.DEPT_ID) WHERE (SUBJECT.DEPT_ID = " + comboBox1.SelectedValue.ToString() + ") AND (SUBJECT.CLASS_ID = " + comboBox2.SelectedValue.ToString() + ") AND (SUBJECT.SEM_ID = " + comboBox3.SelectedValue.ToString() + ")", DBCon1);
                //Declare Data Set4
                DataSet DS4 = new DataSet();
                //Intialise IRecordCount3 to 0; IRecordCount4 is use to store no. of record afected                   
                int IRecordCount4 = 0;
                //Fill DataBase Adapter3 and set IRecordCount4                    
                IRecordCount4 = DBAdapter4.Fill(DS4, "Subject");
                //Set Data Table4                    
                DataTable DT4 = DS4.Tables["Subject"];
                //Set Data View4                    
                DataView DV4 = DT4.DefaultView;

                //Fill DataGridView1
                dataGridView1.DataSource = DV4;
                dataGridView1.Columns[0].HeaderText = "Subject Name";
                dataGridView1.Columns[1].HeaderText = "Lecturer Name";
                dataGridView1.Columns[0].Width = 175;
                dataGridView1.Columns[1].Width = 175;
            }
        }

        //This method will load class list in combobox2 
        //Also loads registered subject and lecturer list in datagrigview1 if Department name is changed
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BDept == true)
            {
                //Load List of Class in Combobox2
                BClass = false;

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
                //set BClass to true

                BClass = true;

                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null)
                {
                    OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("SELECT SUBJECT.SUB_NAME, LECTURER.LECT_NAME FROM ((REG_LECT INNER JOIN SUBJECT ON REG_LECT.SUB_IND = SUBJECT.SUB_IND) INNER JOIN LECTURER ON REG_LECT.LECT_ID = LECTURER.LECT_ID AND SUBJECT.DEPT_ID = LECTURER.DEPT_ID) WHERE (SUBJECT.DEPT_ID = " + comboBox1.SelectedValue.ToString() + ") AND (SUBJECT.CLASS_ID = " + comboBox2.SelectedValue.ToString() + ") AND (SUBJECT.SEM_ID = " + comboBox3.SelectedValue.ToString() + ")", DBCon1);
                    //Declare Data Set4
                    DataSet DS4 = new DataSet();
                    //Intialise IRecordCount3 to 0; IRecordCount4 is use to store no. of record afected                   
                    int IRecordCount4 = 0;
                    //Fill DataBase Adapter3 and set IRecordCount4                    
                    IRecordCount4 = DBAdapter4.Fill(DS4, "Subject");
                    //Set Data Table4                    
                    DataTable DT4 = DS4.Tables["Subject"];
                    //Set Data View4                    
                    DataView DV4 = DT4.DefaultView;

                    //Fill DataGridView1
                    dataGridView1.DataSource = DV4;
                    dataGridView1.Columns[0].HeaderText = "Subject Name";
                    dataGridView1.Columns[1].HeaderText = "Lecturer Name";
                    dataGridView1.Columns[0].Width = 175;
                    dataGridView1.Columns[1].Width = 175;
                }
            }
        }

        //This method will loads registered subject and lecturer list in datagrigview1 if class name is changed
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BClass == true)
            {
                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null)
                {
                    OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("SELECT SUBJECT.SUB_NAME, LECTURER.LECT_NAME FROM ((REG_LECT INNER JOIN SUBJECT ON REG_LECT.SUB_IND = SUBJECT.SUB_IND) INNER JOIN LECTURER ON REG_LECT.LECT_ID = LECTURER.LECT_ID AND SUBJECT.DEPT_ID = LECTURER.DEPT_ID) WHERE (SUBJECT.DEPT_ID = " + comboBox1.SelectedValue.ToString() + ") AND (SUBJECT.CLASS_ID = " + comboBox2.SelectedValue.ToString() + ") AND (SUBJECT.SEM_ID = " + comboBox3.SelectedValue.ToString() + ")", DBCon1);
                    //Declare Data Set4
                    DataSet DS4 = new DataSet();
                    //Intialise IRecordCount3 to 0; IRecordCount4 is use to store no. of record afected                   
                    int IRecordCount4 = 0;
                    //Fill DataBase Adapter3 and set IRecordCount4                    
                    IRecordCount4 = DBAdapter4.Fill(DS4, "Subject");
                    //Set Data Table4                    
                    DataTable DT4 = DS4.Tables["Subject"];
                    //Set Data View4                    
                    DataView DV4 = DT4.DefaultView;

                    //Fill DataGridView1
                    dataGridView1.DataSource = DV4;
                    dataGridView1.Columns[0].HeaderText = "Subject Name";
                    dataGridView1.Columns[1].HeaderText = "Lecturer Name";
                    dataGridView1.Columns[0].Width = 175;
                    dataGridView1.Columns[1].Width = 175;
                }
            }
        }

        //This method will loads registered subject and lecturer list in datagrigview1 if semester name is changed
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BSem == true)
            {
                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null)
                {
                    OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("SELECT SUBJECT.SUB_NAME, LECTURER.LECT_NAME FROM ((REG_LECT INNER JOIN SUBJECT ON REG_LECT.SUB_IND = SUBJECT.SUB_IND) INNER JOIN LECTURER ON REG_LECT.LECT_ID = LECTURER.LECT_ID AND SUBJECT.DEPT_ID = LECTURER.DEPT_ID) WHERE (SUBJECT.DEPT_ID = " + comboBox1.SelectedValue.ToString() + ") AND (SUBJECT.CLASS_ID = " + comboBox2.SelectedValue.ToString() + ") AND (SUBJECT.SEM_ID = " + comboBox3.SelectedValue.ToString() + ")", DBCon1);
                    //Declare Data Set4
                    DataSet DS4 = new DataSet();
                    //Intialise IRecordCount3 to 0; IRecordCount4 is use to store no. of record afected                   
                    int IRecordCount4 = 0;
                    //Fill DataBase Adapter3 and set IRecordCount4                    
                    IRecordCount4 = DBAdapter4.Fill(DS4, "Subject");
                    //Set Data Table4                    
                    DataTable DT4 = DS4.Tables["Subject"];
                    //Set Data View4                    
                    DataView DV4 = DT4.DefaultView;

                    //Fill DataGridView1
                    dataGridView1.DataSource = DV4;
                    dataGridView1.Columns[0].HeaderText = "Subject Name";
                    dataGridView1.Columns[1].HeaderText = "Lecturer Name";
                    dataGridView1.Columns[0].Width = 175;
                    dataGridView1.Columns[1].Width = 175;
                }

            }
        }
    }
}