using System;
using System.Collections.Generic;

namespace Infrastructure.Common
{
    public class TypedHashSet<TEntry>
    {
        private HashSet<TEntry> _entries = new HashSet<TEntry>();

        public void Add<TRequest>(TRequest instance) where TRequest : class, TEntry
        {
            _entries.Add(instance);
        }

        public void ForEach(Action<TEntry> action)
        {
            foreach (TEntry entry in _entries)
                action?.Invoke(entry);
        }
    }
}