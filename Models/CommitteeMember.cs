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
    
    public partial class CommitteeMember
    {
        public int studentID { get; set; }
        [Display(Name = "Member Committee")]
        public int memberCommittee { get; set; }
        [Display(Name = "Class Group")]
        public int class_represented { get; set; }
    
        public virtual Committee Committee { get; set; }
    }
}