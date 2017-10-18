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
    public class Prestations1Controller : ApiController
    {
        private Db db = new Db();

        // GET: api/Prestations1
        public IQueryable<Prestation> GetPrestations()
        {
            return db.Prestations;
        }

        // GET: api/Prestations1/5
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

        // PUT: api/Prestations1/5
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

        // POST: api/Prestations1
        //[ResponseType(typeof(Prestation))]
        //[Route("api/CreerPrestation/{IdClient}")]//{RueDep}/{CodePostalDep}/{VilleDep}/{RueArr}/{CodePostalArr}/{VilleArr}")]
        //public IHttpActionResult PostPrestation2(int IdCli)//, string RueDep, int CodePostalDep, string VilleDep, string RueArr, int CodePostalArr, string VilleArr)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Prestation prestation = new Prestation();           
        //    prestation.IdClient = IdCli;
        //obligatoire
        //prestation.RueDep = RueDep;
        //prestation.RueArr = RueArr;
        //prestation.CodePostalDep = CodePostalDep;
        //prestation.CodePostalArr = CodePostalArr;
        //prestation.VilleDep = VilleDep;
        //prestation.VilleArr = VilleArr;            

        //public int Id { get; set; }    
        //public int IdPrestataire { get; set; }
        //public DateTime HorairesDebut { get; set; }
        //public DateTime HorairesFin { get; set; }
        //public decimal Prix { get; set; }
        //public decimal Salaire_presta { get; set; }
        //public int Note { get; set; }        
        //public string Avis { get; set; }
        //public Status Etat { get; set; }

        //    db.Prestations.Add(prestation);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = prestation.Id }, prestation);
        //}

        // POST: api/Prestations1
        [ResponseType(typeof(Prestation))]
        public IHttpActionResult PostPrestation3(Prestation prestation)
        {
            
        }

        // POST: api/Prestations1
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

        // DELETE: api/Prestations1/5
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