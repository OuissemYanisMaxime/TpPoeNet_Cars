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
    public class CoordonneesController : ApiController
    {
        private Db db = new Db();

        // GET: api/Coordonnees
        public IQueryable<Coordonnee> GetCoordonnees()
        {
            return db.Coordonnees;
        }

        // GET: api/Coordonnees/5
        [ResponseType(typeof(Coordonnee))]
        public IHttpActionResult GetCoordonnee(int id)
        {
            Coordonnee coordonnee = db.Coordonnees.Find(id);
            if (coordonnee == null)
            {
                return NotFound();
            }

            return Ok(coordonnee);
        }

        // PUT: api/Coordonnees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCoordonnee(int id, Coordonnee coordonnee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coordonnee.Id)
            {
                return BadRequest();
            }

            db.Entry(coordonnee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordonneeExists(id))
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

        // POST: api/Coordonnees
        [ResponseType(typeof(Coordonnee))]
        public IHttpActionResult PostCoordonnee(Coordonnee coordonnee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Coordonnees.Add(coordonnee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coordonnee.Id }, coordonnee);
        }

        // DELETE: api/Coordonnees/5
        [ResponseType(typeof(Coordonnee))]
        public IHttpActionResult DeleteCoordonnee(int id)
        {
            Coordonnee coordonnee = db.Coordonnees.Find(id);
            if (coordonnee == null)
            {
                return NotFound();
            }

            db.Coordonnees.Remove(coordonnee);
            db.SaveChanges();

            return Ok(coordonnee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoordonneeExists(int id)
        {
            return db.Coordonnees.Count(e => e.Id == id) > 0;
        }
    }
}