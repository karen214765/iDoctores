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
    public class especialidadesController : ApiController
    {
        private DB_A0FD5F_idoctorsEntities db = new DB_A0FD5F_idoctorsEntities();

        // GET: api/especialidades
        public IQueryable<especialidade> Getespecialidades()
        {
            return db.especialidades;
        }

        // GET: api/especialidades/5
        [ResponseType(typeof(especialidade))]
        public IHttpActionResult Getespecialidade(int id)
        {
            especialidade especialidade = db.especialidades.Find(id);
            if (especialidade == null)
            {
                return NotFound();
            }

            return Ok(especialidade);
        }

        // PUT: api/especialidades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putespecialidade(int id, especialidade especialidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != especialidade.especialidadid)
            {
                return BadRequest();
            }

            db.Entry(especialidade).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!especialidadeExists(id))
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

        // POST: api/especialidades
        [ResponseType(typeof(especialidade))]
        public IHttpActionResult Postespecialidade(especialidade especialidade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.especialidades.Add(especialidade);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = especialidade.especialidadid }, especialidade);
        }

        // DELETE: api/especialidades/5
        [ResponseType(typeof(especialidade))]
        public IHttpActionResult Deleteespecialidade(int id)
        {
            especialidade especialidade = db.especialidades.Find(id);
            if (especialidade == null)
            {
                return NotFound();
            }

            db.especialidades.Remove(especialidade);
            db.SaveChanges();

            return Ok(especialidade);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool especialidadeExists(int id)
        {
            return db.especialidades.Count(e => e.especialidadid == id) > 0;
        }
    }
}