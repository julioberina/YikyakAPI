using System;
using System.Collections.Generic;
using System.Text;

namespace YikyakDataLibrary.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Body { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
