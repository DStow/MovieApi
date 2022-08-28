using System.Collections.Generic;
using MovieApi.Models;
using System.Linq;

namespace MovieApi.Repositories
{
    public class StatRepository : IStatRepository
    {
        private List<Stat> _stats;

        public StatRepository(Data.IStatReader statReader)
        {
            _stats = statReader.Read().ToList();
        }

        public IEnumerable<Stat> GetStatsByMovieId(int movieId)
        {
            return _stats.Where(x => x.MovieId == movieId);
        }
    }
}