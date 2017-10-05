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
    public class consultoriosController : ApiController
    {
        private DB_A0FD5F_idoctorsEntities db = new DB_A0FD5F_idoctorsEntities();

        // GET: api/consultorios
        public IQueryable<consultorio> Getconsultorios()
        {
            return db.consultorios;
        }

        // GET: api/consultorios/5
        [ResponseType(typeof(consultorio))]
        public IHttpActionResult Getconsultorio(int id)
        {
            consultorio consultorio = db.consultorios.Find(id);
            if (consultorio == null)
            {
                return NotFound();
            }

            return Ok(consultorio);
        }

        // PUT: api/consultorios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putconsultorio(int id, consultorio consultorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consultorio.consultorioid)
            {
                return BadRequest();
            }

            db.Entry(consultorio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!consultorioExists(id))
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

        // POST: api/consultorios
        [ResponseType(typeof(consultorio))]
        public IHttpActionResult Postconsultorio(consultorio consultorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.consultorios.Add(consultorio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = consultorio.consultorioid }, consultorio);
        }

        // DELETE: api/consultorios/5
        [ResponseType(typeof(consultorio))]
        public IHttpActionResult Deleteconsultorio(int id)
        {
            consultorio consultorio = db.consultorios.Find(id);
            if (consultorio == null)
            {
                return NotFound();
            }

            db.consultorios.Remove(consultorio);
            db.SaveChanges();

            return Ok(consultorio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool consultorioExists(int id)
        {
            return db.consultorios.Count(e => e.consultorioid == id) > 0;
        }
    }
}