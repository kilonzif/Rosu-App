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

    public partial class clubHead
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clubHead()
        {
            this.Clubs = new HashSet<Club>();
        }

        public int clubheadID { get; set; }
        [Display(Name = "StudentID")]
        public int studentID { get; set; }
        [Display(Name ="Salary")]
        public Nullable<decimal> salaryAllowance { get; set; }
        [Display(Name = "Department Partner")]
        public string departmentPartner { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Club> Clubs { get; set; }
        public virtual studentLeader studentLeader { get; set; }
    }
}
