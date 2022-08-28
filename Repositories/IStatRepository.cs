using MovieApi.Models;
using System.Collections.Generic;
namespace MovieApi.Repositories
{
    public interface IStatRepository
    {
         IEnumerable<Stat> GetStatsByMovieId(int movieId);
    }
}