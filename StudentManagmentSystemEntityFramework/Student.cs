using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagmentSystemEntityFramework
{
    // Code first DB implementation 

    // Added public access modifier to avoid potential issues with Entity Framework
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        public string FullName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
