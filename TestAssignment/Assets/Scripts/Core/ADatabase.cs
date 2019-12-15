using System.Collections.Generic;

namespace Core
{
    public class ADatabase<TKey, TValue>
    {
        public IEnumerable<KeyValuePair<TKey, TValue>> All => _dictionary;

        private readonly Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();

        public bool Has(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        public void Add(TKey key, TValue value)
        {
            _dictionary.Add(key, value);
        }

        public TValue Get(TKey key)
        {
            return _dictionary[key];
        }
    }
}