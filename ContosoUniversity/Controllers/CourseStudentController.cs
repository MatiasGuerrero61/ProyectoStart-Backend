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
    public class CourseStudentController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/CourseStudents
        public IQueryable<CourseStudent> GetCourseStudent()
        {
            return db.CourseStudent;
        }

        // GET: api/CourseStudents/5
        [ResponseType(typeof(CourseStudent))]
        public IHttpActionResult GetCourseStudent(int id)
        {
            CourseStudent courseStudent = db.CourseStudent.Find(id);
            if (courseStudent == null)
            {
                return NotFound();
            }

            return Ok(courseStudent);
        }

        // PUT: api/CourseStudents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCourseStudent(int id, CourseStudent courseStudent)
        {

            if (id != courseStudent.Id)
            {
                return BadRequest();
            }

            db.Entry(courseStudent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseStudentExists(id))
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

        // POST: api/CourseStudents
        [ResponseType(typeof(CourseStudent))]
        public IHttpActionResult PostCourseStudent(CourseStudent courseStudent)
        {

            db.CourseStudent.Add(courseStudent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = courseStudent.Id }, courseStudent);
        }

        // DELETE: api/CourseStudents/5
        [ResponseType(typeof(CourseStudent))]
        public IHttpActionResult DeleteCourseStudent(int id)
        {
            CourseStudent courseStudent = db.CourseStudent.Find(id);
            if (courseStudent == null)
            {
                return NotFound();
            }

            db.CourseStudent.Remove(courseStudent);
            db.SaveChanges();

            return Ok(courseStudent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CourseStudentExists(int id)
        {
            return db.CourseStudent.Count(e => e.Id == id) > 0;
        }
    }
}