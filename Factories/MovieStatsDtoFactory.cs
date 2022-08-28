using MovieApi.Models;
using System.Collections.Generic;
using MovieApi.Dtos;
using System.Linq;

namespace MovieApi.Factories
{
    public static class MovieStatsDtoFactory
    {
        public static MovieStatsDto Create(Metadata movieMetadata, IEnumerable<Stat> movieStats)
        {
            int totalWatches = movieStats.Count();

            double averageWatchtimeMs = movieStats.Average(x => x.watchDurationMs);

            MovieStatsDto newStatDto = new MovieStatsDto()
            {
                MovieId = movieMetadata.MovieId,
                Title = movieMetadata.Title,
                AverageWatchDurationS = (int)(averageWatchtimeMs / 1000),
                Watches = totalWatches,
                ReleaseYear = movieMetadata.ReleaseYear
            };
            
            return newStatDto;
        }
    }
}