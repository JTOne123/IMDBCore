[![NuGet](https://img.shields.io/nuget/v/IMDBCore.svg?style=flat-square)](https://www.nuget.org/packages/IMDBCore/)

# IMDBCore
Wrapper for omdbapi in C# .NETCore

### Example
```cs
using System;
using System.Threading.Tasks;
using IMDBCore;

namespace example
{
  public class Program
  {
    public static void Main() => new Program().Execute().GetAwaiter().GetResult();

    private async Task Execute()
    {
      var imdb = new Imdb("API_KEY");
      var movie = await imdb.GetMovieAsync("MOVIE_TITLE");

      // Log title unless there is an error
      var title = movie.Error ?? movie.Title;
      Console.WriteLine(title);
    }
  }
}
```
