//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ISAutobuskaStanica.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Linija
    {
        public string NazivLinije { get; set; }
        public int AutobuskiPrevoznikIDAP { get; set; }
    
        public virtual AutobuskiPrevoznik AutobuskiPrevoznik { get; set; }
        public virtual PregledLinija PregledLinija { get; set; }
        public virtual Vozac Vozac { get; set; }
    }
}