using System.Collections.Generic;

namespace Stats
{
    public interface IStatDatabase
    {
        IEnumerable<KeyValuePair<EStatType, Stat>> All { get; }
    }
}