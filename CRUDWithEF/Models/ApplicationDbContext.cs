using Microsoft.EntityFrameworkCore;

namespace CRUDWithEF.Models
{
    public class ApplicationDbContext:DbContext
    {
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //fetch the data from DB and store at application side
        //Dbset will translate LINQ queries in the SQL and
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> students { get; set; }

        public DbSet<Movie> movi { get; set; }

    }



}
