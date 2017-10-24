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
using System.Xml.Linq;
using System.Globalization;


namespace API_Prestation.Controllers
{
    public class Prestataires1Controller : ApiController
    {
        private Db db = new Db();

        public static double GetDistanceBetween(double latitudePointA, double longitudePointA, double latitudePointB, double longitudePointB)
        {
            double dDistance = Double.MinValue;

            // Convert coordinates to radians
            double dLatAInRad = latitudePointA * (Math.PI / 180.0);
            double dLongAInRad = longitudePointA * (Math.PI / 180.0);
            double dLatBInRad = latitudePointB * (Math.PI / 180.0);
            double dLongBInRad = longitudePointB * (Math.PI / 180.0);

            double dLongitude = dLongBInRad - dLongAInRad;
            double dLatitude = dLatBInRad - dLatAInRad;

            // Intermediate result a.
            double a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) +
                        Math.Cos(dLatAInRad) * Math.Cos(dLatBInRad) *
                        Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Intermediate result c (great circle distance in Radians).
            double c = 2.0 * Math.Asin(Math.Sqrt(a));

            // Distance.
            const Double kEarthRadiusKms = 6376.5;
            dDistance = kEarthRadiusKms * c;

            return dDistance;
        }

        // A FAIRE
        // GET: api/GetPrestatairesLibresEtProches/id
        [Route("api/GetPrestatairesLibresEtProches/{idCli}")]
        public Prestataire GetPrestatairesLibresEtProches(int idCli) //IQueryable<Prestataire> GetPrestatairesLibresEtProches(int idCli)
        {
            Prestation p = db.Prestations.Find(idCli);
            var address = p.RueDep + " " + p.VilleDep; // "123 something st, somewhere"; /*https://www.google.fr/maps/@50.5961833,3.0853137,12z*/
            var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));
            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());
            var result = xdoc.Element("GeocodeResponse").Element("result");
            var locationElement = result.Element("geometry").Element("location");
            var lat1 = locationElement.Element("lat");
            var lng1 = locationElement.Element("lng");

            string lat11 = lat1.ToString().Substring(5, 15);
            lat11 = lat11.Substring(0, 10);
            lat11 = lat11.Replace(".", ",");
            string lng11 = lng1.ToString().Substring(5, 15);
            lng11 = lng11.Substring(0, 9);
            lng11 = lng11.Replace(".", ",");

            double lat111 = double.Parse(lat11);
            double lng111 = double.Parse(lng11);

            double distance = 42000.0;
            string lat22 = "";
            string lng22 = "";
            double lat222 = 0.0;
            double lng222 = 0.0;
            Prestataire pres = new Prestataire();

            ////Prestataire p1 = db.Prestataires.Find(1);
            foreach (Prestataire p1 in db.Prestataires)
            {
                using (var context = new Db())
                {
                    CoordonneeP c1 = context.CoordonneePs.Find(p1.Id);
                    var address2 = c1.Rue + " " + c1.Ville; // "123 something st, somewhere";
                    var requestUri2 = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address2));
                    var request2 = WebRequest.Create(requestUri2);
                    var response2 = request2.GetResponse();
                    var xdoc2 = XDocument.Load(response2.GetResponseStream());
                    var result2 = xdoc2.Element("GeocodeResponse").Element("result");
                    var locationElement2 = result2.Element("geometry").Element("location");
                    var lat2 = locationElement2.Element("lat");
                    var lng2 = locationElement2.Element("lng");
                    lat22 = lat2.ToString().Substring(5, 15);
                    lat22 = lat22.Substring(0, 10);
                    lat22 = lat22.Replace(".", ",");
                    lng22 = lng2.ToString().Substring(5, 15);
                    lng22 = lng22.Substring(0, 9);
                    lng22 = lng22.Replace(".", ",");
                    lat222 = double.Parse(lat22);
                    lng222 = double.Parse(lng22);

                    if (GetDistanceBetween(lat111, lng111, lat222, lng222) < distance)
                    {
                        distance = GetDistanceBetween(lat111, lng111, lat222, lng222);
                        pres = p1;
                    }
                }
            }

            //return "";
            return pres;
        }


        // FAIT
        // GET: api/PrestatairesLibre
        [Route("api/PrestatairesLibres")]
        public IQueryable<Prestataire> GetPrestatairesLibres()
        {
            return db.Prestataires.Where(a => a.Disponibilite == Dispo.Dispo);
        }

        // GET: api/Prestataires1
        public IQueryable<Prestataire> GetPrestataires()
        {
            IQueryable<Prestataire> retour = db.Prestataires;
            foreach(Prestataire p in retour)
            {
                using (var db = new Db())
                {
                    p.Coordonnee = db.CoordonneePs.Find(p.IdCoordonnee);
                    p.Voiture = db.Voitures.Find(p.IdVoiture);
                }
            }
            return retour;
        }
        
        [Route("api/coordonnePs")]
        public IQueryable<CoordonneeP> GetCoordonneePs()
        {
            return db.CoordonneePs;
        }
        
        // GET: api/Prestataires1/5
        [ResponseType(typeof(Prestataire))]
        public IHttpActionResult GetPrestataire(int id)
        {
            Prestataire prestataire = db.Prestataires.Find(id);
            if (prestataire == null)
            {
                return NotFound();
            }
            using (var db = new Db())
            {
                prestataire.Coordonnee = db.CoordonneePs.Find(prestataire.IdCoordonnee);
                prestataire.Voiture = db.Voitures.Find(prestataire.IdVoiture);
            }
            return Ok(prestataire);
        }

        // PUT: api/Prestataires1/5
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

        // POST: api/Prestataires1
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

        // DELETE: api/Prestataires1/5
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

        // FAIT 
        // PUT: api/Prestataires1/id
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("api/RepriseService/{idpresta}")]
        public IHttpActionResult PrestataireRepriseService(int idpresta)
        {
            Prestataire p = db.Prestataires.Find(idpresta);
            p.Disponibilite = Dispo.Dispo;
            //db.Entry(prestataire).State = EntityState.Modified;
            db.SaveChanges();  
            return StatusCode(HttpStatusCode.NoContent);
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