using System.Collections.Generic;

namespace GameData
{
    public interface IStatUiDatabase
    {
        IEnumerable<KeyValuePair<EStatType, StatUi>> All { get; }
    }
}