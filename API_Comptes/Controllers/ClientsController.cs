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
    public class ClientsController : ApiController
    {
        private Db db = new Db();

        // GET: api/Clients
        [Authorize(Roles = "Admin, Technicien, Prestataire, Client")]
        public IQueryable<Client> GetClients()
        {
            return db.Clients;
        }

        // GET: api/Clients/5
        [Authorize(Roles = "Admin, Technicien, Prestataire, Client")]
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // GET: api/Clients/email/?email=****@****
        [Authorize(Roles = "Admin, Technicien, Prestataire, Client")]
        [Route("api/clients/email")]
        [ResponseType(typeof(Client))]
        public Client GetClient(string email)
        {            
            IQueryable<Client> clients = db.Clients.Include(c => c.Coordonnee).Where(c => c.Coordonnee.Mail == email);
            if (clients.Count() != 0)
                return clients.First();
            else
                return default(Client);

            //return Ok(client);
        }

        // PUT: api/Clients/5
        [Authorize(Roles = "Admin, Technicien, Client")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.Id)
            {
                return BadRequest();
            }
            
            db.Entry(client).State = EntityState.Modified;
            db.Entry(client.Coordonnee).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [Authorize(Roles = "Admin, Prestataire")]
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.Id }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        [Authorize(Roles = "Admin, Technicien")]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            db.SaveChanges();

            return Ok(client);
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
        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.Id == id) > 0;
        }
    }
}