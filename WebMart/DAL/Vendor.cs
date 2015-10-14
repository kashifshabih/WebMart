//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMart.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vendor
    {
        public Vendor()
        {
            this.VendorUsers = new HashSet<VendorUser>();
        }
    
        public int VendorId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CardCompany { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string SecurityCode { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime LastUpdate { get; set; }
        public string AspId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual ICollection<VendorUser> VendorUsers { get; set; }
    }
}
