using System.Collections.Generic;
using Common;

namespace Ui.UiModel
{
    public interface IUiModelDatabase
    {
        IEnumerable<KeyValuePair<int, IUiModel>> All { get; }
        void Add(int id, IUiModel uiModel);
        IUiModel Get(int playerId);
    }
}