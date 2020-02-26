using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            using (var context = new StudentContext()) // same as above, only use var when the type is clearly displayed on the right side of the assignment operator
            {
#if DEBUG
                // Log query to output window
                context.Database.Log = Console.WriteLine;
#endif
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
        }

        /// <summary>
        /// Add single/individual student to DB
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public static Student Add(Student stu)
        {
            using (var context = new StudentContext())
            {
#if DEBUG
                // Log query to output window
                context.Database.Log = Console.WriteLine;
#endif
                // Preparing insert query
                context.Students.Add(stu);

                // Executing insert query against DB
                context.SaveChanges();
            }
            return stu;
        }

        /// <summary>
        /// Deletes a student from the DB by their StudentID,
        /// disconnected scenario.
        /// </summary>
        /// <param name="stu"></param>
        public static void Delete(Student stu)
        {
            // This is a using statement, using directives are at the top of the file.
            using (var context = new StudentContext())
            {
#if DEBUG
                // Log query to output window
                context.Database.Log = Console.WriteLine;
#endif
                // Add to context, but confusing because we are deleting stu not adding
                //context.Students.Add(stu); 

                // Attaching stu to context/EF to be deleted.
                context.Students.Attach(stu); 
                context.Entry(stu).State = EntityState.Deleted; // added using directive for "System.Data.Entity." before EntityState
                context.SaveChanges();
            }

            /* 
               
            this is what the using statement above generates, just a manual equivalent
            https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement

            var context2 = new StudentContext();
            try
            {
                // DB Code goes here.
            }
            finally
            {
                context2.Dispose();
            }
            
            */
        }

        /// <summary>
        /// Updates a student from the DB by their StudentID
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public static Student Update(Student stu)
        {
            using (var context = new StudentContext())
            {
#if DEBUG
                context.Database.Log = Console.WriteLine;
#endif
                context.Students.Attach(stu);
                context.Entry(stu).State = EntityState.Modified;
                context.SaveChanges();
            }
            return stu;
        }

        /// <summary>
        /// Add or Update in a single method, using the ternary/conditional operator.
        /// If StudentID = 0, they will be added, otherwise it will be updated by StudentID
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public static Student AddOrUpdate(Student stu)
        {
            using (var context = new StudentContext())
            {
#if DEBUG
                context.Database.Log = Console.WriteLine;
#endif
                context.Entry(stu).State = (stu.StudentID <= 0) ? EntityState.Added : EntityState.Modified;
                context.SaveChanges();
            }
            return stu;
        }
    }
}