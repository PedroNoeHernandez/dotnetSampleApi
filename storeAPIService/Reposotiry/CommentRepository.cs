using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using storeAPIService.Data;
using storeAPIService.DTOs.Comment;
using storeAPIService.Interfaces;
using storeAPIService.Models;

namespace storeAPIService.Reposotiry
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment CommentModel)
        {
            await _context.Comment.AddAsync(CommentModel);
            await _context.SaveChangesAsync();
            return CommentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var CommentModel =  await _context.Comment.FirstOrDefaultAsync(x=> x.Id == id);
            if(CommentModel == null)
                return null;
            _context.Comment.Remove(CommentModel);
            await _context.SaveChangesAsync();
            return CommentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comment.FindAsync(id);
        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommentRequest CommentDTO)
        {
            var CommentModel = await _context.Comment.FirstOrDefaultAsync(x=> x.Id == id);
            if (CommentModel == null)
                return null;
            CommentModel.Content = (CommentDTO.Content!="")?CommentDTO.Content:CommentModel.Content;
            CommentModel.Title = (CommentDTO.Title!="")?CommentDTO.Title:CommentModel.Title;
            CommentModel.Stars = CommentDTO.Stars;
            await _context.SaveChangesAsync();
            return CommentModel;
        }

    }
}