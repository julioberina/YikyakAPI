using System;
using System.Collections.Generic;
using System.Text;

namespace YikyakDataLibrary.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Body { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
