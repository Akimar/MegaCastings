
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace MegaCastings.DBLib
{

using System;
    using System.Collections.Generic;
    
public partial class Profession
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Profession()
    {

        this.CastingOffers = new HashSet<CastingOffer>();

    }


    public short Id { get; set; }

    public string Name { get; set; }

    public short ProfessionFieldId { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<CastingOffer> CastingOffers { get; set; }

    public virtual ProfessionField ProfessionField { get; set; }

}

}