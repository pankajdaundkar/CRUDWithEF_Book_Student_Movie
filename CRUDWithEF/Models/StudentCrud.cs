namespace CRUDWithEF.Models
{
    public class StudentCrud
    {
        ApplicationDbContext context;
        private IConfiguration configuration;

        public StudentCrud(ApplicationDbContext context)
        {
            this.context = context;
        }
        public StudentCrud(IConfiguration configuration)
        {
            this.configuration = configuration;     
        }

        public IEnumerable<Student> GetStudents()
        {
            return context.students.Where(x => x.isActive == 1).ToList();
        }


        public Student GetStudentById(int id)
        {
            var student = context.students.Where(x => x.Id == id).FirstOrDefault();
            return student;
        }


        public int AddStudent(Student student)
        {
            student.isActive = 1;
            int result = 0;
            context.students.Add(student); // add new record in to the DbSet
            result = context.SaveChanges(); // update the change from DbSet to DB
            return result;
        }
        public int UpdateStudent(Student student)
        {

            int result = 0;
            // search from dbset
            var s = context.students.Where(x => x.Id == student.Id).FirstOrDefault();
            if (s != null)
            {
                s.Name = student.Name; // b object contains old data book obj contains new data
                s.DOB = student.DOB;
                s.Percentage = student.Percentage;
                s.isActive = 1;
                result = context.SaveChanges(); // update the change from DbSet to DB
            }

            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            // search from dbset
            var s = context.students.Where(x => x.Id == id).FirstOrDefault();
            if (s != null)
            {
                s.isActive = 0;
                result = context.SaveChanges(); // update the change from DbSet to DB
            }


            return result;
        }

    }
}
