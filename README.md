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
      var movie = await imdb.GetMovie("MOVIE_TITLE");

      Console.WriteLine(movie.Plot);
    }
  }
}
```

### TODO
- Make errors return properly instead of an empty string which makes it crash