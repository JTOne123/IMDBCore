// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global

using System.Collections.Generic;

namespace IMDBCore
{
    public class ImdbMovieSearchResult
    {
        public List<ImdbMovieSearchResultItem> Search = new List<ImdbMovieSearchResultItem>();
        public int TotalResults;

        public bool Response;
        public string Error;
    }
}
