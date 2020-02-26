namespace StudentManagmentSystemEntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    /*  To create StudentContext.cs:
     *  right click project,
     *  add "New Item",
     *  click "Data",
     *  select "ADO.NET Entity Data Model"
     *  select "Empty Code First Model"
     *  
     *  This database context class manages how things are mapped from the application to the database.
    */

    public class StudentContext : DbContext
    {
        // Your context has been configured to use a 'StudentContext' connection string from your application's configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'StudentManagmentSystemEntityFramework.StudentContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StudentContext' connection string in the application configuration file.

        // Constructor, base is similar to Java "super"
        public StudentContext() : base("name=StudentContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model.
        // For more information on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        //
        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Student> Students { get; set; }
    }
}