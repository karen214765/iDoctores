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
    public class perfilesController : ApiController
    {
        private DB_A0FD5F_idoctorsEntities db = new DB_A0FD5F_idoctorsEntities();

        // GET: api/perfiles
        public IQueryable<perfile> Getperfiles()
        {
            return db.perfiles;
        }

        // GET: api/perfiles/5
        [ResponseType(typeof(perfile))]
        public IHttpActionResult Getperfile(int id)
        {
            perfile perfile = db.perfiles.Find(id);
            if (perfile == null)
            {
                return NotFound();
            }

            return Ok(perfile);
        }

        // PUT: api/perfiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putperfile(int id, perfile perfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfile.perfilid)
            {
                return BadRequest();
            }

            db.Entry(perfile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!perfileExists(id))
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

        // POST: api/perfiles
        [ResponseType(typeof(perfile))]
        public IHttpActionResult Postperfile(perfile perfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.perfiles.Add(perfile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = perfile.perfilid }, perfile);
        }

        // DELETE: api/perfiles/5
        [ResponseType(typeof(perfile))]
        public IHttpActionResult Deleteperfile(int id)
        {
            perfile perfile = db.perfiles.Find(id);
            if (perfile == null)
            {
                return NotFound();
            }

            db.perfiles.Remove(perfile);
            db.SaveChanges();

            return Ok(perfile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool perfileExists(int id)
        {
            return db.perfiles.Count(e => e.perfilid == id) > 0;
        }
    }
}