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
    //Form22: Display "Register Lecturer Name for a Subject" form
    public partial class Form22 : Form
    {
        OleDbConnection DBCon1;
        bool BDept;
        bool BClass;
        bool BSem;
        bool BSub;
        bool BLect;
        int IMRegSInd;

        public Form22()
        {
            InitializeComponent();

            //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");

            //Open DataBase Connection 1
            DBCon1.Open();
            
            //Intialise Maximum Register Subject Index
            IMRegSInd = 0;

        }

        ~Form22()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        ////This method will load Department, Class, Semester, Subject and Lecturer List in combobox1, combobox2, combobox3, combobox4 & combobox5 respectively
        //and retrive max registered subject id from database
        private void Form22_Load(object sender, EventArgs e)
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

           

            //Load subject List in Combobox4
            BSub = false;
            //Get DataBase Adapter4
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null)
            {
                OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("select * from subject where dept_id =" + comboBox1.SelectedValue.ToString() + " and class_id =" + comboBox2.SelectedValue.ToString() + " and sem_id =" + comboBox3.SelectedValue.ToString(), DBCon1);
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

            //Load List of Lecturer in Combobox2
            BLect = false;
            if (comboBox1.SelectedValue != null)
            {
                //Get DataBase Adapter5
                OleDbDataAdapter DBAdapter5 = new OleDbDataAdapter("select * from Lecturer where dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
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
            BLect = true;

            //Get Max Registered Subject Index
            OleDbCommand DBCom1 = new OleDbCommand("SELECT MAX(RLC_INDEX) AS Expr1 FROM REG_LECT", DBCon1);
            try
            {
                
                IMRegSInd = (int)DBCom1.ExecuteScalar();
                DBCom1.Dispose();
            }
            catch (System.NullReferenceException)
            {
                IMRegSInd = 0;
            }
            catch (System.InvalidCastException)
            {
                IMRegSInd = 0;
            }
            IMRegSInd++;
        }

        //This method will load Class and Subject List in combobox2 and combobox4 respectively if department name is changed        
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

                //Load subject List in Combobox4
                BSub = false;
                //Get DataBase Adapter4
                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null)
                {
                    OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("select * from subject where dept_id =" + comboBox1.SelectedValue.ToString() + " and class_id =" + comboBox2.SelectedValue.ToString() + " and sem_id =" + comboBox3.SelectedValue.ToString(), DBCon1);
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
                else
                    comboBox4.DataSource = null;
                BSub = true;

                //Load List of Lecturer in Combobox2
                BLect = false;
                if (comboBox1.SelectedValue != null)
                {
                    //Get DataBase Adapter5
                    OleDbDataAdapter DBAdapter5 = new OleDbDataAdapter("select * from Lecturer where dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
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
                BLect = true;
            }
        }

        //This method will load Subject List in combobox4 if class name is changed        
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BClass == true)
            {
                //Load subject List in Combobox4
                BSub = false;
                //Get DataBase Adapter4
                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null)
                {
                    OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("select * from subject where dept_id =" + comboBox1.SelectedValue.ToString() + " and class_id =" + comboBox2.SelectedValue.ToString() + " and sem_id =" + comboBox3.SelectedValue.ToString(), DBCon1);
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
            }
        }

        //This method will load Subject List in combobox4 if semester name is changed        
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BSem == true)
            {
                //Load subject List in Combobox4
                BSub = false;
                //Get DataBase Adapter4
                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null)
                {
                    OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("select * from subject where dept_id =" + comboBox1.SelectedValue.ToString() + " and class_id =" + comboBox2.SelectedValue.ToString() + " and sem_id =" + comboBox3.SelectedValue.ToString(), DBCon1);
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
                else
                    comboBox4.DataSource = null;
                BSub = true;

            }
        }

        //This method will register lecturer name to a subject
        private void button1_Click(object sender, EventArgs e)
        {
            //Update Entry
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null && comboBox4.SelectedValue != null && comboBox5.SelectedValue != null)
            {
                //Mistake sub_ind is already available 

                OleDbCommand DBCom2 = new OleDbCommand("select SUB_IND from SUBJECT where DEPT_ID=" + comboBox1.SelectedValue.ToString() + " and CLASS_ID = " + comboBox2.SelectedValue.ToString() + " and SEM_ID=" + comboBox3.SelectedValue.ToString() + " and SUB_IND=" + comboBox4.SelectedValue.ToString(), DBCon1);
                int ISub_Ind=0;
                try
                {
                    ISub_Ind = (int)DBCom2.ExecuteScalar();
                }
                catch (System.NullReferenceException)
                {
                    ISub_Ind = 0;
                }

                DBCom2.Dispose();

                if (ISub_Ind != 0)
                {
                    OleDbCommand DBCom3 = new OleDbCommand("select SUB_IND from REG_LECT where SUB_IND=" + ISub_Ind.ToString() + "and lect_id =" + comboBox5.SelectedValue.ToString(), DBCon1);
                    int ITSub_ind = 0;
                    try
                    {
                        ITSub_ind = (int)DBCom3.ExecuteScalar();
                    }
                    catch (System.NullReferenceException)
                    {
                        ITSub_ind = 0;
                    }

                    DBCom3.Dispose();
                    if (ITSub_ind != 0)
                    {
                        MessageBox.Show("The Lecturer is already Registered for this Subject");
                    }
                    else
                    {
                        OleDbCommand DBCom4 = new OleDbCommand("insert into reg_lect values (" + IMRegSInd.ToString() + "," + ISub_Ind.ToString() + "," + comboBox5.SelectedValue.ToString() + ")", DBCon1);
                        DBCom4.ExecuteNonQuery();                       
                        
                        DBCom4.Dispose();

                        //Create Subject Attendance Table                        
                        if (int.Parse(comboBox3.SelectedValue.ToString()) % 2 != 0)
                        {
                            OleDbCommand DBCom5 = new OleDbCommand("create table RSUBJECT" + IMRegSInd.ToString() + " ( Student_id integer, Student_name char(50), Month7LC integer, Month7LA integer, Month8LC integer, Month8LA integer, Month9LC integer, Month9LA integer, Month10LC integer, Month10LA integer, Month11LC integer, Month11LA integer, Month12LC integer, Month12LA integer, TotalLC integer, TotalLA integer, Percentage integer) ", DBCon1);
                            DBCom5.ExecuteNonQuery();
                            DBCom5.Dispose();
                        }
                        else
                        {
                            OleDbCommand DBCom6 = new OleDbCommand("create table RSUBJECT" + IMRegSInd.ToString() + " ( Student_id integer, Student_name char(50), Month1LC integer, Month1LA integer, Month2LC integer, Month2LA integer, Month3LC integer, Month3LA integer, Month4LC integer, Month4LA integer, Month5LC integer, Month5LA integer, Month6LC integer, Month6LA integer, TotalLC integer, TotalLA integer, Percentage integer) ", DBCon1);
                            DBCom6.ExecuteNonQuery();
                            DBCom6.Dispose();
                        }

                        MessageBox.Show("Subject is now Registered");
                        IMRegSInd++;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Subject");
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}