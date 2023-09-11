using Microsoft.EntityFrameworkCore.Query;

namespace CRUDWithEF.Models
{
    public class Movie_CRUD
    {

        ApplicationDbContext context;
        private IConfiguration configuration;

        public Movie_CRUD(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Movie_CRUD(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public IEnumerable<Movie> GetMovie()
        {
            return context.movi.Where(x => x.isActive == 1).ToList();
        }


        public Movie GetMovieById(int id)
        {
            var movie = context.movi.Where(x => x.Id == id).FirstOrDefault();
            return movie;
        }


        public int AddMovie(Movie movie)
        {
            movie.isActive = 1;
            int result = 0;
            context.movi.Add(movie); // add new record in to the DbSet
            result = context.SaveChanges(); // update the change from DbSet to DB
            return result;
        }
        public int UpdateMovie(Movie movie)
        {

            int result = 0;
            // search from dbset
            var m = context.movi.Where(x => x.Id == movie.Id).FirstOrDefault();
            if (m != null)
            {
                m.title = movie.title; // b object contains old data book obj contains new data
                m.release_date = movie.release_date;
                m.movie_type = movie.movie_type;
                m.star_name = movie.star_name;
                m.isActive = 1;
                result = context.SaveChanges(); // update the change from DbSet to DB
            }

            return result;
        }
        public int DeleteMovie(int id)
        {
            int result = 0;
            // search from dbset
            var m = context.movi.Where(x => x.Id == id).FirstOrDefault();
            if (m != null)
            {
                m.isActive = 0;
                result = context.SaveChanges(); // update the change from DbSet to DB
            }


            return result;
        }
    }
}
