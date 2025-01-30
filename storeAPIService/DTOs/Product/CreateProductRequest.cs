using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace storeAPIService.DTOs.Product
{
    public class CreateProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Model  { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        [RegularExpression(@"^#(?:[0-9a-fA-F]{3}){1,2}$", 
         ErrorMessage = "Invalid hexadecimal color")]
        public string HexColor { get; set; } = string.Empty;
        public string B64Image { get; set; } = string.Empty;
        public string Properties { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Cost { get; set; }

    }
}