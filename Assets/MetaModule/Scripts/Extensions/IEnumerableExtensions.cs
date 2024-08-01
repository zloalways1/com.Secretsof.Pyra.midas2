using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Infrastructure.Extensions
{
    public static class IEnumerableExtensions
    {
        public static TSource RandomElement<TSource>(this IEnumerable<TSource> enumerable)
        {
            List<TSource> sources = enumerable.ToList();
            int index = Random.Range(0, sources.Count);
            
            return sources.ElementAt(index);
        }
    }
}