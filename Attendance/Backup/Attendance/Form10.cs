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
    //Form10: Display "New Lecturer Name" form.
    public partial class Form10 : Form
    {
        OleDbConnection DBCon1; // Database Connection 1
        int IMLect_ID;

        public Form10()
        {
            InitializeComponent();

            //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");

            //Intialise Max Class id to 0;
            IMLect_ID = 0;

            //Open DataBase Connection 1
            DBCon1.Open();
        }

         ~Form10()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This method will load Department List in Combobox1 & retrive Max Lecturer Id from database
        private void Form10_Load(object sender, EventArgs e)
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

            //Get MAximum Lecturer ID as Per Department
            if (comboBox1.SelectedValue != null)
            {
                //string SDeptID;
                OleDbCommand DBCom0;
                //OleDbDataReader DBRead0;
                DBCom0 = new OleDbCommand("SELECT MAX(LECT_ID) AS Expr1 FROM Lecturer" , DBCon1);
                try
                {
                    IMLect_ID = (int)DBCom0.ExecuteScalar();
                    DBCom0.Dispose();
                }
                catch (System.NullReferenceException)
                {
                    IMLect_ID = 0;
                    DBCom0.Dispose();
                }
                catch (System.InvalidCastException)
                {
                    IMLect_ID = 0;
                }


                IMLect_ID++;                
            }            
        }

        //This Method will add new Lecturer name in department
        private void button1_Click(object sender, EventArgs e)
        {
            //Initialise RichTextBox Lines Counter
            int IRTBLine = 0;

            for (IRTBLine = 0; IRTBLine < richTextBox1.Lines.Length; IRTBLine++)
            {

                if (string.Compare(richTextBox1.Lines[IRTBLine], "") != 0)
                {
                    OleDbCommand DBCom1;
                    DBCom1 = new OleDbCommand("select lect_name from lecturer where lect_name='" + richTextBox1.Lines[IRTBLine] + "' and dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                    
                    string SLect_name;
                    SLect_name = (string)DBCom1.ExecuteScalar();
                    DBCom1.Dispose();
                    if (string.Compare(SLect_name, richTextBox1.Lines[IRTBLine].ToString()) == 0)
                    {
                        MessageBox.Show("Lecturer Name =" + richTextBox1.Lines[IRTBLine] + " is skiped because it is already exist");
                    }
                    else
                    {
                        //MessageBox.Show("insert into Lecturer values(" + comboBox1.SelectedValue.ToString() + "," + IMLect_ID + ",'" + richTextBox1.Lines[IRTBLine].ToString() + "')");
                        OleDbCommand DBCom2 = new OleDbCommand("insert into Lecturer values(" + comboBox1.SelectedValue.ToString() + "," + IMLect_ID + ",'" + richTextBox1.Lines[IRTBLine].ToString() + "')", DBCon1);
                        DBCom2.ExecuteNonQuery();
                        DBCom2.Dispose();
                        IMLect_ID++;
                    }
                }
            }

            //Clear RichTextBox1
            richTextBox1.ResetText();            
        }
    }
}