using System.Collections.Generic;
using MovieApi.Models;
using MovieApi.Repositories;

namespace MovieApi.Services
{
    public interface IMetadataService
    {
         IEnumerable<Metadata> GetMetadatas(int movieId);
    }
}