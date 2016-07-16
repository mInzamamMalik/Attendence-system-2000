namespace Attendance
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.departmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDepartmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyDepartmentNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDepartmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayDepartmentListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newClassNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyClassNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteClassNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayClassNameListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lecturerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewLecturerInDepartmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyLecturerNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLecturerNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayListOfLecturerInDepartmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewStudentInClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyStudentNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteStudentNameFromClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewStudentInClassToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyStudentNameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.displayListOfStudentInClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lecturerRegistratToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerLecturerNameForASubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deRegisterLecturerNameForASubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayListOfRegisteredSubjectInSemesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsRegistrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerStudentsNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deRegisterStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayListOfStudentRegisterForASubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAttendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printSavedAttendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.departmentToolStripMenuItem,
            this.classToolStripMenuItem,
            this.lecturerToolStripMenuItem,
            this.studentToolStripMenuItem,
            this.studentToolStripMenuItem1,
            this.registrationToolStripMenuItem,
            this.attendanceToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(727, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // departmentToolStripMenuItem
            // 
            this.departmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDepartmentToolStripMenuItem,
            this.modifyDepartmentNameToolStripMenuItem,
            this.deleteDepartmentToolStripMenuItem,
            this.displayDepartmentListToolStripMenuItem});
            this.departmentToolStripMenuItem.Name = "departmentToolStripMenuItem";
            this.departmentToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.departmentToolStripMenuItem.Text = "Department";
            // 
            // newDepartmentToolStripMenuItem
            // 
            this.newDepartmentToolStripMenuItem.Name = "newDepartmentToolStripMenuItem";
            this.newDepartmentToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.newDepartmentToolStripMenuItem.Text = "New Department Name";
            this.newDepartmentToolStripMenuItem.Click += new System.EventHandler(this.newDepartmentToolStripMenuItem_Click);
            // 
            // modifyDepartmentNameToolStripMenuItem
            // 
            this.modifyDepartmentNameToolStripMenuItem.Name = "modifyDepartmentNameToolStripMenuItem";
            this.modifyDepartmentNameToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.modifyDepartmentNameToolStripMenuItem.Text = "Modify Department Name";
            this.modifyDepartmentNameToolStripMenuItem.Click += new System.EventHandler(this.modifyDepartmentNameToolStripMenuItem_Click);
            // 
            // deleteDepartmentToolStripMenuItem
            // 
            this.deleteDepartmentToolStripMenuItem.Name = "deleteDepartmentToolStripMenuItem";
            this.deleteDepartmentToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.deleteDepartmentToolStripMenuItem.Text = "Delete Department Name";
            this.deleteDepartmentToolStripMenuItem.Click += new System.EventHandler(this.deleteDepartmentToolStripMenuItem_Click);
            // 
            // displayDepartmentListToolStripMenuItem
            // 
            this.displayDepartmentListToolStripMenuItem.Name = "displayDepartmentListToolStripMenuItem";
            this.displayDepartmentListToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.displayDepartmentListToolStripMenuItem.Text = "Display Department Names";
            this.displayDepartmentListToolStripMenuItem.Click += new System.EventHandler(this.displayDepartmentListToolStripMenuItem_Click);
            // 
            // classToolStripMenuItem
            // 
            this.classToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newClassNameToolStripMenuItem,
            this.modifyClassNameToolStripMenuItem,
            this.deleteClassNameToolStripMenuItem,
            this.displayClassNameListToolStripMenuItem});
            this.classToolStripMenuItem.Name = "classToolStripMenuItem";
            this.classToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.classToolStripMenuItem.Text = "Class";
            // 
            // newClassNameToolStripMenuItem
            // 
            this.newClassNameToolStripMenuItem.Name = "newClassNameToolStripMenuItem";
            this.newClassNameToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.newClassNameToolStripMenuItem.Text = "New Class Name";
            this.newClassNameToolStripMenuItem.Click += new System.EventHandler(this.newClassNameToolStripMenuItem_Click);
            // 
            // modifyClassNameToolStripMenuItem
            // 
            this.modifyClassNameToolStripMenuItem.Name = "modifyClassNameToolStripMenuItem";
            this.modifyClassNameToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.modifyClassNameToolStripMenuItem.Text = "Modify Class Name";
            this.modifyClassNameToolStripMenuItem.Click += new System.EventHandler(this.modifyClassNameToolStripMenuItem_Click);
            // 
            // deleteClassNameToolStripMenuItem
            // 
            this.deleteClassNameToolStripMenuItem.Name = "deleteClassNameToolStripMenuItem";
            this.deleteClassNameToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.deleteClassNameToolStripMenuItem.Text = "Delete Class Name";
            this.deleteClassNameToolStripMenuItem.Click += new System.EventHandler(this.deleteClassNameToolStripMenuItem_Click);
            // 
            // displayClassNameListToolStripMenuItem
            // 
            this.displayClassNameListToolStripMenuItem.Name = "displayClassNameListToolStripMenuItem";
            this.displayClassNameListToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.displayClassNameListToolStripMenuItem.Text = "Display Class Names";
            this.displayClassNameListToolStripMenuItem.Click += new System.EventHandler(this.displayClassNameListToolStripMenuItem_Click);
            // 
            // lecturerToolStripMenuItem
            // 
            this.lecturerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewLecturerInDepartmentToolStripMenuItem,
            this.modifyLecturerNameToolStripMenuItem,
            this.deleteLecturerNameToolStripMenuItem,
            this.displayListOfLecturerInDepartmentToolStripMenuItem});
            this.lecturerToolStripMenuItem.Name = "lecturerToolStripMenuItem";
            this.lecturerToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.lecturerToolStripMenuItem.Text = "Lecturer";
            // 
            // addNewLecturerInDepartmentToolStripMenuItem
            // 
            this.addNewLecturerInDepartmentToolStripMenuItem.Name = "addNewLecturerInDepartmentToolStripMenuItem";
            this.addNewLecturerInDepartmentToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addNewLecturerInDepartmentToolStripMenuItem.Text = "New Lecturer Name";
            this.addNewLecturerInDepartmentToolStripMenuItem.Click += new System.EventHandler(this.addNewLecturerInDepartmentToolStripMenuItem_Click);
            // 
            // modifyLecturerNameToolStripMenuItem
            // 
            this.modifyLecturerNameToolStripMenuItem.Name = "modifyLecturerNameToolStripMenuItem";
            this.modifyLecturerNameToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.modifyLecturerNameToolStripMenuItem.Text = "Modify Lecturer Name";
            this.modifyLecturerNameToolStripMenuItem.Click += new System.EventHandler(this.modifyLecturerNameToolStripMenuItem_Click);
            // 
            // deleteLecturerNameToolStripMenuItem
            // 
            this.deleteLecturerNameToolStripMenuItem.Name = "deleteLecturerNameToolStripMenuItem";
            this.deleteLecturerNameToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.deleteLecturerNameToolStripMenuItem.Text = "Delete Lecturer Name";
            this.deleteLecturerNameToolStripMenuItem.Click += new System.EventHandler(this.deleteLecturerNameToolStripMenuItem_Click);
            // 
            // displayListOfLecturerInDepartmentToolStripMenuItem
            // 
            this.displayListOfLecturerInDepartmentToolStripMenuItem.Name = "displayListOfLecturerInDepartmentToolStripMenuItem";
            this.displayListOfLecturerInDepartmentToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.displayListOfLecturerInDepartmentToolStripMenuItem.Text = "Display Lecturers Names";
            this.displayListOfLecturerInDepartmentToolStripMenuItem.Click += new System.EventHandler(this.displayListOfLecturerInDepartmentToolStripMenuItem_Click);
            // 
            // studentToolStripMenuItem
            // 
            this.studentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewStudentInClassToolStripMenuItem,
            this.modifyStudentNameToolStripMenuItem,
            this.deleteStudentNameFromClassToolStripMenuItem,
            this.displayLToolStripMenuItem});
            this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            this.studentToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.studentToolStripMenuItem.Text = "Subject";
            // 
            // addNewStudentInClassToolStripMenuItem
            // 
            this.addNewStudentInClassToolStripMenuItem.Name = "addNewStudentInClassToolStripMenuItem";
            this.addNewStudentInClassToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.addNewStudentInClassToolStripMenuItem.Text = "New Subject Name";
            this.addNewStudentInClassToolStripMenuItem.Click += new System.EventHandler(this.addNewStudentInClassToolStripMenuItem_Click);
            // 
            // modifyStudentNameToolStripMenuItem
            // 
            this.modifyStudentNameToolStripMenuItem.Name = "modifyStudentNameToolStripMenuItem";
            this.modifyStudentNameToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.modifyStudentNameToolStripMenuItem.Text = "Modify Subject Name ";
            this.modifyStudentNameToolStripMenuItem.Click += new System.EventHandler(this.modifyStudentNameToolStripMenuItem_Click);
            // 
            // deleteStudentNameFromClassToolStripMenuItem
            // 
            this.deleteStudentNameFromClassToolStripMenuItem.Name = "deleteStudentNameFromClassToolStripMenuItem";
            this.deleteStudentNameFromClassToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.deleteStudentNameFromClassToolStripMenuItem.Text = "Delete Subject Name";
            this.deleteStudentNameFromClassToolStripMenuItem.Click += new System.EventHandler(this.deleteStudentNameFromClassToolStripMenuItem_Click);
            // 
            // displayLToolStripMenuItem
            // 
            this.displayLToolStripMenuItem.Name = "displayLToolStripMenuItem";
            this.displayLToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.displayLToolStripMenuItem.Text = "Display Subject Names";
            this.displayLToolStripMenuItem.Click += new System.EventHandler(this.displayLToolStripMenuItem_Click);
            // 
            // studentToolStripMenuItem1
            // 
            this.studentToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewStudentInClassToolStripMenuItem1,
            this.deleteToolStripMenuItem,
            this.modifyStudentNameToolStripMenuItem1,
            this.displayListOfStudentInClassToolStripMenuItem});
            this.studentToolStripMenuItem1.Name = "studentToolStripMenuItem1";
            this.studentToolStripMenuItem1.Size = new System.Drawing.Size(57, 20);
            this.studentToolStripMenuItem1.Text = "Student";
            // 
            // addNewStudentInClassToolStripMenuItem1
            // 
            this.addNewStudentInClassToolStripMenuItem1.Name = "addNewStudentInClassToolStripMenuItem1";
            this.addNewStudentInClassToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.addNewStudentInClassToolStripMenuItem1.Text = "New Student Name";
            this.addNewStudentInClassToolStripMenuItem1.Click += new System.EventHandler(this.addNewStudentInClassToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.deleteToolStripMenuItem.Text = "Modify Student Name";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // modifyStudentNameToolStripMenuItem1
            // 
            this.modifyStudentNameToolStripMenuItem1.Name = "modifyStudentNameToolStripMenuItem1";
            this.modifyStudentNameToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.modifyStudentNameToolStripMenuItem1.Text = "Delete Student Name";
            this.modifyStudentNameToolStripMenuItem1.Click += new System.EventHandler(this.modifyStudentNameToolStripMenuItem1_Click);
            // 
            // displayListOfStudentInClassToolStripMenuItem
            // 
            this.displayListOfStudentInClassToolStripMenuItem.Name = "displayListOfStudentInClassToolStripMenuItem";
            this.displayListOfStudentInClassToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.displayListOfStudentInClassToolStripMenuItem.Text = "Display Student Names";
            this.displayListOfStudentInClassToolStripMenuItem.Click += new System.EventHandler(this.displayListOfStudentInClassToolStripMenuItem_Click);
            // 
            // registrationToolStripMenuItem
            // 
            this.registrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lecturerRegistratToolStripMenuItem,
            this.studentsRegistrationToolStripMenuItem});
            this.registrationToolStripMenuItem.Name = "registrationToolStripMenuItem";
            this.registrationToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.registrationToolStripMenuItem.Text = "Registration";
            // 
            // lecturerRegistratToolStripMenuItem
            // 
            this.lecturerRegistratToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerLecturerNameForASubjectToolStripMenuItem,
            this.deRegisterLecturerNameForASubjectToolStripMenuItem,
            this.displayListOfRegisteredSubjectInSemesterToolStripMenuItem});
            this.lecturerRegistratToolStripMenuItem.Name = "lecturerRegistratToolStripMenuItem";
            this.lecturerRegistratToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.lecturerRegistratToolStripMenuItem.Text = "Lecturer Registration";
            // 
            // registerLecturerNameForASubjectToolStripMenuItem
            // 
            this.registerLecturerNameForASubjectToolStripMenuItem.Name = "registerLecturerNameForASubjectToolStripMenuItem";
            this.registerLecturerNameForASubjectToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.registerLecturerNameForASubjectToolStripMenuItem.Text = "Register Lecturer Name for a Subject ";
            this.registerLecturerNameForASubjectToolStripMenuItem.Click += new System.EventHandler(this.registerLecturerNameForASubjectToolStripMenuItem_Click);
            // 
            // deRegisterLecturerNameForASubjectToolStripMenuItem
            // 
            this.deRegisterLecturerNameForASubjectToolStripMenuItem.Name = "deRegisterLecturerNameForASubjectToolStripMenuItem";
            this.deRegisterLecturerNameForASubjectToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.deRegisterLecturerNameForASubjectToolStripMenuItem.Text = "Unregister Lecturer Name for a Subject ";
            this.deRegisterLecturerNameForASubjectToolStripMenuItem.Click += new System.EventHandler(this.deRegisterLecturerNameForASubjectToolStripMenuItem_Click);
            // 
            // displayListOfRegisteredSubjectInSemesterToolStripMenuItem
            // 
            this.displayListOfRegisteredSubjectInSemesterToolStripMenuItem.Name = "displayListOfRegisteredSubjectInSemesterToolStripMenuItem";
            this.displayListOfRegisteredSubjectInSemesterToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.displayListOfRegisteredSubjectInSemesterToolStripMenuItem.Text = "Display List of registered Subject in Semester";
            this.displayListOfRegisteredSubjectInSemesterToolStripMenuItem.Click += new System.EventHandler(this.displayListOfRegisteredSubjectInSemesterToolStripMenuItem_Click);
            // 
            // studentsRegistrationToolStripMenuItem
            // 
            this.studentsRegistrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerStudentsNameToolStripMenuItem,
            this.deRegisterStudentToolStripMenuItem,
            this.displayListOfStudentRegisterForASubjectToolStripMenuItem});
            this.studentsRegistrationToolStripMenuItem.Name = "studentsRegistrationToolStripMenuItem";
            this.studentsRegistrationToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.studentsRegistrationToolStripMenuItem.Text = "Student Registration";
            // 
            // registerStudentsNameToolStripMenuItem
            // 
            this.registerStudentsNameToolStripMenuItem.Name = "registerStudentsNameToolStripMenuItem";
            this.registerStudentsNameToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.registerStudentsNameToolStripMenuItem.Text = "Register Student Name for a subject";
            this.registerStudentsNameToolStripMenuItem.Click += new System.EventHandler(this.registerStudentsNameToolStripMenuItem_Click);
            // 
            // deRegisterStudentToolStripMenuItem
            // 
            this.deRegisterStudentToolStripMenuItem.Name = "deRegisterStudentToolStripMenuItem";
            this.deRegisterStudentToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.deRegisterStudentToolStripMenuItem.Text = "Unregister Student  Name for a subject";
            this.deRegisterStudentToolStripMenuItem.Click += new System.EventHandler(this.deRegisterStudentToolStripMenuItem_Click);
            // 
            // displayListOfStudentRegisterForASubjectToolStripMenuItem
            // 
            this.displayListOfStudentRegisterForASubjectToolStripMenuItem.Name = "displayListOfStudentRegisterForASubjectToolStripMenuItem";
            this.displayListOfStudentRegisterForASubjectToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
            this.displayListOfStudentRegisterForASubjectToolStripMenuItem.Text = "Display List of Student Register for a Subject";
            this.displayListOfStudentRegisterForASubjectToolStripMenuItem.Click += new System.EventHandler(this.displayListOfStudentRegisterForASubjectToolStripMenuItem_Click);
            // 
            // attendanceToolStripMenuItem
            // 
            this.attendanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAttendanceToolStripMenuItem,
            this.printSavedAttendanceToolStripMenuItem});
            this.attendanceToolStripMenuItem.Name = "attendanceToolStripMenuItem";
            this.attendanceToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.attendanceToolStripMenuItem.Text = "Attendance";
            // 
            // addAttendanceToolStripMenuItem
            // 
            this.addAttendanceToolStripMenuItem.Name = "addAttendanceToolStripMenuItem";
            this.addAttendanceToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.addAttendanceToolStripMenuItem.Text = "Add Attendance (subject wise)";
            this.addAttendanceToolStripMenuItem.Click += new System.EventHandler(this.addAttendanceToolStripMenuItem_Click);
            // 
            // printSavedAttendanceToolStripMenuItem
            // 
            this.printSavedAttendanceToolStripMenuItem.Name = "printSavedAttendanceToolStripMenuItem";
            this.printSavedAttendanceToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.printSavedAttendanceToolStripMenuItem.Text = "Build Attendance Document (Subject Wise)";
            this.printSavedAttendanceToolStripMenuItem.Click += new System.EventHandler(this.printSavedAttendanceToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creditsToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 428);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Attendance Analysis System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem departmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDepartmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyDepartmentNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDepartmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayDepartmentListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newClassNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyClassNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteClassNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayClassNameListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lecturerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewLecturerInDepartmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyLecturerNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLecturerNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayListOfLecturerInDepartmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewStudentInClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyStudentNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteStudentNameFromClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addNewStudentInClassToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyStudentNameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem displayListOfStudentInClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lecturerRegistratToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerLecturerNameForASubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deRegisterLecturerNameForASubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayListOfRegisteredSubjectInSemesterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsRegistrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerStudentsNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deRegisterStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayListOfStudentRegisterForASubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attendanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAttendanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printSavedAttendanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
    }
}

