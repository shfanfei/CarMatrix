//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarMatrixData.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BuyYear
    {
        public BuyYear()
        {
            this.Record = new HashSet<Record>();
        }
    
        public int Id { get; set; }
        public System.DateTime Time { get; set; }
    
        public virtual ICollection<Record> Record { get; set; }
    }
}