//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OKO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dep
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dep()
        {
            this.Human = new HashSet<Human>();
        }

        public override string ToString()
        {
            return NameDep;
        }
        public int id { get; set; }
        public string NameDep { get; set; }
        public string Obl { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Human> Human { get; set; }
    }
}
