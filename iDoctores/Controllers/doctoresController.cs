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
using iDoctores;

namespace iDoctores.Controllers
{
    public class doctoresController : ApiController
    {
        private DB_A0FD5F_idoctorsEntities db = new DB_A0FD5F_idoctorsEntities();

        // GET: api/doctores
        public IQueryable<doctore> Getdoctores()
        {
            return db.doctores;
        }

        // GET: api/doctores/5
        [ResponseType(typeof(doctore))]
        public IHttpActionResult Getdoctore(int id)
        {
            doctore doctore = db.doctores.Find(id);
            if (doctore == null)
            {
                return NotFound();
            }

            return Ok(doctore);
        }

        // PUT: api/doctores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdoctore(int id, doctore doctore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doctore.doctorid)
            {
                return BadRequest();
            }

            db.Entry(doctore).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!doctoreExists(id))
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

        // POST: api/doctores
        [ResponseType(typeof(doctore))]
        public IHttpActionResult Postdoctore(doctore doctore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.doctores.Add(doctore);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = doctore.doctorid }, doctore);
        }

        // DELETE: api/doctores/5
        [ResponseType(typeof(doctore))]
        public IHttpActionResult Deletedoctore(int id)
        {
            doctore doctore = db.doctores.Find(id);
            if (doctore == null)
            {
                return NotFound();
            }

            db.doctores.Remove(doctore);
            db.SaveChanges();

            return Ok(doctore);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool doctoreExists(int id)
        {
            return db.doctores.Count(e => e.doctorid == id) > 0;
        }
    }
}