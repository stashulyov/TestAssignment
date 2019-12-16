using System.Collections.Generic;

namespace Players
{
    public interface IPlayerModelDatabase
    {
        IEnumerable<KeyValuePair<int, IPlayerModel>> All { get; }
        void Add(int id, IPlayerModel model);
        IPlayerModel Get(int id);
    }
}