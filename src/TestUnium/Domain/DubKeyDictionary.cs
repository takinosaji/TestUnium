using System;
using System.Collections.Generic;
using System.Linq;

namespace TestUnium.Domain
{
    public class DubKeyDictionary<TKey, TValue> : List<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>
    {
        public Boolean ContainsKey(TKey key)
        {
            return this.Any(kvp => kvp.Key.GetHashCode() == key.GetHashCode());
        }

        public void Add(TKey key, TValue value)
        {
            Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public Boolean Remove(TKey key)
        {
            return Remove(Find(kvp => kvp.Key.GetHashCode() == key.GetHashCode()));
        }

        public Boolean TryGetValue(TKey key, out TValue value)
        {
            var result = this.Any(kvp => kvp.Key.GetHashCode() == key.GetHashCode());
            value = this.FirstOrDefault(kvp => kvp.Key.GetHashCode() == key.GetHashCode()).Value;
            return result;
        }

        public TValue this[TKey key]
        {
            get { return this.FirstOrDefault(kvp => kvp.Key.GetHashCode() == key.GetHashCode()).Value; }
            set
            {
                if (this.Any(kvp => kvp.Key.GetHashCode() == key.GetHashCode()))
                {
                    Add(new KeyValuePair<TKey, TValue>(key, value));
                }
            }
        }

        public ICollection<TKey> Keys => this.Select(kvp => kvp.Key).ToList();
        public ICollection<TValue> Values => this.Select(kvp => kvp.Value).ToList();
    }
}
