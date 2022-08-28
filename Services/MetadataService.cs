using System.Collections.Generic;
using MovieApi.Models;
using MovieApi.Repositories;
using System.Linq;

namespace MovieApi.Services
{
    public class MetadataService : IMetadataService
    {
        private IMetadataRepository _metadataRepository;
        public MetadataService(IMetadataRepository metadataRepository)
        {
            _metadataRepository = metadataRepository;
        }

        public IEnumerable<Metadata> GetMetadatas(int movieId)
        {
            // holds all records for the movieId
            IEnumerable<Metadata> records = _metadataRepository.GetMetadatas(movieId);

            // Null will be used to return the 404 requirement
            if (records.Count() == 0)
                return null;

            IEnumerable<Metadata> results = FilterToSingleLanguageEntries(records);
            return results;
        }

        private IEnumerable<Metadata> FilterToSingleLanguageEntries(IEnumerable<Metadata> records)
        {
            List<Metadata> results = new List<Metadata>();

            string[] movieLanguages = records.Select(x => x.Language).Distinct().ToArray();

            foreach (var language in movieLanguages)
            {
                var languageSpecificRecords = records.Where(x => x.Language == language);

                int maxLanguageId = languageSpecificRecords.Max(x => x.Id);

                results.Add(records.FirstOrDefault(x => x.Language == language && x.Id == maxLanguageId));
            }

            return results;
        }
    }
}