//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rosu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

      

        public partial class Club
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Club()
        {
            this.Programs = new HashSet<Program>();
        }
    
        public int clubID { get; set; }
        [Display(Name = "Club Name")]
        public string clubName { get; set; }
        [Display(Name = "Founded Year")]
        public string yearFounded { get; set; }
        [Display(Name = "Leader")]
        public int clubHead { get; set; }
        [Display(Name = "Industry Field")]
        public string industryField { get; set; }
    
        public virtual clubHead clubHead1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Program> Programs { get; set; }
    }
}
