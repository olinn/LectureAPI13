using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAngular.Web.Models
{
    public class User
    {
        public int ID { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
        public int isTeacher { get; set; }
        public string userPassword { get; set; }
    }
}