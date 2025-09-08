using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class UpdateBlogDto
    {
        public int BlogPostId { get; set; }    // Primary Key

        public string? Title { get; set; }      // Post title
        public string? Content { get; set; }    // Post content
        public string? ImageUrl { get; set; }   // Image URL
        public string? UserId { get; set; }     // FK -> AspNetUsers
        public int? CategoryId { get; set; }   // FK -> Categories
        public PostStatus? Status { get; set; } // Draft/Published
 
    }
 
}
