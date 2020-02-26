using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSystemEntityFramework
{
    // Remember SOLID: Open for extension, but closed for modification

    public static class StudentDB
    {
        /// <summary>
        /// Returns a list of all students,
        /// sorted by StudentID,
        /// in ascending order.
        /// Don't change behavior of methods
        /// </summary>
        /// <returns></returns>
        public static List<Student> GetAllStudents()
        {
            // how to create an instance of a class

            // StudentContext context = new StudentContext();
            var context = new StudentContext(); // same as above, only use var when the type is clearly displayed on the right side of the assignment operator

            // LINQ - Language INtegrated Query
                // 1st Option: LINQ Query Syntax (preferred)
                // Don't use var in this example, type is not clearly displayed right of the assignment operator
            List<Student> students = (from stu in context.Students 
                                      orderby stu.StudentID ascending 
                                      select stu).ToList();

                // 2nd Option: LINQ Method Syntax
            List<Student> students2 = context.Students.OrderBy(stu2 => stu2.StudentID).ToList();

            return students;
        }

        /// <summary>
        /// Add single/individual student to DB
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public static Student Add(Student stu)
        {
            var context = new StudentContext();

            // Preparing insert query
            context.Students.Add(stu);

            // Executing insert query against DB
            context.SaveChanges();
            return stu;
        }
    }
}
