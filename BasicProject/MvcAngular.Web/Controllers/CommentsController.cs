﻿using System;
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
    public class CommentsController : ApiController
    {
        private AppDataContext db = new AppDataContext();

        // GET api/Comments
        public IEnumerable<Comment> GetComments()
        {
            return db.Comments.AsEnumerable();
        }

        // GET api/Comments/5
        public Comment GetComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return comment;
        }

        // PUT api/Comments/5
        public HttpResponseMessage PutComment(int id, Comment comment)
        {
            if (ModelState.IsValid && id == comment.ID)
            {
                db.Entry(comment).State = EntityState.Modified;

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

        // POST api/Comments
        public HttpResponseMessage PostComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, comment);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = comment.ID }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Comments/5
        public HttpResponseMessage DeleteComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Comments.Remove(comment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, comment);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}