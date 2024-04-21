using System.Net;
using System.Text.Json;

using static System.Net.WebRequestMethods;

namespace InprocessWebSite.Data
{
    public class MovieService : IMovieService
    {
        HttpClient _httpClient;

        public MovieService(HttpClient httpClient) {
            _httpClient = httpClient;
        }

        public async Task<Movie?> AddMovieAsync(Movie movie)
        {
            var response = await _httpClient.PostAsJsonAsync("", movie);
            var movieInserted = await response.Content.ReadFromJsonAsync<Movie>();
            return movieInserted;

        }

        public async Task DeleteMovieAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(id.ToString());   
        }

        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            Movie? movie = await _httpClient.GetFromJsonAsync<Movie>("" + id);
            return movie;
        }

        public async Task<Movie[]> GetMoviesAsync()
        {
            return await _httpClient.GetFromJsonAsync<Movie[]>("") ?? [];
        }

        public async Task<Movie?> UpdateMovieAsync(Movie movie)
        {
            var response = await _httpClient.PutAsJsonAsync("", movie);
            //var movieUpdated = await response.Content.ReadFromJsonAsync<Movie>();
            return new Movie();
        }
    }
}
