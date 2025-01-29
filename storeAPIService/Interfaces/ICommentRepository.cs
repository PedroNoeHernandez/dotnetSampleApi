using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using storeAPIService.DTOs.Comment;
using storeAPIService.DTOs.Product;
using storeAPIService.Models;

namespace storeAPIService.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment CommentModel);
        Task<Comment?> UpdateAsync(int id, UpdateCommentRequest CommentDTO);
        Task<Comment?> DeleteAsync(int id);
    }
}