using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using motors.Models;
using motors.Models.Cars;

namespace motors.Controllers
{
    public class ContactdealersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Contactdealers
        public IQueryable<Contactdealer> GetContactdealer()
        {
            return db.Contactdealer;
        }

        // GET: api/Contactdealers/5
        [ResponseType(typeof(Contactdealer))]
        public async Task<IHttpActionResult> GetContactdealer(int id)
        {
            Contactdealer contactdealer = await db.Contactdealer.FindAsync(id);
            if (contactdealer == null)
            {
                return NotFound();
            }

            return Ok(contactdealer);
        }

        // PUT: api/Contactdealers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContactdealer(int id, Contactdealer contactdealer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactdealer.Id)
            {
                return BadRequest();
            }

            db.Entry(contactdealer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactdealerExists(id))
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

        // POST: api/Contactdealers
        [ResponseType(typeof(Contactdealer))]
        public async Task<IHttpActionResult> PostContactdealer(Contactdealer contactdealer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contactdealer.Add(contactdealer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = contactdealer.Id }, contactdealer);
        }

        // DELETE: api/Contactdealers/5
        [ResponseType(typeof(Contactdealer))]
        public async Task<IHttpActionResult> DeleteContactdealer(int id)
        {
            Contactdealer contactdealer = await db.Contactdealer.FindAsync(id);
            if (contactdealer == null)
            {
                return NotFound();
            }

            db.Contactdealer.Remove(contactdealer);
            await db.SaveChangesAsync();

            return Ok(contactdealer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactdealerExists(int id)
        {
            return db.Contactdealer.Count(e => e.Id == id) > 0;
        }
    }
}