namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Bills = new HashSet<Bill>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(200)]
        public string password { get; set; }

        [StringLength(20)]
        public string groupid { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public bool gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime birthday { get; set; }

        [Required]
        [StringLength(100)]
        public string address { get; set; }

        [Required]
        [StringLength(15)]
        public string phone { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public bool status { get; set; }

        public virtual AccountGroup AccountGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
