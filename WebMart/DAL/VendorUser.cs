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
    
    public partial class VendorUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<int> VendorId { get; set; }
        public string AspId { get; set; }
    
        public virtual Vendor Vendor { get; set; }
    }
}
