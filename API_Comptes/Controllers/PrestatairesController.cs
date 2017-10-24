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

namespace API_Comptes.Controllers
{
    public class PrestatairesController : ApiController
    {
        private Db db = new Db();

        // GET: api/Prestataires
        public IQueryable<Prestataire> GetPrestataires()
        {
            return db.Prestataires;
        }

        // GET: api/Prestataires/5
        [ResponseType(typeof(Prestataire))]
        public IHttpActionResult GetPrestataire(int id)
        {
            Prestataire prestataire = db.Prestataires.Find(id);
            if (prestataire == null)
            {
                return NotFound();
            }

            return Ok(prestataire);
        }

        // PUT: api/Prestataires/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrestataire(int id, Prestataire prestataire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prestataire.Id)
            {
                return BadRequest();
            }

            db.Entry(prestataire).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestataireExists(id))
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

        // POST: api/Prestataires
        [ResponseType(typeof(Prestataire))]
        public IHttpActionResult PostPrestataire(Prestataire prestataire)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prestataires.Add(prestataire);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prestataire.Id }, prestataire);
        }

        // DELETE: api/Prestataires/5
        [ResponseType(typeof(Prestataire))]
        public IHttpActionResult DeletePrestataire(int id)
        {
            Prestataire prestataire = db.Prestataires.Find(id);
            if (prestataire == null)
            {
                return NotFound();
            }

            db.Prestataires.Remove(prestataire);
            db.SaveChanges();

            return Ok(prestataire);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrestataireExists(int id)
        {
            return db.Prestataires.Count(e => e.Id == id) > 0;
        }
    }
}