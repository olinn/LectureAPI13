using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAngular.Web.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }
        public int LectureID { get; set; }

		public Comment() {
			CommentTime = DateTime.Now;
		}
    }
}