using MovieApi.Dtos;
using System.Collections.Generic;

namespace MovieApi.Services
{
    public interface IMovieService
    {
         IEnumerable<MovieStatsDto> GetMovieStats();
    }
}