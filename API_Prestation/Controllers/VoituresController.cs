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

namespace API_Prestation.Controllers
{
    public class VoituresController : ApiController
    {
        private Db db = new Db();

        // GET: api/Voitures
        public IQueryable<Voiture> GetVoitures()
        {
            return db.Voitures;
        }

        // GET: api/Voitures/5
        [ResponseType(typeof(Voiture))]
        public IHttpActionResult GetVoiture(int id)
        {
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return NotFound();
            }

            return Ok(voiture);
        }

        // PUT: api/Voitures/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVoiture(int id, Voiture voiture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voiture.id)
            {
                return BadRequest();
            }

            db.Entry(voiture).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoitureExists(id))
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

        // POST: api/Voitures
        [ResponseType(typeof(Voiture))]
        public IHttpActionResult PostVoiture(Voiture voiture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Voitures.Add(voiture);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = voiture.id }, voiture);
        }

        // DELETE: api/Voitures/5
        [ResponseType(typeof(Voiture))]
        public IHttpActionResult DeleteVoiture(int id)
        {
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return NotFound();
            }

            db.Voitures.Remove(voiture);
            db.SaveChanges();

            return Ok(voiture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoitureExists(int id)
        {
            return db.Voitures.Count(e => e.id == id) > 0;
        }
    }
}