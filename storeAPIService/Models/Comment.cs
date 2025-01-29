using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeAPIService.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime createdOn { get; set; } = DateTime.Now;
        public int? ProductId { get; set; }
        public Product? Product {get; set;}
    }
}