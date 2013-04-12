using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MvcAngular.Web.Models;

namespace MvcAngular.Web.Controllers
{
    public class LecturesController : ApiController
    {
        private AppDataContext db = new AppDataContext();

        // GET api/Lectures
        
        public IEnumerable<Lecture> GetLectures()
        {
            return db.Lectures.AsEnumerable();
        }

        // GET api/Lectures/5
        public Lecture GetLecture(int id)
        {
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return lecture;
        }

        // GET api/Lectures/5/Comments
        public IEnumerable<Comment> GetLecture(int id, string more)
        {
            IEnumerable<Comment> comments = db.Comments.Where(x => x.LectureID == id).AsEnumerable();

            return comments;
        }

        // PUT api/Lectures/5
        public HttpResponseMessage PutLecture(int id, Lecture lecture)
        {
            if (ModelState.IsValid && id == lecture.ID)
            {
                db.Entry(lecture).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Lectures
        public HttpResponseMessage PostLecture(Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.Lectures.Add(lecture);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, lecture);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = lecture.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Lectures/5
        public HttpResponseMessage DeleteLecture(int id)
        {
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Lectures.Remove(lecture);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, lecture);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}