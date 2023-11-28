using MoviesAPI.Data;
using MoviesAPI.ViewModels;

namespace MoviesAPI.Services
{
    public class MoviesService
    {
        private readonly AppDbContext _dbContext;

        public MoviesService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Movie> GetAllMovies()
        {
            return _dbContext.Movies.ToList();
        }

        public Movie? GetMovieById(int id)
        {
            return _dbContext.Movies.FirstOrDefault(x => x.Id == id);
        }

        public Movie? UpdateMovie(int id, MovieVM movieVM) 
        {
            Movie? movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);

            if (movie is not null)
            {
                movie.Name = movieVM.Name;
                movie.Year = movieVM.Year;
                movie.Genre = movieVM.Genre;

                _dbContext.Movies.Update(movie);
                _dbContext.SaveChanges();
            }

            return movie;
        }

        public void DeleteMovie(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(x => x.Id == id);

            if (movie is null) 
                return;

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }

        public void AddMovie(MovieVM movieVM)
        {
            var newMovie = new Movie()
            {
                Name = movieVM.Name,
                Year = movieVM.Year,
                Genre = movieVM.Genre
            };

            _dbContext.Movies.Add(newMovie);
            _dbContext.SaveChanges();
        }
    }
}
