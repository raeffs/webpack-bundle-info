using System.Collections.Generic;

namespace WebpackBundleInfo.Generic
{
    public record Page<T>
    {
        public int PageSize { get; init; }
        public int PageNumber { get; init; }
        public int TotalItems { get; init; }
        public IEnumerable<T> Items { get; init; } = new List<T>();
    }
}
