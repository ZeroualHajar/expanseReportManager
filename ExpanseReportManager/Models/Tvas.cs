//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpanseReportManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tvas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tvas()
        {
            this.ExpanseTypes = new HashSet<ExpanseTypes>();
        }
    
        public System.Guid TVA_ID { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpanseTypes> ExpanseTypes { get; set; }
    }
}