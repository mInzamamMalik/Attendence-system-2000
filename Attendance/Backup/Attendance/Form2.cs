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
    //Form2: Display "New Departemnt Name" form

    public partial class Form2 : Form
    {
        OleDbConnection DBCon1; // Database Connection 
        int IDept_id; // Department ID counter (Integer)

        public Form2()
        {
            InitializeComponent();

            //Intialise New Database Connection 
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");
            
            //Open Database Connection
            DBCon1.Open();
        }
        
        ~Form2()
        {
            //Close DataBase Connection
            DBCon1.Close();
        }
        
        //This method will provide Max DepartmentId to add new Department
        private void Form2_Load(object sender, EventArgs e)
        {
            //Get Next Department ID                
                OleDbCommand DBcom1; // Database Command1                
                //Set Command to select Maximum Department ID
                DBcom1 = new OleDbCommand("SELECT MAX(DEPT_ID) AS Expr1 FROM DEPARTMENT", DBCon1);            
                // Read From Database
                try
                {
                    IDept_id = (int)DBcom1.ExecuteScalar();
                }
                catch (System.NullReferenceException)
                {
                    IDept_id = 0;
                }
                catch (System.InvalidCastException)
                {
                    IDept_id = 0;
                }

                // Increment Department ID counter for next Department
                IDept_id++;
                
                //Dispose Database Command 1
                DBcom1.Dispose();
                
        }

        //This Method will Add New Department in Database
        private void button1_Click(object sender, EventArgs e)
        {
            int IRTBLines = 0; // Counter Represent Lines from RichTextBox
            //Read Lines from RichTextBox
            for (IRTBLines = 0; IRTBLines < richTextBox1.Lines.Length; IRTBLines++)            
            {
                //If IRTBLine is not Null Then
                if (string.Compare(richTextBox1.Lines[IRTBLines], "") != 0)
                {
                    //Data Base Command 2
                    OleDbCommand DBcom2 = new OleDbCommand("select * from department where dept_name ='" + richTextBox1.Lines[IRTBLines] + "'", DBCon1);

                    //Database Reader 2                    
                    OleDbDataReader DBRead2;

                    //Read From Database
                    DBRead2 = DBcom2.ExecuteReader();

                    // Check if Department Name is Exist
                    if (DBRead2.HasRows)
                    {
                        //Department Name is Already Exist
                        MessageBox.Show("Department Name =" + richTextBox1.Lines[IRTBLines] + " is skiped because it is already exist");                        
                        
                        //Dispose Database command 2 and reader 2
                        DBRead2.Dispose();
                        DBcom2.Dispose();                        
                    }
                    else
                    {
                        //Department Name is Not Already Exist                                                                       
                        //Database Command3 String
                        string SCom1 = "insert into department values(" + IDept_id + ",'" + richTextBox1.Lines[IRTBLines].ToString() + "')";
                        //Dispose Databse command 2 and reader 2
                        DBRead2.Dispose();
                        DBcom2.Dispose(); 

                        //Database Command 3
                        OleDbCommand DBcom3 = new OleDbCommand(SCom1, DBCon1);

                        //Execute Database Command 3.
                        DBcom3.ExecuteNonQuery();

                        //Dispose Database Command 3
                        DBcom3.Dispose();

                        //Increment Department ID Counter
                        IDept_id++;
                    }

                }
            }

            //Clear RichTextBox1 Content
            richTextBox1.ResetText();
            
        }
    }
}