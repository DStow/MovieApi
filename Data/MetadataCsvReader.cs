using System.Collections.Generic;
using MovieApi.Models;
using System.IO;
using System;
using System.Text.RegularExpressions;

namespace MovieApi.Data
{
    public class MetadataCsvReader : IMetadataReader
    {
        private string _filePath;
        public MetadataCsvReader(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Metadata> Read()
        {
            var results = new List<Metadata>();

            using (var sr = new StreamReader(_filePath))
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    //string[] data = line.Split(',', System.StringSplitOptions.None);

                    Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                    String[] data = CSVParser.Split(line);

                    var newMetadata = new Metadata()
                    {
                        Id = Convert.ToInt32(data[0]),
                        MovieId = Convert.ToInt32(data[1]),
                        Title = data[2],
                        Language = data[3],
                        Duration = data[4],
                        ReleaseYear = Convert.ToInt32(data[5])
                    };

                    results.Add(newMetadata);

                    line = sr.ReadLine();
                }
            }

            return results;
        }
    }
}