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
    //Form3: Display "Modify Department Name" form.
    public partial class Form3 : Form
    {
        OleDbConnection DBCon1; // Database Connection 1

        public Form3()
        {
            InitializeComponent();

            //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");

            //Open DataBase Connection 1
            DBCon1.Open();
        }

        ~Form3()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This method will Display List of Department in Combobox1 
        private void Form3_Load(object sender, EventArgs e)
        {
            //Load List of Department in Combobox1
                //Get DataBase Adapter1
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
        }

        //This Method Modify Department Name (selected from combobox1)
        private void button1_Click(object sender, EventArgs e)
        {
            //Check if Existing and New Department Name Exist or not
            if (comboBox1.SelectedValue != null && string.Compare(textBox1.Text, "") != 0)
            {
                // set DataBase Command1 
                OleDbCommand DBCom1 = new OleDbCommand("select DEPT_NAME from department where dept_name= '" + textBox1.Text + "'", DBCon1);                
                // Get Department Name from Database which already exist
                string DeptName = (string)DBCom1.ExecuteScalar();
                
                //Dispose DataBase Command 2
                DBCom1.Dispose();
                
                //Check if New department name is already exist or not
                if (string.Compare(DeptName, textBox1.Text.ToString()) == 0)
                {
                    //New Department Name is alreasdy exist
                    MessageBox.Show(textBox1.Text + " already exist");                
                }
                else
                {                     
                     //Set DataBase Command 2                    
                    OleDbCommand DBCom2 = new OleDbCommand("update department set dept_name='" + textBox1.Text.Trim() + "' where dept_id=" + comboBox1.SelectedValue.ToString(), DBCon1);
                    //Excute DataBase Command 2
                    DBCom2.ExecuteNonQuery();
                    //Dispose DataBase Command 2
                    DBCom2.Dispose();

                    //Load Modified List of Department in Combobox1
                    //Get DataBase Adapter
                    OleDbDataAdapter DBAdapter2 = new OleDbDataAdapter("select * from department", DBCon1);

                    //Declare Data Set1
                    DataSet DS2 = new DataSet();

                    //Intialise IRecordCount to 0; IRecordCount is use to store no. of record afected
                    int IRecordCount2 = 0;

                    //Fill DataBase Adapter1 and set IRecordCount
                    IRecordCount2 = DBAdapter2.Fill(DS2, "Department");

                    //Set Data Table1
                    DataTable DT2 = DS2.Tables["Department"];

                    //Set Data View1
                    DataView DV2 = DT2.DefaultView;

                    //set Combobox Data source to Data View 1
                    comboBox1.DataSource = DV2;

                    //Set DisplayMember and ValueMember of Combobox1
                    comboBox1.DisplayMember = "DEPT_NAME";
                    comboBox1.ValueMember = "DEPT_ID";

                    //Dispose DataTable1, DataSet1, DataBase Adapter 1 
                    DT2.Dispose();
                    DS2.Dispose();
                    DBAdapter2.Dispose();
                }
            }
            else if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("There is No Existing Department Exist to modify");
            }
            else if (string.Compare(textBox1.Text, "") == 0)
            {
                MessageBox.Show("Please Enter New Department Name");
            }

            //Clear TextBox1 
            textBox1.Text = "";

        }
    }
}