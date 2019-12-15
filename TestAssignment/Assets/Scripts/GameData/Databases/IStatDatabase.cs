using System.Collections.Generic;

namespace GameData
{
    public interface IStatDatabase
    {
        IEnumerable<KeyValuePair<EStatType, Stat>> All { get; }
    }
}