using System.Collections.Generic;

namespace Common
{
    public interface IUiModelDatabase
    {
        IEnumerable<KeyValuePair<int, IUiModel>> All { get; }
        void Add(int id, IUiModel uiModel);
    }
}