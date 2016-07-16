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
    //Form6: Display "New Class Name" form.
    public partial class Form6 : Form
    {
        OleDbConnection DBCon1; // Database Connection 1
        int IMClass_ID; //Class ID 

        public Form6()
        {
            InitializeComponent();

            //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");

            //Intialise Max Class id to 0;
            IMClass_ID = 0;

            //Open DataBase Connection 1
            DBCon1.Open();
        }

        ~Form6()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This mentod loads department list in combobox1 and retrive maximum cloass id from database
        private void Form6_Load(object sender, EventArgs e)
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

            //Get MAximum Class Id as Per Department
            if (comboBox1.SelectedValue != null)
            {
                string SDeptID;
                OleDbCommand DBCom0;
                OleDbDataReader DBRead0;
                DBCom0 = new OleDbCommand("SELECT MAX(CLASS_ID) AS Expr1 FROM CLASS WHERE DEPT_ID=" + comboBox1.SelectedValue.ToString(), DBCon1);
                DBRead0 = DBCom0.ExecuteReader();
                DBRead0.Read();
                SDeptID = string.Copy(DBRead0.GetValue(0).ToString());
                if (string.Compare(SDeptID, "") == 0)
                    IMClass_ID = 0;
                else
                    IMClass_ID = Int32.Parse(SDeptID);

                IMClass_ID++;
                DBCom0.Dispose();
            }
            else
            {
                MessageBox.Show("No Department Exist");               
            }
        }

        //Thsi method will add new class in department
        private void button1_Click(object sender, EventArgs e)
        {
            //Initialise RichTextBox Lines Counter
            int IRTBLine = 0;

            for (IRTBLine = 0; IRTBLine < richTextBox1.Lines.Length; IRTBLine++)
            {

                if (string.Compare(richTextBox1.Lines[IRTBLine], "") != 0)
                {
                    OleDbCommand DBCom1;
                    DBCom1 = new OleDbCommand ("select * from class where class_name='" + richTextBox1.Lines[IRTBLine] + "' and dept_id =" + comboBox1.SelectedValue.ToString(),DBCon1 );

                    string SClass_name;
                    SClass_name = (string)DBCom1.ExecuteScalar();
                    DBCom1.Dispose();
                    if(string.Compare(SClass_name, richTextBox1.Lines[IRTBLine].ToString())==0)
                    {
                        MessageBox.Show("Class Name =" + richTextBox1.Lines[IRTBLine] + " is skiped because it is already exist");                        
                    }
                    else
                    {                        
                        
                        OleDbCommand DBCom2 = new OleDbCommand("insert into class values(" + comboBox1.SelectedValue.ToString() + "," + IMClass_ID + ",'" + richTextBox1.Lines[IRTBLine].ToString() + "')", DBCon1);
                        DBCom2.ExecuteNonQuery();
                        DBCom2.Dispose();
                        IMClass_ID++;
                    }
                }
            }

            //Clear RichTextBox1
            richTextBox1.ResetText();
            
        }

        //This method will change max. class id if another department name is selected
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Get MAximum Class Id as Per Department
            if (comboBox1.SelectedValue != null)
            {
                string SDeptID;
                OleDbCommand DBCom0;
                OleDbDataReader DBRead0;
                DBCom0 = new OleDbCommand("SELECT MAX(CLASS_ID) AS Expr1 FROM CLASS WHERE DEPT_ID=" + comboBox1.SelectedValue.ToString(), DBCon1);
                DBRead0 = DBCom0.ExecuteReader();
                DBRead0.Read();
                SDeptID = string.Copy(DBRead0.GetValue(0).ToString());
                if (string.Compare(SDeptID, "") == 0)
                    IMClass_ID = 0;
                else
                    IMClass_ID = Int32.Parse(SDeptID);

                IMClass_ID++;
                DBCom0.Dispose();
            }
            else
            {
                MessageBox.Show("No Department Exist");
            }
        }
    }
}