using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Attendance
{
    // Form1: Display Menustrip (which include Department menu, class menu, Lecturer menu, Subject menu, Student Menu, Registration Menu, attendance Menu and About Menu)

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Department Menu 
        private void newDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display New Department Name form
            Form2 a = new Form2();            
            a.Show();
        }

        private void modifyDepartmentNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display Modify Department Name form
            Form3 a = new Form3();
            a.Show();
        }

        private void deleteDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Delete Department Name form
            Form4 a = new Form4();
            a.Show();
        }

        private void displayDepartmentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display Department Names form
            Form5 a = new Form5();
            a.Show();
        }

        //Class Menu
        private void newClassNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display New Class Name form
            Form6 a = new Form6();
            a.Show();
        }

        private void modifyClassNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display Modify Class Name form
            Form7 a = new Form7();
            a.Show();
        }

        private void deleteClassNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display Delete Class Name form
            Form8 a = new Form8();
            a.Show();
        }

        private void displayClassNameListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display Class Names form
            Form9 a = new Form9();
            a.Show();
        }

        //Lecturer Menu
        private void addNewLecturerInDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display New Lecturer Name form
            Form10 a = new Form10();
            a.Show();
        }

        private void modifyLecturerNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display Modify Lecturer Name form
            Form11 a = new Form11();
            a.Show();
        }

        private void deleteLecturerNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display Delete Lecturer Name form
            Form12 a = new Form12();
            a.Show();
        }

        private void displayListOfLecturerInDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display Lecturer Names form
            Form13 a = new Form13();
            a.Show();
        }

        //Subject Menu
        private void addNewStudentInClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display New Subject Name form
            Form14 a = new Form14();
            a.Show();
        }

        private void modifyStudentNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display Modify Subject Name form
            Form15 a = new Form15();
            a.Show();
        }

        private void deleteStudentNameFromClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display Delete Subject Name form
            Form16 a = new Form16();
            a.Show();
        }

        private void displayLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display "Display Subject Names" form
            Form17 a = new Form17();
            a.Show();
        }

        //Student Menu
        private void addNewStudentInClassToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Display "New Student Name" form
            Form18 a = new Form18();
            a.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display "Modify Student Name" form
            Form19 a = new Form19();
            a.Show();
        }

        private void modifyStudentNameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Display "Delete Student Name" form
            Form20 a = new Form20();
            a.Show();
        }

        private void displayListOfStudentInClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display "Display Student Names" form
            Form21 a = new Form21();
            a.Show();
        }
        //Registration Menu
            //Lecturer Registration Menu
        private void registerLecturerNameForASubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display "Register Lecturer Name for a Subject" form
            Form22 a = new Form22();
            a.Show();
        }

        private void deRegisterLecturerNameForASubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display "DeRegister Lecturer Name for a Subject" form
            Form23 a = new Form23();
            a.Show();
        }

        private void displayListOfRegisteredSubjectInSemesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display "Display List of Registered Subject in Semester" form 
            Form24 a = new Form24();
            a.Show();
        }
            //Studentt Registration Menu
        private void registerStudentsNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display "Register Student Name for a subject" form 
            Form25 a = new Form25();
            a.Show();
        }

        private void deRegisterStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display "DeRegister Student Name for a subject" form
            Form26 a = new Form26();
            a.Show();
        }

        private void displayListOfStudentRegisterForASubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display "Display List of student register for a subject" form
            Form27 a = new Form27();            
            a.Show();
        }

        //Attendance Menu
        private void addAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display "Add Attendance (Subject wise)" form
            Form28 a = new Form28();
            a.Show();
        }

        private void printSavedAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Display "Build Attendnace Document (subject wise)" form
            Form29 a = new Form29();
            a.Show();
        }

        //About Menu
        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Show Message  
            MessageBox.Show("Special Thanks to:\n"+
                            "\nLecturer Anila Nawaz from Federal Urdu University,"+
                            "\nMy Friend Hasan Siddiqui from PAF Kiet"+
                            "\nAnd Google baba :-)"+
                            "\n\nThey All Helped me alot"
                            ," Credits");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                            "My Name is Inzamam Malik"+
                            "\ni'm student of Semister iii Computer Science in Federal Urdu University "+
                            "\ni'm related to open source technolgies like MEAN Stak, firebase, ionic etc. "+
                            "and contributing in open Source from 3 years"+
                            "\nNow a days i develop Hybrid Mobile Application for a local firm named PanaCloud" 
                            , " About Me");
        }

        private void aboutSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                           "\n\nThis software is a Attendence system for university"+
                           " created as assigment of Subject Visual Programming" +
                           " conducted by Respected Lecturer Anila Nawaz"
                           , " About Me");
        }
    }
}