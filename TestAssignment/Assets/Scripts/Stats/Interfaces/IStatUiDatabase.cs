using System.Collections.Generic;

namespace Stats
{
    public interface IStatUiDatabase
    {
        IEnumerable<KeyValuePair<EStatType, StatUi>> All { get; }
    }
}