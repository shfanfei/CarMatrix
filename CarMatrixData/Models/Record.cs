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
    #pragma warning disable 1573
    using System;
    using System.Collections.Generic;
    
    public partial class Record
    {
        public int Id { get; set; }
        public string Brands { get; set; }
        public string Model { get; set; }
        public string City { get; set; }
        public Nullable<System.DateTime> Time { get; set; }
        public Nullable<System.DateTime> Both { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public Nullable<double> Lat { get; set; }
        public Nullable<double> Lnt { get; set; }
    }
}
