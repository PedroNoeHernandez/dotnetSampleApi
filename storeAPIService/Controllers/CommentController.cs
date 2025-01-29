using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using storeAPIService.Data;
using storeAPIService.DTOs.Comment;
using storeAPIService.Mappers;
using storeAPIService.Interfaces;
using storeAPIService.Models;
using storeAPIService.Helpers;

namespace storeAPIService.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICommentRepository _commentRepository;
        private readonly IProductRepository _productRepository;

        public CommentController(ApplicationDBContext context, ICommentRepository commentRepository, IProductRepository productRepository)
        {
            _context = context;
            _commentRepository =commentRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var Comments =  await _commentRepository.GetAllAsync();
            var CommentsDTo = Comments.Select(s=> s.ToCommentDTO());
            return Ok(CommentsDTo);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var Comment =  await _commentRepository.GetByIdAsync(id);
            if (Comment == null)
                return NotFound();
            return Ok(Comment.ToCommentDTO());
        }

        [HttpPost("{productId:int}")]
        public async Task<IActionResult> Create([FromRoute] int productId ,[FromBody] CreateCommentRequest CommentDTO ){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            if (! await _productRepository.ProductExist(productId))
                return NotFound();
            var CommentModel = CommentDTO.ToProducctFromDTO(productId);
            await _commentRepository.CreateAsync(CommentModel);
            return CreatedAtAction(nameof(GetById),new{id= CommentModel.Id},CommentModel.ToCommentDTO());
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateCommentRequest CommentDTO){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var CommentModel =  await _commentRepository.UpdateAsync(id,CommentDTO);
            if (CommentModel ==null)
                return NotFound();
            return Ok(CommentModel.ToCommentDTO());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var CommentModel =  await _commentRepository.DeleteAsync(id);
            if (CommentModel ==null)
                return NotFound();
            return NoContent();
        }
    }
}