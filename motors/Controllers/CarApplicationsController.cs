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
    public class CarApplicationsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CarApplications
        public IQueryable<CarApplication> GetApplications()
        {
            return db.Applications;
        }

        // GET: api/CarApplications/5
        [ResponseType(typeof(CarApplication))]
        public async Task<IHttpActionResult> GetCarApplication(int id)
        {
            CarApplication carApplication = await db.Applications.FindAsync(id);
            if (carApplication == null)
            {
                return NotFound();
            }

            return Ok(carApplication);
        }

        // PUT: api/CarApplications/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCarApplication(int id, CarApplication carApplication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carApplication.Id)
            {
                return BadRequest();
            }

            db.Entry(carApplication).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarApplicationExists(id))
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

        // POST: api/CarApplications
        [ResponseType(typeof(CarApplication))]
        public async Task<IHttpActionResult> PostCarApplication(CarApplication carApplication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Applications.Add(carApplication);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = carApplication.Id }, carApplication);
        }

        // DELETE: api/CarApplications/5
        [ResponseType(typeof(CarApplication))]
        public async Task<IHttpActionResult> DeleteCarApplication(int id)
        {
            CarApplication carApplication = await db.Applications.FindAsync(id);
            if (carApplication == null)
            {
                return NotFound();
            }

            db.Applications.Remove(carApplication);
            await db.SaveChangesAsync();

            return Ok(carApplication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarApplicationExists(int id)
        {
            return db.Applications.Count(e => e.Id == id) > 0;
        }
    }
}