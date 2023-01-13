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
using ExpenseWeb.Views;

namespace ExpenseWeb.Controllers
{
    public class TotalsController : ApiController
    {
        private Expense_TrackerEntities1 db = new Expense_TrackerEntities1();

        // GET: api/Totals
        public IQueryable<Total> GetTotals()
        {
            return db.Totals;
        }

        // GET: api/Totals/5
        [ResponseType(typeof(Total))]
        public IHttpActionResult GetTotal(int id)
        {
            Total total = db.Totals.Find(id);
            if (total == null)
            {
                return NotFound();
            }

            return Ok(total);
        }

        // PUT: api/Totals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTotal(int id, Total total)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != total.totId)
            {
                return BadRequest();
            }

            db.Entry(total).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TotalExists(id))
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

        // POST: api/Totals
        [ResponseType(typeof(Total))]
        public IHttpActionResult PostTotal(Total total)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Totals.Add(total);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = total.totId }, total);
        }

        // DELETE: api/Totals/5
        [ResponseType(typeof(Total))]
        public IHttpActionResult DeleteTotal(int id)
        {
            Total total = db.Totals.Find(id);
            if (total == null)
            {
                return NotFound();
            }

            db.Totals.Remove(total);
            db.SaveChanges();

            return Ok(total);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TotalExists(int id)
        {
            return db.Totals.Count(e => e.totId == id) > 0;
        }
    }
}