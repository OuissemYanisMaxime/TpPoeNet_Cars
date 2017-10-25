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
        [Authorize(Roles = "Admin, Technicien, Prestataire, Client")]
        public IQueryable<Prestataire> GetPrestataires()
        {
            return db.Prestataires;
        }

        // GET: api/Prestataires/5
        [ResponseType(typeof(Prestataire))]
        [Authorize(Roles = "Admin, Technicien, Prestataire, Client")]
        public IHttpActionResult GetPrestataire(int id)
        {
            Prestataire prestataire = db.Prestataires.Find(id);
            if (prestataire == null)
            {
                return NotFound();
            }

            return Ok(prestataire);
        }

        // GET: api/Clients/email/?email=****@****
        [Authorize(Roles = "Admin, Technicien, Prestataire, Client")]
        [ResponseType(typeof(Prestataire))]
        [Route("api/prestataires/email")]
        public Prestataire GetPrestataire(string email)
        {
            IQueryable<Prestataire> prestataires = db.Prestataires.Include(p => p.Coordonnee).Include(p=>p.Voiture).Where(p => p.Coordonnee.Mail == email);
            if (prestataires.Count() != 0)
                return prestataires.First();
            else
                return default(Prestataire);

            //return Ok(client);
        }

        // PUT: api/Prestataires/5
        [ResponseType(typeof(void))]
        [Authorize(Roles = "Admin, Technicien, Prestataire")]
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
            db.Entry(prestataire.Coordonnee).State = EntityState.Modified;
            db.Entry(prestataire.Voiture).State = EntityState.Modified;

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
        [Authorize(Roles = "Admin, Prestataire")]
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
        [Authorize(Roles = "Admin, Technicien")]
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

        [Authorize(Roles = "Admin, Technicien, Prestataire, Client")]
        private bool PrestataireExists(int id)
        {
            return db.Prestataires.Count(e => e.Id == id) > 0;
        }
    }
}