using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model;

namespace Application.model.Dto
{
    public class BlogCreateDto
    {
        public string? Title { get; set; }      // Post title
        public string? Content { get; set; }    // Post content
        public string? ImageUrl { get; set; }   // Image URL
        public string? UserId { get; set; }     // FK -> AspNetUsers
        public int? CategoryId { get; set; }   // FK -> Categories
        public PostStatus? Status { get; set; } // Draft/Published
        public bool? IsDeleted { get; set; }    // Soft delete
    }
    public enum PostStatus
    {
        Draft = 1,
        Published = 2
    }
}
