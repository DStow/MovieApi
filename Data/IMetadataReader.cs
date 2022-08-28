using System.Collections.Generic;

namespace MovieApi.Data
{
    public interface IMetadataReader
    {
        IEnumerable<Models.Metadata> Read();
    }
}