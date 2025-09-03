using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public enum ReactionType
    {
        Like = 1,
        Dislike = 2
    }
    public class PostReactionModel
    {
        public int BlogPostId { get; set; }   // FK -> BlogPosts, part of composite PK
        public string? UserId { get; set; }    // FK -> AspNetUsers, part of composite PK
        public ReactionType ReactionType { get; set; } // Enum: Like/Dislike
        public DateTime CreatedAt { get; set; }        // Timestamp
    }
}
