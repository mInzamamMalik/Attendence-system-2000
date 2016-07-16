using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;		

namespace Attendance
{
    //Form29: Display "Build Attendance Document (subject wise)" form
    public partial class Form29 : Form
    {
        OleDbConnection DBCon1;
        bool BDept;
        bool BClass;
        bool BSem;
        bool BSub;
        bool BLect;
        
        bool BIsGridDisplay;

        public Form29()
        {
           
            InitializeComponent();
        
             //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");

            //Open DataBase Connection 1
            DBCon1.Open();
        }

        ~Form29()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This method will load Department, Class, Semester, Subject and Lecturer List in combobox1, combobox2, combobox3, combobox4 & combobox5 respectively
        private void Form29_Load(object sender, EventArgs e)
        {
            BIsGridDisplay = false;
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

            //Load Registerd subject List in Combobox4
            BSub = false;
            //Get DataBase Adapter4
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null)
            {
                OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("SELECT sub_ind, sub_name from subject  where sub_ind in(select sub_ind from reg_lect) and  Dept_id=" + comboBox1.SelectedValue.ToString() + " and class_id= " + comboBox2.SelectedValue.ToString() + " and sem_id=" + comboBox3.SelectedValue.ToString(), DBCon1);
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
                //set Combobox Data source to Data View 4                    
                comboBox4.DataSource = DV4;
                //Set DisplayMember and ValueMember of Combobox4                    
                comboBox4.DisplayMember = "SUB_NAME";
                comboBox4.ValueMember = "SUB_IND";
                //Dispose DataTable4, DataSet4, DataBase Adapter4                     
                DT4.Dispose();
                DS4.Dispose();
                DBAdapter4.Dispose();
            }
            BSub = true;

            //Load List of Registered Lecturer in Combobox2
            BLect = false;
            if (comboBox1.SelectedValue != null && comboBox4.SelectedValue != null)
            {
                //Get DataBase Adapter5                
                OleDbDataAdapter DBAdapter5 = new OleDbDataAdapter("select * from lecturer where lect_id  in (SELECT Lect_id from reg_lect where sub_ind in(select sub_ind from subject where Sub_ind =" + comboBox4.SelectedValue.ToString() + "and Dept_id=" + comboBox1.SelectedValue.ToString() + "and class_id=" + comboBox2.SelectedValue.ToString() + "and sem_id=" + comboBox3.SelectedValue.ToString() + ") ) and Dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                // OleDbDataAdapter DBAdapter5 = new OleDbDataAdapter("select * from Lecturer where lect_id  in (select  lect_id from reg_lect ) and dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                //Declare Data Set5
                DataSet DS5 = new DataSet();
                //Intialise IRecordCount5 to 0; IRecordCount is use to store no. of record afected
                int IRecordCount5 = 0;
                //Fill DataBase Adapter5 and set IRecordCount5
                IRecordCount5 = DBAdapter5.Fill(DS5, "Lecturer");
                //Set Data Table5
                DataTable DT5 = DS5.Tables["Lecturer"];
                //Set Data View1
                DataView DV5 = DT5.DefaultView;
                //set Combobox Data source to Data View 5
                comboBox5.DataSource = DV5;
                //Set DisplayMember and ValueMember of Combobox5
                comboBox5.DisplayMember = "LECT_NAME";
                comboBox5.ValueMember = "LECT_ID";
                //Dispose DataTable5, DataSet5, DataBase Adapter5 
                DT5.Dispose();
                DS5.Dispose();
                DBAdapter5.Dispose();
            }
            else
                comboBox5.DataSource = null;
            BLect = true;            
        }

        //This method will load Class, Semester, Subject and Lecturer List in combobox2, combobox3, combobox4 & combobox5 respectively if department is changed
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

                //Load Registerd subject List in Combobox4
                BSub = false;
                //Get DataBase Adapter4
                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null)
                {
                    OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("SELECT sub_ind, sub_name from subject  where sub_ind in(select sub_ind from reg_lect) and  Dept_id=" + comboBox1.SelectedValue.ToString() + " and class_id= " + comboBox2.SelectedValue.ToString() + " and sem_id=" + comboBox3.SelectedValue.ToString(), DBCon1);
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
                    //set Combobox Data source to Data View 4                    
                    comboBox4.DataSource = DV4;
                    //Set DisplayMember and ValueMember of Combobox4                    
                    comboBox4.DisplayMember = "SUB_NAME";
                    comboBox4.ValueMember = "SUB_IND";
                    //Dispose DataTable4, DataSet4, DataBase Adapter4                     
                    DT4.Dispose();
                    DS4.Dispose();
                    DBAdapter4.Dispose();
                }
                BSub = true;

