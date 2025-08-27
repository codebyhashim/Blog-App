using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Comment
    {
        public int CommentId { get; set; }   // Primary Key
        public string? Content { get; set; }  // Comment text
        public int BlogPostId { get; set; }  // FK -> BlogPosts
        public string? UserId { get; set; }   // FK -> AspNetUsers
        public bool IsDeleted { get; set; }  // Soft delete
        public DateTime CreatedAt { get; set; } // Timestamp
    }
}
