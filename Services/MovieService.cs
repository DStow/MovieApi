using System.Collections.Generic;
using MovieApi.Dtos;
using MovieApi.Models;
using System.Linq;

namespace MovieApi.Services
{
    public class MovieService : IMovieService
    {
        private Repositories.IStatRepository _statRepository;
        private Repositories.IMetadataRepository _metadataRepository;
        public MovieService(Repositories.IStatRepository statRepository, Repositories.IMetadataRepository metaDataRepository)
        {
            _statRepository = statRepository;
            _metadataRepository = metaDataRepository;
        }

        public IEnumerable<MovieStatsDto> GetMovieStats()
        {
            IEnumerable<Metadata> movies = _metadataRepository.GetMetadatas();

            int[] distinctMovieIds = movies.Select(x => x.MovieId).Distinct().ToArray();

            List<MovieStatsDto> results = new List<MovieStatsDto>();

            foreach (int movieId in distinctMovieIds)
            {
                Metadata movieMetadata = movies.FirstOrDefault(x => x.MovieId == movieId);
                IEnumerable<Stat> movieStats = _statRepository.GetStatsByMovieId(movieId);

                MovieStatsDto statDto = Factories.MovieStatsDtoFactory.Create(movieMetadata, movieStats);
                results.Add(statDto);
            }

            return results;
        }
    }
}