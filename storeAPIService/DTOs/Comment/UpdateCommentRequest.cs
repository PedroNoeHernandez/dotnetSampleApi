using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace storeAPIService.DTOs.Comment
{
    public class UpdateCommentRequest
    {
        [Required]
        [Range(1,5, ErrorMessage = "Value must be between 1 and 5")]
        public int Stars { get; set; }
        [Required]
        [MinLength(5,ErrorMessage = "Value must be 5 character at lease")]
        [MaxLength(200,ErrorMessage = "Value cant have more than 200  characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
         [MinLength(15,ErrorMessage = "Value must be 15 character at lease")]
        [MaxLength(500,ErrorMessage = "Value cant have more than 500  characters")]
        public string Content { get; set; } = string.Empty;

    }
}