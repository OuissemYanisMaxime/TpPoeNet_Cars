using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using Flurl.Http;
using System.Web.Mvc;
using DAO.modeles;
using System.Threading.Tasks;

namespace WebInterface.Controllers
{
    public class VoituresController : Controller
    {
        private Db db = new Db();

        // test du contrôleur userTester de l'api API_Comptes

        [HttpGet]
        [Route("Voitures/UserTest")]
        //[ResponseType(typeof(bool))]        
        public async Task<String> testIsAdmin() // (IOwinContext actualContext)
        {
            string userToken = "EyBr4vLoT7JW7LodkCXg72cqayvKpS66DAu5zfgyciNGTbTKaBf9RBR15vS7vku52hXbX-CxEEYgRsL05acE5x6kb11eizIwBcFAH_8svpGPLaqruqfDxloYMZogqICDEZzoljytOLv4vdbxmW80FQM-7_ijasd-QzbgVoeEJmJJxTJfSJTFjLL6EzbH0HAzFfC_pLe19nnBgJPM1ppooihPub3ZK66jqIMuTdvz5QxkSlj0TGsmJAi-SjjNT1wLI80xJ5mVV_9LXj5YmBb58QYLdzd8pc_TEJnhuW4uHbJ5gjF8YPo_NuLDD9jy73zWm0rKhS9bdrRs9SZD0A0EJ6EqZmFElD1QvxNPlCAQl7IC_-TBR9Z5nMGIoRDqUsGZ1qFUZwmP3IK5prBg81jBJeDlhNcFHLNRRZ--zX1beYLZkBMMXW-2yY3BrSAxSkD-4okXbq6lOqthFQt8sygHO1WIfKqEjDF0RuxX28GjmOmFTi9W8LUOoP9rVX-b5nvDh84j7Ihe5-T7rsm1jv5PSQ"; // Request.Cookies["UserSettings"]["token"];
            bool result = await "http://localhost:50631/api/IsAdmin"
                    .WithOAuthBearerToken(userToken)
                    .WithHeader("Accept", "application/json")
                    .PostAsync(null).ReceiveJson<bool>();

            return result.ToString();            
        }

        [HttpGet]
        [Route("Voitures/UserTest1")]
        //[ResponseType(typeof(bool))]        
        public async Task<String> testIsClient() // (IOwinContext actualContext)
        {
            string userToken = "EyBr4vLoT7JW7LodkCXg72cqayvKpS66DAu5zfgyciNGTbTKaBf9RBR15vS7vku52hXbX-CxEEYgRsL05acE5x6kb11eizIwBcFAH_8svpGPLaqruqfDxloYMZogqICDEZzoljytOLv4vdbxmW80FQM-7_ijasd-QzbgVoeEJmJJxTJfSJTFjLL6EzbH0HAzFfC_pLe19nnBgJPM1ppooihPub3ZK66jqIMuTdvz5QxkSlj0TGsmJAi-SjjNT1wLI80xJ5mVV_9LXj5YmBb58QYLdzd8pc_TEJnhuW4uHbJ5gjF8YPo_NuLDD9jy73zWm0rKhS9bdrRs9SZD0A0EJ6EqZmFElD1QvxNPlCAQl7IC_-TBR9Z5nMGIoRDqUsGZ1qFUZwmP3IK5prBg81jBJeDlhNcFHLNRRZ--zX1beYLZkBMMXW-2yY3BrSAxSkD-4okXbq6lOqthFQt8sygHO1WIfKqEjDF0RuxX28GjmOmFTi9W8LUOoP9rVX-b5nvDh84j7Ihe5-T7rsm1jv5PSQ"; // Request.Cookies["UserSettings"]["token"];
            bool result = await "http://localhost:50631/api/IsCustomer"
                    .WithOAuthBearerToken(userToken)
                    .WithHeader("Accept", "application/json")
                    .PostAsync(null).ReceiveJson<bool>();

            return result.ToString();
        }

        // GET: Voitures
        public ActionResult Index()
        {
            return View(db.Voitures.ToList());
        }

        // GET: Voitures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // GET: Voitures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Voitures/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Marque,modele,Immatriculation,Nb_Place")] Voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.Voitures.Add(voiture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(voiture);
        }

        // GET: Voitures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // POST: Voitures/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Marque,modele,Immatriculation,Nb_Place")] Voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voiture);
        }

        // GET: Voitures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // POST: Voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voiture voiture = db.Voitures.Find(id);
            db.Voitures.Remove(voiture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