                //Load List of Registered Lecturer in Combobox2
                BLect = false;
                if (comboBox1.SelectedValue != null && comboBox4.SelectedValue != null)
                {
                    //Get DataBase Adapter5                
                    OleDbDataAdapter DBAdapter5 = new OleDbDataAdapter("select * from lecturer where lect_id  in (SELECT Lect_id from reg_lect where sub_ind in(select sub_ind from subject where Sub_ind =" + comboBox4.SelectedValue.ToString() + "and Dept_id=" + comboBox1.SelectedValue.ToString() + "and class_id=" + comboBox2.SelectedValue.ToString() + "and sem_id=" + comboBox3.SelectedValue.ToString() + ") ) and Dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                    // OleDbDataAdapter DBAdapter5 = new OleDbDataAdapter("select * from Lecturer where lect_id  in (select  lect_id from reg_lect ) and dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                    //Declare Data Set5
                    DataSet DS5 = new DataSet();
                    //Intialise IRecordCount5 to 0; IRecordCount is use to store no. of record afected
                    int IRecordCount5 = 0;
                    //Fill DataBase Adapter5 and set IRecordCount5
                    IRecordCount5 = DBAdapter5.Fill(DS5, "Lecturer");
                    //Set Data Table5
                    DataTable DT5 = DS5.Tables["Lecturer"];
                    //Set Data View1
                    DataView DV5 = DT5.DefaultView;
                    //set Combobox Data source to Data View 5
                    comboBox5.DataSource = DV5;
                    //Set DisplayMember and ValueMember of Combobox5
                    comboBox5.DisplayMember = "LECT_NAME";
                    comboBox5.ValueMember = "LECT_ID";
                    //Dispose DataTable5, DataSet5, DataBase Adapter5 
                    DT5.Dispose();
                    DS5.Dispose();
                    DBAdapter5.Dispose();
                }
                else
                    comboBox5.DataSource = null;
                BLect = true;
            }
        }

        //This method will load Semester, Subject and Lecturer List in combobox3, combobox4 & combobox5 respectively if Class is changed
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BClass == true)
            {
                //Load Registerd subject List in Combobox4
                BSub = false;
                //Get DataBase Adapter4
                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null)
                {
                    OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("SELECT sub_ind, sub_name from subject  where sub_ind in(select sub_ind from reg_lect) and  Dept_id=" + comboBox1.SelectedValue.ToString() + " and class_id= " + comboBox2.SelectedValue.ToString() + " and sem_id=" + comboBox3.SelectedValue.ToString(), DBCon1);
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
                    //set Combobox Data source to Data View 4                    
                    comboBox4.DataSource = DV4;
                    //Set DisplayMember and ValueMember of Combobox4                    
                    comboBox4.DisplayMember = "SUB_NAME";
                    comboBox4.ValueMember = "SUB_IND";
                    //Dispose DataTable4, DataSet4, DataBase Adapter4                     
                    DT4.Dispose();
                    DS4.Dispose();
                    DBAdapter4.Dispose();
                }
                BSub = true;

                //Load List of Registered Lecturer in Combobox2
                BLect = false;
                if (comboBox1.SelectedValue != null && comboBox4.SelectedValue != null)
                {
                    //Get DataBase Adapter5                
                    OleDbDataAdapter DBAdapter5 = new OleDbDataAdapter("select * from lecturer where lect_id  in (SELECT Lect_id from reg_lect where sub_ind in(select sub_ind from subject where Sub_ind =" + comboBox4.SelectedValue.ToString() + "and Dept_id=" + comboBox1.SelectedValue.ToString() + "and class_id=" + comboBox2.SelectedValue.ToString() + "and sem_id=" + comboBox3.SelectedValue.ToString() + ") ) and Dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                    // OleDbDataAdapter DBAdapter5 = new OleDbDataAdapter("select * from Lecturer where lect_id  in (select  lect_id from reg_lect ) and dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                    //Declare Data Set5
                    DataSet DS5 = new DataSet();
                    //Intialise IRecordCount5 to 0; IRecordCount is use to store no. of record afected
                    int IRecordCount5 = 0;
                    //Fill DataBase Adapter5 and set IRecordCount5
                    IRecordCount5 = DBAdapter5.Fill(DS5, "Lecturer");
                    //Set Data Table5
                    DataTable DT5 = DS5.Tables["Lecturer"];
                    //Set Data View1
                    DataView DV5 = DT5.DefaultView;
                    //set Combobox Data source to Data View 5
                    comboBox5.DataSource = DV5;
                    //Set DisplayMember and ValueMember of Combobox5
                    comboBox5.DisplayMember = "LECT_NAME";
                    comboBox5.ValueMember = "LECT_ID";
                    //Dispose DataTable5, DataSet5, DataBase Adapter5 
                    DT5.Dispose();
                    DS5.Dispose();
                    DBAdapter5.Dispose();
                }
                else
                    comboBox5.DataSource = null;
                BLect = true;
            }
        }


        //This method will load Subject and Lecturer List in combobox4 & combobox5 respectively if Semester is changed
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BSem == true)
            {
                //Load Registerd subject List in Combobox4
                BSub = false;
                //Get DataBase Adapter4
                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null)
                {
                    OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("SELECT sub_ind, sub_name from subject  where sub_ind in(select sub_ind from reg_lect) and  Dept_id=" + comboBox1.SelectedValue.ToString() + " and class_id= " + comboBox2.SelectedValue.ToString() + " and sem_id=" + comboBox3.SelectedValue.ToString(), DBCon1);
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
                    //set Combobox Data source to Data View 4                    
                    comboBox4.DataSource = DV4;
                    //Set DisplayMember and ValueMember of Combobox4                    
                    comboBox4.DisplayMember = "SUB_NAME";
                    comboBox4.ValueMember = "SUB_IND";
                    //Dispose DataTable4, DataSet4, DataBase Adapter4                     
                    DT4.Dispose();
                    DS4.Dispose();
                    DBAdapter4.Dispose();
                }
                BSub = true;

                //Load List of Registered Lecturer in Combobox2
                BLect = false;
                if (comboBox1.SelectedValue != null && comboBox4.SelectedValue != null)
                {
                    //Get DataBase Adapter5                
                    OleDbDataAdapter DBAdapter5 = new OleDbDataAdapter("select * from lecturer where lect_id  in (SELECT Lect_id from reg_lect where sub_ind in(select sub_ind from subject where Sub_ind =" + comboBox4.SelectedValue.ToString() + "and Dept_id=" + comboBox1.SelectedValue.ToString() + "and class_id=" + comboBox2.SelectedValue.ToString() + "and sem_id=" + comboBox3.SelectedValue.ToString() + ") ) and Dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                    // OleDbDataAdapter DBAdapter5 = new OleDbDataAdapter("select * from Lecturer where lect_id  in (select  lect_id from reg_lect ) and dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                    //Declare Data Set5
                    DataSet DS5 = new DataSet();
                    //Intialise IRecordCount5 to 0; IRecordCount is use to store no. of record afected
                    int IRecordCount5 = 0;
                    //Fill DataBase Adapter5 and set IRecordCount5
                    IRecordCount5 = DBAdapter5.Fill(DS5, "Lecturer");
                    //Set Data Table5
                    DataTable DT5 = DS5.Tables["Lecturer"];
                    //Set Data View1
                    DataView DV5 = DT5.DefaultView;
                    //set Combobox Data source to Data View 5
                    comboBox5.DataSource = DV5;
                    //Set DisplayMember and ValueMember of Combobox5
                    comboBox5.DisplayMember = "LECT_NAME";
                    comboBox5.ValueMember = "LECT_ID";
                    //Dispose DataTable5, DataSet5, DataBase Adapter5 
                    DT5.Dispose();
                    DS5.Dispose();
                    DBAdapter5.Dispose();
                }
                else
                    comboBox5.DataSource = null;
                BLect = true;                
            }
        }

        //This method will load Lecturer List in combobox5 respectively if subject is changed
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BSub == true)
            {
                //Load List of Registered Lecturer in Combobox2
                BLect = false;
                if (comboBox1.SelectedValue != null && comboBox4.SelectedValue != null)
                {
                    //Get DataBase Adapter5                
                    OleDbDataAdapter DBAdapter5 = new OleDbDataAdapter("select * from lecturer where lect_id  in (SELECT Lect_id from reg_lect where sub_ind in(select sub_ind from subject where Sub_ind =" + comboBox4.SelectedValue.ToString() + "and Dept_id=" + comboBox1.SelectedValue.ToString() + "and class_id=" + comboBox2.SelectedValue.ToString() + "and sem_id=" + comboBox3.SelectedValue.ToString() + ") ) and Dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                    // OleDbDataAdapter DBAdapter5 = new OleDbDataAdapter("select * from Lecturer where lect_id  in (select  lect_id from reg_lect ) and dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                    //Declare Data Set5
                    DataSet DS5 = new DataSet();
                    //Intialise IRecordCount5 to 0; IRecordCount is use to store no. of record afected
                    int IRecordCount5 = 0;
                    //Fill DataBase Adapter5 and set IRecordCount5
                    IRecordCount5 = DBAdapter5.Fill(DS5, "Lecturer");
                    //Set Data Table5
                    DataTable DT5 = DS5.Tables["Lecturer"];
                    //Set Data View1
                    DataView DV5 = DT5.DefaultView;
                    //set Combobox Data source to Data View 5
                    comboBox5.DataSource = DV5;
                    //Set DisplayMember and ValueMember of Combobox5
                    comboBox5.DisplayMember = "LECT_NAME";
                    comboBox5.ValueMember = "LECT_ID";
                    //Dispose DataTable5, DataSet5, DataBase Adapter5 
                    DT5.Dispose();
                    DS5.Dispose();
                    DBAdapter5.Dispose();
                }
                else
                    comboBox5.DataSource = null;
                BLect = true;

            }
        }

        //This method will display Attendance Sheet
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null && comboBox4.SelectedValue != null && comboBox5.SelectedValue != null )
            {
                OleDbCommand DBCom8 = new OleDbCommand("select rlc_index from reg_lect where sub_ind=" + comboBox4.SelectedValue.ToString() + " and lect_id =" + comboBox5.SelectedValue.ToString(), DBCon1);
                int Reg_Sub_Ind = 0;
                try
                {
                    Reg_Sub_Ind = (int)DBCom8.ExecuteScalar();
                }
                catch (System.NullReferenceException)
                {
                    Reg_Sub_Ind = 0;
                }

                if (Reg_Sub_Ind > 0)
                {
                    string s;
                    bool BMonth = false;
                    if (int.Parse(comboBox3.SelectedValue.ToString()) % 2 == 0)
                    {
                        s = "Select student_id, student_name, Month1LA,Month2LA,Month3LA,Month4LA,Month5LA,Month6LA, Totallc,Totalla,Percentage from RSUBJECT" + Reg_Sub_Ind.ToString() + " order by student_id";
                        BMonth = false;
                    }
                    else
                    {
                        s = "Select student_id, student_name, Month7LA,Month8LA,Month9LA,Month10LA,Month11LA,Month12LA, Totallc,Totalla,Percentage from RSUBJECT" + Reg_Sub_Ind.ToString() + " order by student_id";
                        BMonth = true;
                    }
                    OleDbDataAdapter DBAdapter7 = new OleDbDataAdapter(s, DBCon1);
                    DataSet DS7 = new DataSet();
                    int i7 = DBAdapter7.Fill(DS7, "Student");
                    DataTable DT7 = DS7.Tables["Student"];
                    DataView DV7 = DT7.DefaultView;
                    dataGridView1.DataSource = DV7;
                    dataGridView1.Columns[0].HeaderText = "Student Roll No.";
                    dataGridView1.Columns[1].HeaderText = "Student Name";
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].ReadOnly = true;

                    dataGridView1.Columns[0].Width = 50;
                    dataGridView1.Columns[1].Width = 150;
                    dataGridView1.Columns[2].Width = 75;
                    dataGridView1.Columns[3].Width = 75;
                    dataGridView1.Columns[4].Width = 75;
                    dataGridView1.Columns[5].Width = 75;
                    dataGridView1.Columns[6].Width = 75;
                    dataGridView1.Columns[7].Width = 75;
                    dataGridView1.Columns[8].Width = 75;
                    dataGridView1.Columns[9].Width = 75;
                    dataGridView1.Columns[10].Width = 75;

                    if (BMonth == true)
                    {
                        dataGridView1.Columns[2].HeaderText = "July";
                        dataGridView1.Columns[3].HeaderText = "August";
                        dataGridView1.Columns[4].HeaderText = "September";
                        dataGridView1.Columns[5].HeaderText = "October";
                        dataGridView1.Columns[6].HeaderText = "November";
                        dataGridView1.Columns[7].HeaderText = "December";
                    }
                    else
                    {
                        dataGridView1.Columns[2].HeaderText = "January";
                        dataGridView1.Columns[3].HeaderText = "February";
                        dataGridView1.Columns[4].HeaderText = "March";
                        dataGridView1.Columns[5].HeaderText = "April";
                        dataGridView1.Columns[6].HeaderText = "May";
                        dataGridView1.Columns[7].HeaderText = "June";
                    }

                    dataGridView1.Columns[8].HeaderText = "Total Lectures Conducted";
                    dataGridView1.Columns[9].HeaderText = "Total Lectures Attended";
                    DBAdapter7.Dispose();
                    DS7.Dispose();
                    DT7.Dispose();
                    BIsGridDisplay = true;
                }
                else
                    BIsGridDisplay = false;
            }
        }

        //This method will build word based attenance document
        private void button2_Click(object sender, EventArgs e)
        {
            
            
            if (BIsGridDisplay == true)
            {
                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc"; // endofdoc is a predefined bookmark 

                //Start Word and create a new document.
                Word._Application oWord;
                Word._Document oDoc;
                oWord = new Word.Application();
                oWord.Visible = true;
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);

                oDoc.PageSetup.PaperSize = Word.WdPaperSize.wdPaperLegal;
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                //Insert a paragraph at the beginning of the document.
                Word.Paragraph oPara1;
                oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
                oPara1.Range.Text = "Vijay Mukhi's Computer Institute";
                oPara1.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oPara1.Range.Font.Bold = 1;
                oPara1.Format.SpaceAfter = 24;    //24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter();

                //Insert a paragraph at the end of the document.
                Word.Paragraph oPara2;
                object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara2 = oDoc.Content.Paragraphs.Add(ref oRng);

                oPara2.Range.Text = "Department Name: " + comboBox1.Text.ToString() + "                  Class Name: " + comboBox2.Text.ToString() + "           Semester: " + comboBox3.SelectedValue.ToString() + "           Subject Name: " + comboBox4.Text.ToString();

                oPara2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oPara2.Format.SpaceAfter = 6;
                oPara2.Range.InsertParagraphAfter();

                //Insert another paragraph.
                Word.Paragraph oPara3;
                oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara3.Range.Text = "Lecturer Name: " + comboBox5.Text.ToString();
                oPara3.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                oPara3.Format.SpaceAfter = 24;
                oPara3.Range.InsertParagraphAfter();

                //Insert a attendance sheet
                //bold and italic.
                Word.Table oTable;
                Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oTable = oDoc.Tables.Add(wrdRng, dataGridView1.RowCount+1, dataGridView1.ColumnCount, ref oMissing, ref oMissing);
                
                object Ot;
                Ot = Word.WdTableFormat.wdTableFormatGrid1;

                oTable.AutoFormat(ref Ot, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                oTable.Range.ParagraphFormat.SpaceAfter = 6;

                oTable.Cell(1, 1).Range.Text = dataGridView1.Columns[0].HeaderText.ToString();
                oTable.Cell(1, 2).Range.Text = dataGridView1.Columns[1].HeaderText.ToString();
                oTable.Cell(1, 3).Range.Text = dataGridView1.Columns[2].HeaderText.ToString();
                oTable.Cell(1, 4).Range.Text = dataGridView1.Columns[3].HeaderText.ToString();
                oTable.Cell(1, 5).Range.Text = dataGridView1.Columns[4].HeaderText.ToString();
                oTable.Cell(1, 6).Range.Text = dataGridView1.Columns[5].HeaderText.ToString();
                oTable.Cell(1, 7).Range.Text = dataGridView1.Columns[6].HeaderText.ToString();
                oTable.Cell(1, 8).Range.Text = dataGridView1.Columns[7].HeaderText.ToString();
                oTable.Cell(1, 9).Range.Text = dataGridView1.Columns[8].HeaderText.ToString();
                oTable.Cell(1, 10).Range.Text = dataGridView1.Columns[9].HeaderText.ToString();
                oTable.Cell(1, 11).Range.Text = dataGridView1.Columns[10].HeaderText.ToString();


                int r, c;
                string strText;
                for (r = 0; r < dataGridView1.RowCount; r++)
                    for (c = 0; c < 11; c++)
                    {
                        strText = dataGridView1.Rows[r].Cells[c].Value.ToString();
                        oTable.Cell(r + 2, c + 1).Range.Text = strText;
                    }

                oTable.Rows[1].Range.Font.Bold = 1;
                oTable.Rows[1].Range.Font.Italic = 1;                
            }
            else
            {
                MessageBox.Show("Please Show attendance first"); 
            }
        }
    }
}