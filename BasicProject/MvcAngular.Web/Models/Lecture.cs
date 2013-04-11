using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAngular.Web.Models
{
    public class Lecture
    {
        public int ID { get; set; }
        public string LectureTitle { get; set; }
        public string LectureURL { get; set; }
        public string TeacherName { get; set; }
        public DateTime PubDate { get; set; }

    }
}