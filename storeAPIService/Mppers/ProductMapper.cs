using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using storeAPIService.DTOs.Comment;
using storeAPIService.DTOs.Product;
using storeAPIService.Models;

namespace storeAPIService.Mappers
{
    public static class ProductMapper
    {
        public static ProductDTO toProductDTO(this Product productModel){
            return new ProductDTO{
                Id = productModel.Id,
                Name = productModel.Name,
                Description = productModel.Description,
                Model = productModel.Model,
                Color = productModel.Color,
                HexColor = productModel.HexColor,
                B64Image = productModel.B64Image,
                Properties = productModel.Properties,
                Price = productModel.Price,
                Cost = productModel.Cost,
                Comments = productModel.Comments.Select(c => c.ToCommentDTO()).ToList()
            };
        }

        public static Product toProducctFromDTO(this CreateProductRequest productDTO){
            return new Product{
                Name = productDTO.Name,
                Description = productDTO.Description,
                Model = productDTO.Model,
                Color = productDTO.Color,
                HexColor = productDTO.HexColor,
                B64Image = productDTO.B64Image,
                Properties = productDTO.Properties,
                Price = productDTO.Price,
                Cost = productDTO.Cost
            };
        }
    }
}