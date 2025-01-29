using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAPIService.Helpers
{
    public class QueryObject
    {
        public string? Name { get; set; } =null;
        public string? Description  { get; set; }=null;
        public string? SortBy { get; set; }=null;
        public bool decending { get; set; }= false;
        public int page { get; set; }=1;

        public int pageSize { get; set; } = 20;
    
    }
}