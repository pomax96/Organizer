using System.Data.Entity;

namespace BinaryStudio_Server
{
    class OrganaizerContext : DbContext
    {
        public OrganaizerContext()
            : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=BSOrganizerDataBase;Integrated Security=true;")
        {
           
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Subtask> Subtasks { get; set; }
    }
}
