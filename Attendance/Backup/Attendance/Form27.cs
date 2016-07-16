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
    //Form27: Display "Display List of registered Student for a subject" form
    public partial class Form27 : Form
    {
        OleDbConnection DBCon1;
        bool BDept;
        bool BClass;
        bool BSem;
        bool BSub;
        bool BLect;

        public Form27()
        {
            InitializeComponent();
         
             //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");

            //Open DataBase Connection 1
            DBCon1.Open();
        }

        ~Form27()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This method will load Department, Class, Semester, Subject and Lecturer List in combobox1, combobox2, combobox3, combobox4 & combobox5 respectively
        //This method will also load Register Student list in datagridview1
        private void Form27_Load(object sender, EventArgs e)
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

            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null && comboBox4.SelectedValue != null && comboBox5.SelectedValue != null)
            {
                OleDbCommand DBCom1 = new OleDbCommand("select rlc_index from reg_lect where sub_ind=" + comboBox4.SelectedValue.ToString() + " and lect_id =" + comboBox5.SelectedValue.ToString(), DBCon1);
                int Reg_Sub_Ind = 0;
                try
                {
                    Reg_Sub_Ind = (int)DBCom1.ExecuteScalar();
                }
                catch (System.NullReferenceException)
                {
                    Reg_Sub_Ind = 0;
                }
                if (Reg_Sub_Ind > 0)
                {
                    OleDbDataAdapter DBAdapter2 = new OleDbDataAdapter("Select Student_id, Student_name from Student where student_id in(select student_id from RSUBJECT" + Reg_Sub_Ind + ") and dept_id=" + comboBox1.SelectedValue.ToString() + " and class_id=" + comboBox2.SelectedValue.ToString() + " order by student_id", DBCon1);
                    DataSet DS = new DataSet();
                    int i = DBAdapter2.Fill(DS, "Student");
                    DataTable DT = DS.Tables["Student"];
                    DataView DV = DT.DefaultView;
                    dataGridView1.DataSource = DV;
                    dataGridView1.Columns[0].HeaderText = "Student Roll No.";
                    dataGridView1.Columns[1].HeaderText = "Student Name";
                    DBAdapter2.Dispose();
                }
                else
                    dataGridView1.DataSource = null;
            }
        }


        //This method will load Class, Subject and Lecturer List in combobox2, combobox4 & combobox5 respectively if Department is Changed
        //This method will also load Register Student list in datagridview1
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Load List of Class in Combobox2
            if (BDept == true)
            {
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


                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null && comboBox4.SelectedValue != null && comboBox5.SelectedValue != null)
                {
                    OleDbCommand DBCom1 = new OleDbCommand("select rlc_index from reg_lect where sub_ind=" + comboBox4.SelectedValue.ToString() + " and lect_id =" + comboBox5.SelectedValue.ToString(), DBCon1);
                    int Reg_Sub_Ind = 0;
                    try
                    {
                        Reg_Sub_Ind = (int)DBCom1.ExecuteScalar();
                    }
                    catch (System.NullReferenceException)
                    {
                        Reg_Sub_Ind = 0;
                    }
                    if (Reg_Sub_Ind > 0)
                    {
                        OleDbDataAdapter DBAdapter1 = new OleDbDataAdapter("Select Student_id, Student_name from Student where student_id in(select student_id from RSUBJECT" + Reg_Sub_Ind + ") and dept_id=" + comboBox1.SelectedValue.ToString() + " and class_id=" + comboBox2.SelectedValue.ToString() + " order by student_id", DBCon1);
                        DataSet DS = new DataSet();
                        int i = DBAdapter1.Fill(DS, "Student");
                        DataTable DT = DS.Tables["Student"];
                        DataView DV = DT.DefaultView;
                        dataGridView1.DataSource = DV;
                        dataGridView1.Columns[0].HeaderText = "Student Roll No.";
                        dataGridView1.Columns[1].HeaderText = "Student Name";
                        DBAdapter1.Dispose();
                    }
                }
                else
                    dataGridView1.DataSource = null;
 
            }
        }
        
        //This method will load Subject and Lecturer List in  combobox4 & combobox5 respectively if class is Changed
        //This method will also load Register Student list in datagridview1
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
                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null && comboBox4.SelectedValue != null && comboBox5.SelectedValue != null)
                {
                    OleDbCommand DBCom1 = new OleDbCommand("select rlc_index from reg_lect where sub_ind=" + comboBox4.SelectedValue.ToString() + " and lect_id =" + comboBox5.SelectedValue.ToString(), DBCon1);
                    int Reg_Sub_Ind = 0;
                    try
                    {
                        Reg_Sub_Ind = (int)DBCom1.ExecuteScalar();
                    }
                    catch (System.NullReferenceException)
                    {
                        Reg_Sub_Ind = 0;
                    }
                    if (Reg_Sub_Ind > 0)
                    {
                        OleDbDataAdapter DBAdapter1 = new OleDbDataAdapter("Select Student_id, Student_name from Student where student_id in(select student_id from RSUBJECT" + Reg_Sub_Ind + ") and dept_id=" + comboBox1.SelectedValue.ToString() + " and class_id=" + comboBox2.SelectedValue.ToString() + " order by student_id", DBCon1);
                        DataSet DS = new DataSet();
                        int i = DBAdapter1.Fill(DS, "Student");
                        DataTable DT = DS.Tables["Student"];
                        DataView DV = DT.DefaultView;
                        dataGridView1.DataSource = DV;
                        dataGridView1.Columns[0].HeaderText = "Student Roll No.";
                        dataGridView1.Columns[1].HeaderText = "Student Name";
                        DBAdapter1.Dispose();
                    }
                    else
                        dataGridView1.DataSource = null;
                }
 
            }
        }

        //This method will load Subject and Lecturer List in combobox4 & combobox5 respectively if semester is Changed
        //This method will also load Register Student list in datagridview1
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

                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null && comboBox4.SelectedValue != null && comboBox5.SelectedValue != null)
                {
                    OleDbCommand DBCom1 = new OleDbCommand("select rlc_index from reg_lect where sub_ind=" + comboBox4.SelectedValue.ToString() + " and lect_id =" + comboBox5.SelectedValue.ToString(), DBCon1);
                    int Reg_Sub_Ind = 0;
                    try
                    {
                        Reg_Sub_Ind = (int)DBCom1.ExecuteScalar();
                    }
                    catch (System.NullReferenceException)
                    {
                        Reg_Sub_Ind = 0;
                    }
                    if (Reg_Sub_Ind > 0)
                    {
                        OleDbDataAdapter DBAdapter1 = new OleDbDataAdapter("Select Student_id, Student_name from Student where student_id in(select student_id from RSUBJECT" + Reg_Sub_Ind + ") and dept_id=" + comboBox1.SelectedValue.ToString() + " and class_id=" + comboBox2.SelectedValue.ToString() + " order by student_id", DBCon1);
                        DataSet DS = new DataSet();
                        int i = DBAdapter1.Fill(DS, "Student");
                        DataTable DT = DS.Tables["Student"];
                        DataView DV = DT.DefaultView;
                        dataGridView1.DataSource = DV;
                        dataGridView1.Columns[0].HeaderText = "Student Roll No.";
                        dataGridView1.Columns[1].HeaderText = "Student Name";
                        DBAdapter1.Dispose();
                    }
                    else
                        dataGridView1.DataSource = null;
                }
 
            }
        }

        //This method will load Lecturer List in combobox5 if subject is Changed
        //This method will also load Register Student list in datagridview1
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

                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null && comboBox4.SelectedValue != null && comboBox5.SelectedValue != null)
                {
                    OleDbCommand DBCom1 = new OleDbCommand("select rlc_index from reg_lect where sub_ind=" + comboBox4.SelectedValue.ToString() + " and lect_id =" + comboBox5.SelectedValue.ToString(), DBCon1);
                    int Reg_Sub_Ind = 0;
                    try
                    {
                        Reg_Sub_Ind = (int)DBCom1.ExecuteScalar();
                    }
                    catch (System.NullReferenceException)
                    {
                        Reg_Sub_Ind = 0;
                    }
                    if (Reg_Sub_Ind > 0)
                    {
                        OleDbDataAdapter DBAdapter1 = new OleDbDataAdapter("Select Student_id, Student_name from Student where student_id in(select student_id from RSUBJECT" + Reg_Sub_Ind + ") and dept_id=" + comboBox1.SelectedValue.ToString() + " and class_id=" + comboBox2.SelectedValue.ToString() + " order by student_id", DBCon1);
                        DataSet DS = new DataSet();
                        int i = DBAdapter1.Fill(DS, "Student");
                        DataTable DT = DS.Tables["Student"];
                        DataView DV = DT.DefaultView;
                        dataGridView1.DataSource = DV;
                        dataGridView1.Columns[0].HeaderText = "Student Roll No.";
                        dataGridView1.Columns[1].HeaderText = "Student Name";
                        DBAdapter1.Dispose();
                    }
                    else
                        dataGridView1.DataSource = null;
                }
 
            }
        }

        //This method will load Register Student list in datagridview1
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BLect == true)
            {
                if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null && comboBox4.SelectedValue != null && comboBox5.SelectedValue != null)
                {
                    OleDbCommand DBCom1 = new OleDbCommand("select rlc_index from reg_lect where sub_ind=" + comboBox4.SelectedValue.ToString() + " and lect_id =" + comboBox5.SelectedValue.ToString(), DBCon1);
                    int Reg_Sub_Ind = 0;
                    try
                    {
                        Reg_Sub_Ind = (int)DBCom1.ExecuteScalar();
                    }
                    catch (System.NullReferenceException)
                    {
                        Reg_Sub_Ind = 0;
                    }
                    if (Reg_Sub_Ind > 0)
                    {
                        OleDbDataAdapter DBAdapter1 = new OleDbDataAdapter("Select Student_id, Student_name from Student where student_id in(select student_id from RSUBJECT" + Reg_Sub_Ind + ") and dept_id=" + comboBox1.SelectedValue.ToString() + " and class_id=" + comboBox2.SelectedValue.ToString() + " order by student_id", DBCon1);
                        DataSet DS = new DataSet();
                        int i = DBAdapter1.Fill(DS, "Student");
                        DataTable DT = DS.Tables["Student"];
                        DataView DV = DT.DefaultView;
                        dataGridView1.DataSource = DV;
                        dataGridView1.Columns[0].HeaderText = "Student Roll No.";
                        dataGridView1.Columns[1].HeaderText = "Student Name";
                        DBAdapter1.Dispose();
                    }
                    else
                        dataGridView1.DataSource = null;
                }
            }
        }
    }
}