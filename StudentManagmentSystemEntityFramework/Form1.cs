using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagmentSystemEntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Student stu = new Student()
            {
                FullName = "Jonathan Smith III",
                DateOfBirth = DateTime.Today.AddYears(-45)
            };

            StudentDB.Add(stu);
            MessageBox.Show($"Student {stu.FullName}, SID: 00{stu.StudentID} Added");

            List<Student> allStu = StudentDB.GetAllStudents();
            MessageBox.Show("Total Students" + allStu.Count);

            StudentDB.Delete(stu);

            List<Student> allStu2 = StudentDB.GetAllStudents();
            MessageBox.Show("Total Students" + allStu2.Count);
        }
    }
}