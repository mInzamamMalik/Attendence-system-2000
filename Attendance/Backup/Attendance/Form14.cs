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
    //Form14: Display " New Subject Name" form.
    public partial class Form14 : Form
    {
        OleDbConnection DBCon1;
        bool BDept;
        int ISub_Ind;

        public Form14()
        {
            InitializeComponent();

            //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");
            //Open DataBase Connection 1
            DBCon1.Open();
            //Set Department Flag to false
            BDept = false;
            //Initialise ISub_Ind Counter
            ISub_Ind = 0;

        }

         ~Form14()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This method will load Department, Class and Semester List in combobox1, combobox2 & combobox3 respectively and
        // retrive maximum subject id from database
        private void Form14_Load(object sender, EventArgs e)
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

            //Set Department Flag to true
            BDept = true;

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

            //Load Semester List in Combobox3
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

            //Generate next Subject Inedex
         
            OleDbCommand DBCom1 = new OleDbCommand("SELECT MAX(SUB_IND) AS Expr1 FROM SUBJECT", DBCon1);
            try
            {
                ISub_Ind = (int)DBCom1.ExecuteScalar();
            }
            catch (System.NullReferenceException)
            {
                ISub_Ind = 0;
            }
            catch (System.InvalidCastException)
            {
                ISub_Ind = 0;
            }
            ISub_Ind++;
            DBCom1.Dispose();
            
        }

        //This method will load class list in combobox2 if dapartment name is changed
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        //This method will add new subject name
        private void button1_Click(object sender, EventArgs e)
        {
            int IRTB_Linec = 0;
            string SSub_name;
            for (IRTB_Linec = 0; IRTB_Linec < richTextBox1.Lines.Length; IRTB_Linec++)
            {
                if (string.Compare(richTextBox1.Lines[IRTB_Linec], "") != 0)
                {
                    OleDbCommand DBCom2 = new OleDbCommand("select sub_name from subject where sub_name='" + richTextBox1.Lines[IRTB_Linec] + "' and dept_id =" + comboBox1.SelectedValue.ToString() + " and class_id =" + comboBox2.SelectedValue.ToString() + " and sem_id =" + comboBox3.SelectedValue.ToString(), DBCon1);
                    SSub_name = (string)DBCom2.ExecuteScalar();
                    DBCom2.Dispose();
                    if (string.Compare(richTextBox1.Lines[IRTB_Linec], SSub_name) != 0)
                    {
                        OleDbCommand DBCom3 = new OleDbCommand("insert into subject values(" + comboBox1.SelectedValue.ToString() + "," + comboBox2.SelectedValue.ToString() + "," + comboBox3.SelectedValue.ToString() + "," + ISub_Ind + ",'" + richTextBox1.Lines[IRTB_Linec].ToString() + "')", DBCon1);
                        DBCom3.ExecuteNonQuery();
                        ISub_Ind++;
                        DBCom3.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Subject Already exist");
                    }
                }
            }

            //Clear Rich Text Box
            richTextBox1.ResetText();
        }
    }
}