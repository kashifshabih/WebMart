using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMart.Models
{
    //private int MyProperty { get; set; }
    public class AdminUser
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminAddress { get; set; }
        public string AspId { get; set; }
        //http://www.aspsnippets.com/Articles/Encrypt-and-Decrypt-Username-or-Password-stored-in-database-in-ASPNet-using-C-and-VBNet.aspx
        //public string password { get { return password; } set { password = System.Security.Policy.Hash.CreateSHA256(Convert.ToByte( value)); } }
        //public virtual . //AspNetUser AspNetUser { get; set; }
    }
}