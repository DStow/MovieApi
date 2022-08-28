using System.Collections.Generic;
using MovieApi.Models;

namespace MovieApi.Repositories
{
    public interface IMetadataRepository
    {
        IEnumerable<Metadata> GetMetadatas();
        IEnumerable<Metadata> GetMetadatas(int movieId);
        void Insert(Metadata metadata);
    }
}