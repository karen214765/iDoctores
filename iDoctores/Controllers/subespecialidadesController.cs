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
    public class subespecialidadesController : ApiController
    {
        private DB_A0FD5F_idoctorsEntities db = new DB_A0FD5F_idoctorsEntities();

        // GET: api/subespecialidades
        public IQueryable<subespecialidade> Getsubespecialidades()
        {
            return db.subespecialidades;
        }

        // GET: api/subespecialidades/5
        [ResponseType(typeof(subespecialidade))]
        public IHttpActionResult Getsubespecialidade(int id)
        {
            subespecialidade subespecialidade = db.subespecialidades.Find(id);
            if (subespecialidade == null)
            {
                return NotFound();
            }

            return Ok(subespecialidade);
        }

        // PUT: api/subespecialidades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsubespecialidade(int id, subespecialidade subespecialidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subespecialidade.subespecialidadid)
            {
                return BadRequest();
            }

            db.Entry(subespecialidade).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!subespecialidadeExists(id))
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

        // POST: api/subespecialidades
        [ResponseType(typeof(subespecialidade))]
        public IHttpActionResult Postsubespecialidade(subespecialidade subespecialidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.subespecialidades.Add(subespecialidade);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subespecialidade.subespecialidadid }, subespecialidade);
        }

        // DELETE: api/subespecialidades/5
        [ResponseType(typeof(subespecialidade))]
        public IHttpActionResult Deletesubespecialidade(int id)
        {
            subespecialidade subespecialidade = db.subespecialidades.Find(id);
            if (subespecialidade == null)
            {
                return NotFound();
            }

            db.subespecialidades.Remove(subespecialidade);
            db.SaveChanges();

            return Ok(subespecialidade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool subespecialidadeExists(int id)
        {
            return db.subespecialidades.Count(e => e.subespecialidadid == id) > 0;
        }
    }
}