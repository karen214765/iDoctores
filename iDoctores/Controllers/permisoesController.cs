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
    public class permisoesController : ApiController
    {
        private DB_A0FD5F_idoctorsEntities db = new DB_A0FD5F_idoctorsEntities();

        // GET: api/permisoes
        public IQueryable<permiso> Getpermisos()
        {
            return db.permisos;
        }

        // GET: api/permisoes/5
        [ResponseType(typeof(permiso))]
        public IHttpActionResult Getpermiso(int id)
        {
            permiso permiso = db.permisos.Find(id);
            if (permiso == null)
            {
                return NotFound();
            }

            return Ok(permiso);
        }

        // PUT: api/permisoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpermiso(int id, permiso permiso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != permiso.permisoid)
            {
                return BadRequest();
            }

            db.Entry(permiso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!permisoExists(id))
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

        // POST: api/permisoes
        [ResponseType(typeof(permiso))]
        public IHttpActionResult Postpermiso(permiso permiso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.permisos.Add(permiso);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = permiso.permisoid }, permiso);
        }

        // DELETE: api/permisoes/5
        [ResponseType(typeof(permiso))]
        public IHttpActionResult Deletepermiso(int id)
        {
            permiso permiso = db.permisos.Find(id);
            if (permiso == null)
            {
                return NotFound();
            }

            db.permisos.Remove(permiso);
            db.SaveChanges();

            return Ok(permiso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool permisoExists(int id)
        {
            return db.permisos.Count(e => e.permisoid == id) > 0;
        }
    }
}