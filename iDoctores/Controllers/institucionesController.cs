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
    public class institucionesController : ApiController
    {
        private DB_A0FD5F_idoctorsEntities db = new DB_A0FD5F_idoctorsEntities();

        // GET: api/instituciones
        public IQueryable<institucione> Getinstituciones()
        {
            return db.instituciones;
        }

        // GET: api/instituciones/5
        [ResponseType(typeof(institucione))]
        public IHttpActionResult Getinstitucione(int id)
        {
            institucione institucione = db.instituciones.Find(id);
            if (institucione == null)
            {
                return NotFound();
            }

            return Ok(institucione);
        }

        // PUT: api/instituciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putinstitucione(int id, institucione institucione)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != institucione.institucionid)
            {
                return BadRequest();
            }

            db.Entry(institucione).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!institucioneExists(id))
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

        // POST: api/instituciones
        [ResponseType(typeof(institucione))]
        public IHttpActionResult Postinstitucione(institucione institucione)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.instituciones.Add(institucione);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = institucione.institucionid }, institucione);
        }

        // DELETE: api/instituciones/5
        [ResponseType(typeof(institucione))]
        public IHttpActionResult Deleteinstitucione(int id)
        {
            institucione institucione = db.instituciones.Find(id);
            if (institucione == null)
            {
                return NotFound();
            }

            db.instituciones.Remove(institucione);
            db.SaveChanges();

            return Ok(institucione);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool institucioneExists(int id)
        {
            return db.instituciones.Count(e => e.institucionid == id) > 0;
        }
    }
}