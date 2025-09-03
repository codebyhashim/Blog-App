using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class PostTagModel
    {
        public int BlogPostId { get; set; } // FK -> BlogPosts, part of composite PK
        public int TagId { get; set; }      // FK -> Tags, part of composite PK
    }
}
