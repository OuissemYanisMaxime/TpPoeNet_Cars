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
    public class PrestationsController : ApiController
    {
        private Db db = new Db();

        // GET: api/Prestations
        public IQueryable<Prestation> GetPrestations()
        {
            return db.Prestations;
        }

        // GET: api/Prestations/5
        [ResponseType(typeof(Prestation))]
        public IHttpActionResult GetPrestation(int id)
        {
            Prestation prestation = db.Prestations.Find(id);
            if (prestation == null)
            {
                return NotFound();
            }

            return Ok(prestation);
        }

        // PUT: api/Prestations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrestation(int id, Prestation prestation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prestation.Id)
            {
                return BadRequest();
            }

            db.Entry(prestation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestationExists(id))
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

        // POST: api/Prestations
        [ResponseType(typeof(Prestation))]
        public IHttpActionResult PostPrestation(Prestation prestation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prestations.Add(prestation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prestation.Id }, prestation);
        }

        // DELETE: api/Prestations/5
        [ResponseType(typeof(Prestation))]
        public IHttpActionResult DeletePrestation(int id)
        {
            Prestation prestation = db.Prestations.Find(id);
            if (prestation == null)
            {
                return NotFound();
            }

            db.Prestations.Remove(prestation);
            db.SaveChanges();

            return Ok(prestation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrestationExists(int id)
        {
            return db.Prestations.Count(e => e.Id == id) > 0;
        }
    }
}