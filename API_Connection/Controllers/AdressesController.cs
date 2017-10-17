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
using DAO.modeles;

namespace API_Connection.Controllers
{
    public class AdressesController : ApiController
    {
        private Db db = new Db();

        // GET: api/Adresses
        public IQueryable<Adresse> GetAdresses()
        {
            return db.Adresses;
        }

        // GET: api/Adresses/5
        [ResponseType(typeof(Adresse))]
        public IHttpActionResult GetAdresse(int id)
        {
            Adresse adresse = db.Adresses.Find(id);
            if (adresse == null)
            {
                return NotFound();
            }

            return Ok(adresse);
        }

        // PUT: api/Adresses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdresse(int id, Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adresse.Id)
            {
                return BadRequest();
            }

            db.Entry(adresse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdresseExists(id))
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

        // POST: api/Adresses
        [ResponseType(typeof(Adresse))]
        public IHttpActionResult PostAdresse(Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Adresses.Add(adresse);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adresse.Id }, adresse);
        }

        // DELETE: api/Adresses/5
        [ResponseType(typeof(Adresse))]
        public IHttpActionResult DeleteAdresse(int id)
        {
            Adresse adresse = db.Adresses.Find(id);
            if (adresse == null)
            {
                return NotFound();
            }

            db.Adresses.Remove(adresse);
            db.SaveChanges();

            return Ok(adresse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdresseExists(int id)
        {
            return db.Adresses.Count(e => e.Id == id) > 0;
        }
    }
}