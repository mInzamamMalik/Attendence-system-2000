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
    //Form19: Display "Modify Student Name" form
    public partial class Form19 : Form
    {
        OleDbConnection DBCon1;
        bool BDept;     
        
        public Form19()
        {
            InitializeComponent();
            //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");
            //Set Depatment Flag to false
            BDept = false;
            //Open DataBase Connection 1
            DBCon1.Open();
        }

        ~Form19()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This method will load Department and Class List in combobox1 and combobox2 respectively
        private void Form19_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "";
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
            
            //Set Department Flag to true
            BDept = true;
        }

        //This method will load class list in combobox2 if another department is selected
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set Class Flag to false
            maskedTextBox1.Text = "";
        
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

        }

        //This method wil display student name in textbox1 as per student_id in Maskedtextbox1
        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            string SStud_Name="";
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && string.Compare(maskedTextBox1.Text, "") != 0)
            {
                OleDbCommand DBCom1 = new OleDbCommand("select Student_Name from student where student_id="+ maskedTextBox1.Text.ToString() +" and dept_id =" + comboBox1.SelectedValue.ToString() + " and class_id=" + comboBox2.SelectedValue.ToString(), DBCon1);
                
                try
                {
                    SStud_Name = (string)DBCom1.ExecuteScalar();

                }
                catch (System.NullReferenceException)
                {
                    SStud_Name= "";
                }

                DBCom1.Dispose();                
            }

            if (string.Compare(SStud_Name, "") != 0)
            {             
                textBox1.Text = SStud_Name;
            }
            else
            {
                textBox1.Text = "";
            }
        }

        //This method will modify student Name
        private void button1_Click(object sender, EventArgs e)
        {
            int a1 = string.Compare(textBox1.Text.Trim(), "");
            int a2 = string.Compare(textBox2.Text.Trim(), "");
            if (a1 != 0 && a2 != 0)
            {
                OleDbCommand DBCom2 = new OleDbCommand("update student set student_name='" + textBox2.Text.Trim() + "' where student_id=" + maskedTextBox1.Text.Trim() + "and dept_id=" + comboBox1.SelectedValue.ToString() + "and class_id=" + comboBox2.SelectedValue.ToString(), DBCon1);
                DBCom2.ExecuteNonQuery();
                MessageBox.Show("Student Name is Updated");
                maskedTextBox1.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else if (a1 == 0)
            {
                MessageBox.Show("No Student Selected (Invalid Student ID)");
            }
            else if (a2 == 0)
            {
                MessageBox.Show("Please Enter New Student Name");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            maskedTextBox1.Text = "";
        }
    }
}