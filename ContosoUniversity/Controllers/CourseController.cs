using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class CourseController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Courses
        public IQueryable<Course> GetCourse()
        {
            return db.Course;
        }

        // GET: api/Courses/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult GetCourse(int id)
        {
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // PUT: api/Courses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourse(int id, Course course)
        {
           

            if (id != course.Id)
            {
                return BadRequest();
            }

            db.Entry(course).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Courses
        [ResponseType(typeof(Course))]
        public IHttpActionResult PostCourse(Course course)
        {
        

            db.Course.Add(course);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult DeleteCourse(int id)
        {
            Course course = db.Course.Find(id);
            if (course == null)
            {
                return NotFound();
            }

            db.Course.Remove(course);
            db.SaveChanges();

            return Ok(course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseExists(int id)
        {
            return db.Course.Count(e => e.Id == id) > 0;
        }
    }
}