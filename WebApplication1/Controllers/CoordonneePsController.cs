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

namespace WebApplication1.Controllers
{
    public class CoordonneePsController : ApiController
    {
        private Db db = new Db();

        // GET: api/CoordonneePs
        public IQueryable<CoordonneeP> GetCoordonneePs()
        {
            return db.CoordonneePs;
        }

        // GET: api/CoordonneePs/5
        [ResponseType(typeof(CoordonneeP))]
        public IHttpActionResult GetCoordonneeP(int id)
        {
            CoordonneeP coordonneeP = db.CoordonneePs.Find(id);
            if (coordonneeP == null)
            {
                return NotFound();
            }

            return Ok(coordonneeP);
        }

        // PUT: api/CoordonneePs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCoordonneeP(int id, CoordonneeP coordonneeP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coordonneeP.Id)
            {
                return BadRequest();
            }

            db.Entry(coordonneeP).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordonneePExists(id))
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

        // POST: api/CoordonneePs
        [ResponseType(typeof(CoordonneeP))]
        public IHttpActionResult PostCoordonneeP(CoordonneeP coordonneeP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CoordonneePs.Add(coordonneeP);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coordonneeP.Id }, coordonneeP);
        }

        // DELETE: api/CoordonneePs/5
        [ResponseType(typeof(CoordonneeP))]
        public IHttpActionResult DeleteCoordonneeP(int id)
        {
            CoordonneeP coordonneeP = db.CoordonneePs.Find(id);
            if (coordonneeP == null)
            {
                return NotFound();
            }

            db.CoordonneePs.Remove(coordonneeP);
            db.SaveChanges();

            return Ok(coordonneeP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoordonneePExists(int id)
        {
            return db.CoordonneePs.Count(e => e.Id == id) > 0;
        }
    }
}