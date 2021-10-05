using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiBooksUdemy.PagingHelper
{
    public partial class PaginationVM<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public List<T> Data { get; set; }
    }
}
