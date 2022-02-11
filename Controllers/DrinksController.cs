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
using WebApiTorgovyAutomat.Models.DB;

namespace WebApiTorgovyAutomat.Controllers
{
    public class DrinksController : ApiController
    {
        private TorgovyAutomatEntities db = new TorgovyAutomatEntities();

        // GET: api/Drinks
        public IQueryable<Drinks> GetDrinks()
        {
            return db.Drinks;
        }

        // GET: api/Drinks/5
        [ResponseType(typeof(Drinks))]
        public IHttpActionResult GetDrinks(int id)
        {
            Drinks drinks = db.Drinks.Find(id);
            if (drinks == null)
            {
                return NotFound();
            }

            return Ok(drinks);
        }

        // PUT: api/Drinks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDrinks(int id, Drinks drinks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != drinks.id)
            {
                return BadRequest();
            }

            db.Entry(drinks).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrinksExists(id))
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

        // POST: api/Drinks
        [ResponseType(typeof(Drinks))]
        public IHttpActionResult PostDrinks(Drinks drinks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Drinks.Add(drinks);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = drinks.id }, drinks);
        }

        // DELETE: api/Drinks/5
        [ResponseType(typeof(Drinks))]
        public IHttpActionResult DeleteDrinks(int id)
        {
            Drinks drinks = db.Drinks.Find(id);
            if (drinks == null)
            {
                return NotFound();
            }

            db.Drinks.Remove(drinks);
            db.SaveChanges();

            return Ok(drinks);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DrinksExists(int id)
        {
            return db.Drinks.Count(e => e.id == id) > 0;
        }
    }
}