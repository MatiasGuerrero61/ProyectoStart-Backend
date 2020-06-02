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
    public class StudentController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Student
        public IQueryable<Student> GetStudent()
        {
            return db.Student;
        }

        // GET: api/Student/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Student/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {

            if (id != student.Id)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Student
        [ResponseType(typeof(Student))]
        public IHttpActionResult PostStudent(Student student)
        {

            db.Student.Add(student);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student.Id }, student);
        }

        // DELETE: api/Student/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Student.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Student.Count(e => e.Id == id) > 0;
        }
    }
}