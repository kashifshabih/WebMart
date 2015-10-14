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
using CreditCardService.Models;
using System.Security.Cryptography;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace CreditCardService.Controllers
{
    public class CreditCardController : ApiController
    {
        private CreditCardServiceContext db = new CreditCardServiceContext();

        // GET: api/CreditCard
        public IQueryable<CreditCard> GetCreditCards()
        {
            return db.CreditCards;
        }

        // GET: api/CreditCard/5
        [ResponseType(typeof(CreditCard))]
        public async Task<IHttpActionResult> GetCreditCard(int id)
        {
            CreditCard creditCard = await db.CreditCards.FindAsync(id);
            if (creditCard == null)
            {
                return NotFound();
            }

            return Ok(creditCard);
        }

        // PUT: api/CreditCard/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCreditCard(int id, CreditCard creditCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != creditCard.Id)
            {
                return BadRequest();
            }

            db.Entry(creditCard).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditCardExists(id))
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

        // POST: api/CreditCard
        [ResponseType(typeof(CreditCard))]
        public bool PostCreditCard(CreditCard creditCard)
        {
            //if (!ModelState.IsValid)
            //{
                //return BadRequest(ModelState);
            //}                                 

            bool IsValid = db.CreditCards.Count(e => GetCrypt(e.CreditCardNumber) == creditCard.CreditCardNumber && GetCrypt(e.CreditCardPin) == creditCard.CreditCardPin) > 0;
            
            if (IsValid)
            {
                //Update database

                //send back yes
            }
            else
            { 
                //send back false
            }

            return IsValid;

            //db.CreditCards.Add(creditCard);
            //await db.SaveChangesAsync();

            //return CreatedAtRoute("DefaultApi", new { id = creditCard.Id }, creditCard);
        }

        // DELETE: api/CreditCard/5
        [ResponseType(typeof(CreditCard))]
        public async Task<IHttpActionResult> DeleteCreditCard(int id)
        {
            CreditCard creditCard = await db.CreditCards.FindAsync(id);
            if (creditCard == null)
            {
                return NotFound();
            }

            db.CreditCards.Remove(creditCard);
            await db.SaveChangesAsync();

            return Ok(creditCard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }        
        
        private bool CreditCardExists(int id)
        {
            return db.CreditCards.Count(e => e.Id == id) > 0;
        }

        public static string GetCrypt(string text)
        {
            return text;
            /*string hash = "";
            MD5 alg = MD5.Create();
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(text);            
            byte[] result = alg.ComputeHash(toEncryptArray); 
            hash = Encoding.UTF8.GetString(result);            
            return hash;*/
        }
    }
}