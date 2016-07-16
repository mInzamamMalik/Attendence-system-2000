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

    //Form18: Display "New Student Name" form
    public partial class Form18 : Form
    {
        OleDbConnection DBCon1;
        bool BDept;
        static bool BClass;
        int IMStu_ID;

        public Form18()
        {
            InitializeComponent();

            //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");

            //Intialise Max Student ID to 0;
            IMStu_ID = 0;

            //Set Depatment Flag to false
            BDept = false;

           
            //Open DataBase Connection 1
            DBCon1.Open();
        }

        ~Form18()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This method will load Department, Class List in combobox1, combobox2 respectively and
        //Retrive max student id from database
        private void Form18_Load(object sender, EventArgs e)
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
                //Dispose DataTable1, DataSet1, DataBase Adapter 1 
                DT2.Dispose();
                DS2.Dispose();
                DBAdapter2.Dispose();
            }
            
            //Set Class Flag to true
            BClass = true;
            //Set Department Flag to true
            BDept = true;
            
            //Get Maximum Student ID in Class
            
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null)
            {
                OleDbCommand DBCom1 = new OleDbCommand("SELECT MAX(STUDENT_ID) AS Expr1 FROM STUDENT WHERE DEPT_ID =" + comboBox1.SelectedValue.ToString() + " AND CLASS_ID =" + comboBox2.SelectedValue.ToString(), DBCon1);
                
                int IStud_ID=0;
                try
                {
                    IStud_ID = (int) DBCom1.ExecuteScalar();
                     
                }
                catch (System.InvalidCastException)
                {
                    IStud_ID = 0;
                }

                label7.Text = IStud_ID.ToString();
                IMStu_ID = IStud_ID + 1;                
            }
            // 
        }

        ////This method will load Class List in combobox2 and retrive max student_id form database if Department name is changed
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
            
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && BDept==true)
            {
                OleDbCommand DBCom1 = new OleDbCommand("SELECT MAX(STUDENT_ID) AS Expr1 FROM STUDENT WHERE DEPT_ID =" + comboBox1.SelectedValue.ToString() + " AND CLASS_ID =" + comboBox2.SelectedValue.ToString(), DBCon1);

                int IStud_ID = 0;
                try
                {
                    IStud_ID = (int)DBCom1.ExecuteScalar();

                }
                catch (System.InvalidCastException)
                {
                    IStud_ID = 0;
                }

                label7.Text = IStud_ID.ToString();
                IMStu_ID = IStud_ID + 1;               
            }
            //Set Class Flag to True
            BClass = true;    
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
            int IRTB_Linec = 0;
            int ICount = 0;
            int ICNum = 0;
            for (IRTB_Linec = 0; IRTB_Linec < richTextBox1.Lines.Length; IRTB_Linec++)
            {

                if (string.Compare(richTextBox1.Lines[IRTB_Linec], "") != 0)
                {                    
                    ICount = IMStu_ID + ICNum;
                    label5.Text = ICount.ToString();
                    ICNum++;
                }
            }
        }

        //Retrive max student_id form database if Class name is changed
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (BClass == true && comboBox1.SelectedValue != null && comboBox2.SelectedValue != null)
            {                
                OleDbCommand DBCom1 = new OleDbCommand("SELECT MAX(STUDENT_ID) AS Expr1 FROM STUDENT WHERE DEPT_ID =" + comboBox1.SelectedValue.ToString() + " AND CLASS_ID =" + comboBox2.SelectedValue.ToString(), DBCon1);
                string SStud_ID;
                int IStud_ID = 0;
                try
                {
                    SStud_ID = (string)DBCom1.ExecuteScalar();
                    IStud_ID = Int32.Parse(SStud_ID);
                }
                catch (System.InvalidCastException)
                {
                    IStud_ID = 0;
                }

                label7.Text = IStud_ID.ToString();
                IMStu_ID = IStud_ID + 1;
            }
        }

        //Add new student in database
        private void button1_Click(object sender, EventArgs e)
        {
            int IRTBLinec = 0;
            for (IRTBLinec = 0; IRTBLinec < richTextBox1.Lines.Length; IRTBLinec++)
            {
                if (string.Compare(richTextBox1.Lines[IRTBLinec], "") != 0)
                {
                    string SStud_name;
                    OleDbCommand DBCom1 = new OleDbCommand("select student_name from student where student_name='" + richTextBox1.Lines[IRTBLinec].ToString() + "' and dept_id =" + comboBox1.SelectedValue.ToString() + " and class_id =" + comboBox2.SelectedValue.ToString(),DBCon1 );
                    SStud_name = (string)DBCom1.ExecuteScalar();
                    DBCom1.Dispose();
                    if (string.Compare(SStud_name, richTextBox1.Lines[IRTBLinec].ToString()) != 0)
                    {
                        OleDbCommand DBCom2 = new OleDbCommand("insert into student values(" + comboBox1.SelectedValue.ToString() + "," + comboBox2.SelectedValue.ToString() + "," + IMStu_ID + ",'" + richTextBox1.Lines[IRTBLinec].ToString() + "')", DBCon1);
                        DBCom2.ExecuteNonQuery();
                        DBCom2.Dispose();
                        IMStu_ID++;
                    }
                }
            }
            int ITemp = IMStu_ID - 1;
           label7.Text = ITemp.ToString();
           richTextBox1.ResetText(); 
        }
    }
}