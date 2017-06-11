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
using Saldo.Api.Models;

namespace Saldo.Api.Controllers
{
    public class DayBooksController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/DayBooks
        public IQueryable<DayBook> GetDayBooks()
        {
            return db.DayBooks;
        }

        // GET: api/DayBooks/5
        [ResponseType(typeof(DayBook))]
        public async Task<IHttpActionResult> GetDayBook(int id)
        {
            DayBook dayBook = await db.DayBooks.FindAsync(id);
            if (dayBook == null)
            {
                return NotFound();
            }

            return Ok(dayBook);
        }

        // PUT: api/DayBooks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDayBook(int id, DayBook dayBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dayBook.DayBookID)
            {
                return BadRequest();
            }

            db.Entry(dayBook).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayBookExists(id))
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

        // POST: api/DayBooks
        [ResponseType(typeof(DayBook))]
        public async Task<IHttpActionResult> PostDayBook(DayBook dayBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DayBooks.Add(dayBook);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dayBook.DayBookID }, dayBook);
        }

        // DELETE: api/DayBooks/5
        [ResponseType(typeof(DayBook))]
        public async Task<IHttpActionResult> DeleteDayBook(int id)
        {
            DayBook dayBook = await db.DayBooks.FindAsync(id);
            if (dayBook == null)
            {
                return NotFound();
            }

            db.DayBooks.Remove(dayBook);
            await db.SaveChangesAsync();

            return Ok(dayBook);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DayBookExists(int id)
        {
            return db.DayBooks.Count(e => e.DayBookID == id) > 0;
        }
    }
}