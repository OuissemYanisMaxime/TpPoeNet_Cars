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
    public class CoordonneeCsController : ApiController
    {
        private Db db = new Db();

        // GET: api/CoordonneeCs
        public IQueryable<CoordonneeC> GetCoordonneeCs()
        {
            return db.CoordonneeCs;
        }

        // GET: api/CoordonneeCs/5
        [ResponseType(typeof(CoordonneeC))]
        public IHttpActionResult GetCoordonneeC(int id)
        {
            CoordonneeC coordonneeC = db.CoordonneeCs.Find(id);
            if (coordonneeC == null)
            {
                return NotFound();
            }

            return Ok(coordonneeC);
        }

        // PUT: api/CoordonneeCs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCoordonneeC(int id, CoordonneeC coordonneeC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coordonneeC.Id)
            {
                return BadRequest();
            }

            db.Entry(coordonneeC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordonneeCExists(id))
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

        // POST: api/CoordonneeCs
        [ResponseType(typeof(CoordonneeC))]
        public IHttpActionResult PostCoordonneeC(CoordonneeC coordonneeC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CoordonneeCs.Add(coordonneeC);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coordonneeC.Id }, coordonneeC);
        }

        // DELETE: api/CoordonneeCs/5
        [ResponseType(typeof(CoordonneeC))]
        public IHttpActionResult DeleteCoordonneeC(int id)
        {
            CoordonneeC coordonneeC = db.CoordonneeCs.Find(id);
            if (coordonneeC == null)
            {
                return NotFound();
            }

            db.CoordonneeCs.Remove(coordonneeC);
            db.SaveChanges();

            return Ok(coordonneeC);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoordonneeCExists(int id)
        {
            return db.CoordonneeCs.Count(e => e.Id == id) > 0;
        }
    }
}