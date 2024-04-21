using static System.Net.WebRequestMethods;

namespace InprocessWebSite.Data
{
    public interface IMovieService
    {
        public Task<Movie[]> GetMoviesAsync();
        public Task<Movie?> GetMovieByIdAsync(int id);
        public Task<Movie?> AddMovieAsync(Movie movie);
        public Task<Movie?> UpdateMovieAsync(Movie movie);
        public Task DeleteMovieAsync(int id);
    }
}
