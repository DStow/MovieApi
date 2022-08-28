using System.Collections.Generic;

namespace MovieApi.Data
{
    public interface IStatReader
    {
        IEnumerable<Models.Stat> Read();
    }
}