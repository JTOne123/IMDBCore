// ReSharper disable UnusedMember.Global
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnassignedField.Global
// ReSharper disable SwitchStatementMissingSomeCases

namespace IMDBCore
{
    public class ImdbMovie
    {
        public string Title;
        public string Year;
        public string Rated;
        public string Released;
        public string RunTime;
        public string Genre;
        public string Director;
        public string Writer;
        public string Actors;
        public string Plot;
        public string Language;
        public string Country;
        public string Awards;
        public string Poster;
        public string MetaScore;

        public string ImdbRating;
        public string ImdbVotes;
        public string ImdbId;
        public string Type;
        public string TomatoMeter;
        public string TomatoImage;
        public string TomatoRating;
        public string TomatoReviews;
        public string TomatoFresh;
        public string TomatoRotten;
        public string TomatoConsensus;
        public string TomatoUserMeter;
        public string TomatoUserRating;
        public string TomatoUserReviews;
        public string TomatoUrl;
        public string Dvd;
        public string BoxOffice;
        public string Production;
        public string Website;

        public string Response;
        public string Error;
        
        public new Imdb.ImdbType GetType()
        {
            switch (Type)
            {
                case "Episode": return Imdb.ImdbType.Episode;
                case "Movie": return Imdb.ImdbType.Movie;
                case "Series": return Imdb.ImdbType.Series;
            }
            return Imdb.ImdbType.Error;
        }

        public bool ApiCallSucceeded()
        {
            return bool.Parse(Response);
        }
    }
}
