using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using storeAPIService.DTOs.Comment;
using storeAPIService.Models;

namespace storeAPIService.Mappers
{
    public static class CommentMapper
    {
        public static CommentDTO ToCommentDTO(this Comment CommentModel){
            return new CommentDTO{
                Id = CommentModel.Id,
                Stars = CommentModel.Stars,
                Title = CommentModel.Title,
                Content = CommentModel.Content,
                CreatedOn = CommentModel.createdOn,
                ProductId = CommentModel.ProductId
            };
        }

        public static Comment ToProducctFromDTO(this CreateCommentRequest CommentDTO, int productId){
            return new Comment{
                Stars = CommentDTO.Stars,
                Title = CommentDTO.Title,
                Content = CommentDTO.Content,
                ProductId = productId
            };
        }
    }
}