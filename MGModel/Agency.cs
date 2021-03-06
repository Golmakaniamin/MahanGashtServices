//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MGModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Agency
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Agency()
        {
            this.AgencyBills = new HashSet<AgencyBill>();
        }
    
        public int AgencyId { get; set; }
        public int ServiceTypeId { get; set; }
        public int Code { get; set; }
        public string CooperativeCode { get; set; }
        public string Name { get; set; }
        public string Phones { get; set; }
        public string Mobile { get; set; }
        public string Manager { get; set; }
        public string RegionCodes { get; set; }
        public string Address { get; set; }
        public string Vehicles { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> MaxCallDuration { get; set; }
        public Nullable<int> MaxCallTimes { get; set; }
        public string VirtualPhone { get; set; }
        public string SMSNumber { get; set; }
        public string PostalCode { get; set; }
        public string sCode { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AgencyBill> AgencyBills { get; set; }
    }
}
