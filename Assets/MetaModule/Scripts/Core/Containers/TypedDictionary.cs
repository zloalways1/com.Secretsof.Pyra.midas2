using System;
using System.Collections.Generic;

namespace Infrastructure.Common
{
    public class TypedDictionary<TEntry>
    {
        private Dictionary<Type, TEntry> _entries = new Dictionary<Type, TEntry>();

        public bool Has<TRequest>() => _entries.ContainsKey(typeof(TRequest));
        
        public bool Has(Type type) => _entries.ContainsKey(type);
        
        public TRequest Get<TRequest>() where TRequest : class, TEntry
        {
            Type type = typeof(TRequest);
            
            if (_entries.TryGetValue(type, out TEntry entry))
                return entry as TRequest;
            
            return null;
        }

        public TRequest Create<TRequest>() where TRequest : class, TEntry, new()
        {
            Type type = typeof(TRequest);
            
            if (!_entries.TryGetValue(type, out var entry))
            {
                TRequest request = new TRequest();
                _entries.Add(type, request);

                return request;
            }

            return entry as TRequest;
        }
        
        public void Register(Type type, TEntry instance)
        {
            if (!_entries.ContainsKey(type))
                _entries.Add(type, instance);
        }
    }
}