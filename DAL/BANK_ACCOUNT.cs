//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class BANK_ACCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BANK_ACCOUNT()
        {
            this.PARKING = new HashSet<PARKING>();
        }
    
        public short ID { get; set; }
        public short USER_ID { get; set; }
        public string OWNER_NAME { get; set; }
        public string BANK { get; set; }
        public string BRANCH { get; set; }
        public string ACCOUNT_NUMBER { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PARKING> PARKING { get; set; }
        public virtual USERS USERS { get; set; }
    }
}
