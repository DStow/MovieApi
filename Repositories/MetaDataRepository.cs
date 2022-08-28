using MovieApi.Repositories;
using MovieApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieApi.Repositories
{
    public class MetaDataRepository : IMetadataRepository
    {
        private Data.IMetadataReader _metadataReader;
        private List<Models.Metadata> _insertedMetadatas = new List<Metadata>();

        public MetaDataRepository(Data.IMetadataReader metadataReader)
        {
            _metadataReader = metadataReader;
        }

        public IEnumerable<Metadata> GetMetadatas()
        {
            return _metadataReader.Read();
        }

        public IEnumerable<Metadata> GetMetadatas(int movieId)
        {
            return _metadataReader.Read().Where(x => x.MovieId == movieId);
        }

        public void Insert(Metadata metadata)
        {
            _insertedMetadatas.Add(metadata);
        }
    }
}