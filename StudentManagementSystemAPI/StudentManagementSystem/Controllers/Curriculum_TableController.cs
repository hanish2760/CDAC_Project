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
using StudentManagementSystem;

namespace StudentManagementSystem.Controllers
{
    public class Curriculum_TableController : ApiController
    {
        private StudentManagementSystemEntities3 db = new StudentManagementSystemEntities3();

        // GET: api/Curriculum_Table
        public IQueryable<Curriculum_Table> GetCurriculum_Table()
        {
            return db.Curriculum_Table;
        }

        // GET: api/Curriculum_Table/5
        [ResponseType(typeof(Curriculum_Table))]
        public IHttpActionResult GetCurriculum_Table(int id)
        {
            Curriculum_Table curriculum_Table = db.Curriculum_Table.Find(id);
            if (curriculum_Table == null)
            {
                return NotFound();
            }

            return Ok(curriculum_Table);
        }

        // PUT: api/Curriculum_Table/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCurriculum_Table(int id, Curriculum_Table curriculum_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != curriculum_Table.Userid)
            {
                return BadRequest();
            }

            db.Entry(curriculum_Table).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Curriculum_TableExists(id))
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

        // POST: api/Curriculum_Table
        [ResponseType(typeof(Curriculum_Table))]
        public IHttpActionResult PostCurriculum_Table(Curriculum_Table curriculum_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Curriculum_Table.Add(curriculum_Table);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Curriculum_TableExists(curriculum_Table.Userid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = curriculum_Table.Userid }, curriculum_Table);
        }

        // DELETE: api/Curriculum_Table/5
        [ResponseType(typeof(Curriculum_Table))]
        public IHttpActionResult DeleteCurriculum_Table(int id)
        {
            Curriculum_Table curriculum_Table = db.Curriculum_Table.Find(id);
            if (curriculum_Table == null)
            {
                return NotFound();
            }

            db.Curriculum_Table.Remove(curriculum_Table);
            db.SaveChanges();

            return Ok(curriculum_Table);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Curriculum_TableExists(int id)
        {
            return db.Curriculum_Table.Count(e => e.Userid == id) > 0;
        }
    }
}