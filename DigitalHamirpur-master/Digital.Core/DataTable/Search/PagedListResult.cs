using System;
using System.Collections.Generic;
using System.Text;

namespace Digital.Core
{
    public class PagedListResult<TEntity>
    {
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
        public long Count { get; set; }
        public IEnumerable<TEntity> Entities { get; set; }
    }
}
