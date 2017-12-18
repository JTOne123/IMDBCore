using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace IMDBCore
{
    public class Imdb
    {
        private static void Main() {}
        
        private readonly string _apiKey;
        public Imdb(string apiKey)
        {
            _apiKey = apiKey;
        }
        
        public enum ImdbType { Error, Movie, Series, Episode};

        public async Task<ImdbMovie> GetMovie(string title)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "t=" + title }));
            return movie;
        }
        
        public async Task<ImdbMovie> GetMovie(string title, int year)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "t=" + title, "y=" + year }));
            return movie;
        }
        
        public async Task<ImdbMovie> GetMovie(string title, ImdbType type)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "t=" + title, "type=" + type }));
            return movie;
        }
        
        public async Task<ImdbMovie> GetMovie(string title, bool tomatoes)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "t=" + title, "tomatoes=" + tomatoes }));
            return movie;
        }
        
        public async Task<ImdbMovie> GetMovie(string title, int year, bool tomatoes)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "t=" + title, "y=" + year, "tomatoes=" + tomatoes }));
            return movie;
        }
        
        public async Task<ImdbMovie> GetMovie(string title, ImdbType type, bool tomatoes)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "t=" + title, "type=" + type, "tomatoes=" + tomatoes }));
            return movie;
        }
        
        public async Task<ImdbMovie> GetMovie(string title, bool fullPlot, bool tomatoes)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "t=" + title, "plot=" + fullPlot, "tomatoes=" + tomatoes }));
            return movie;
        }
        
        public async Task<ImdbMovie> GetMovie(string title, bool fullPlot, ImdbType type, bool tomatoes)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "t=" + title, "plot=" + fullPlot, "type=" + type, "tomatoes=" + tomatoes }));
            return movie;
        }

        public async Task<ImdbMovie> GetMovieFromId(string id)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "t=" + id }));
            return movie;
        }
        
        public async Task<ImdbMovie> GetMovieFromId(string id, int year)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "i=" + id, "y=" + year }));
            return movie;
        }
        
        public async Task<ImdbMovie> GetMovieFromId(string id, bool tomatoes)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "t=" + id, "tomatoes=" + tomatoes }));
            return movie;
        }
        
        public async Task<ImdbMovie> GetMovieFromId(string id, ImdbType type)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "t=" + id, "type=" + type }));
            return movie;
        }
        
        public async Task<ImdbMovie> GetMovieFromId(string id, int year, bool tomatoes)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "i=" + id, "y=" + year, "tomatoes=" + tomatoes }));
            return movie;
        }
        
        public async Task<ImdbMovie> GetMovieFromId(string id, ImdbType type, bool tomatoes)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "t=" + id, "type=" + type, "tomatoes=" + tomatoes }));
            return movie;
        }
        
        public async Task<ImdbMovie> GetMovieFromId(string id, bool fullPlot, bool tomatoes)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "i=" + id, "plot=" + fullPlot, "tomatoes=" + tomatoes }));
            return movie;
        }
        
        public async Task<ImdbMovie> GetMovieFromId(string id, bool fullPlot, ImdbType type, bool tomatoes)
        {
            var movie = DeserializeImdbMovie(await GetDataFromOmdb(new[] { "i=" + id, "plot=" + fullPlot, "type=" + type, "tomatoes=" + tomatoes }));
            return movie;
        }

        public async Task<ImdbMovieSearchResult> SearchMovie(string title)
        {
            var movie = DeserializeImdbMovieSearchResult(await GetDataFromOmdb(new[] { "s=" + title }));
            return movie;
        }
        public async Task<ImdbMovieSearchResult> SearchMovie(string title, int page)
        {
            var movie = DeserializeImdbMovieSearchResult(await GetDataFromOmdb(new[] { "s=" + title, "page=" + page }));
            return movie;
        }

        private static ImdbMovie DeserializeImdbMovie(string json)
        {
            var deserializedProduct = JsonConvert.DeserializeObject<ImdbMovie>(json);
            return deserializedProduct;
        }

        private static ImdbMovieSearchResult DeserializeImdbMovieSearchResult(string json)
        {
            var deserializedProduct = JsonConvert.DeserializeObject<ImdbMovieSearchResult>(json);
            return deserializedProduct;
        }

        private async Task<string> GetDataFromOmdb(IEnumerable<string> args)
        {
            var input = args.Aggregate("", (current, t) => current + ("&" + t));

            var client = new HttpClient();
            
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync($"http://www.omdbapi.com/?{input}&apikey={_apiKey}");
            if (!response.IsSuccessStatusCode) return "";
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }
    }
}
