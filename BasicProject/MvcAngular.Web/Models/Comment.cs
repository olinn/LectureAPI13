using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAngular.Web.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public virtual User User { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }
        public virtual Lecture Lecture { get; set; }
    }
}