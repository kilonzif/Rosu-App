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
    
    public partial class asset
    {
        [Display(Name ="Asset No.")]
        public int assetNo { get; set; }
        [Display(Name = "Asset Name")]
        public string assetname { get; set; }
        [Display(Name = "Function")]
        public string functionality { get; set; }
        [Display(Name = "Value ($)")]
        public Nullable<decimal> monetaryValue { get; set; }
        [Display(Name = "Asset Manager")]
        public int assetManager { get; set; }
    
        public virtual Executive Executive { get; set; }
    }
}
