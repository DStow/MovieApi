using System.Collections.Generic;
using MovieApi.Models;
using System.IO;
using System;
using System.Text.RegularExpressions;


namespace MovieApi.Data
{
    public class StatCsvReader : IStatReader
    {
        private string _filePath;
        public StatCsvReader(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Stat> Read()
        {
            var results = new List<Stat>();

            using (var sr = new StreamReader(_filePath))
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    string[] data = line.Split(',', System.StringSplitOptions.None);

                    var newStat = new Stat()
                    {
                        MovieId = Convert.ToInt32(data[0]),
                        watchDurationMs = Convert.ToInt32(data[1])
                    };

                    results.Add(newStat);

                    line = sr.ReadLine();
                }
            }

            return results;
        }
    }
}