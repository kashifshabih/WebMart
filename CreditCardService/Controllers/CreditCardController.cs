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
using System.Configuration;
using System.Web.Configuration;

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
            
            string decryptedCreditCardNumber = GetDecrypt(creditCard.CreditCardNumber);
            string decryptedCreditCardPin = GetDecrypt(creditCard.CreditCardPin);
            bool IsValid = db.CreditCards.Count(e => (e.CreditCardNumber == decryptedCreditCardNumber) && (e.CreditCardPin == decryptedCreditCardPin)) > 0;
            
            if (IsValid)
            {
                //Update database

                //send back yes
            }
            else
            { 
                //send back false
            }

          //  return IsValid;

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

        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }

        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }

        public static string GetDecrypt(string ciphertext)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~/");
            KeyValueConfigurationElement Appsetting = config.AppSettings.Settings["sequence"];            
            var key = StringToBinary(Appsetting.Value);
            var xor = "";
            for (var i = 0; i < ciphertext.Length; ++i)
                xor += ciphertext[i] ^ key[i % key.Length];                                  
            return BinaryToString(xor);                                           
        }
    }
}