using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace storeAPIService.DTOs.Comment
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Model  { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string HexColor { get; set; } = string.Empty;
        public string B64Image { get; set; } = string.Empty;
        public string Properties { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public List<CommentDTO> Comments {get;set;} = new List<CommentDTO>();

    }
}