using System.Collections.Generic;

namespace Ui
{
    public interface IUiModelDatabase
    {
        IEnumerable<KeyValuePair<int, IUiModel>> All { get; }
        void Add(int id, IUiModel uiModel);
        IUiModel Get(int playerId);
    }
}