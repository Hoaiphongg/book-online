namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int id { get; set; }

        public int? idCustomer { get; set; }

        public int? idDiscount { get; set; }

        public double sale { get; set; }

        public DateTime checkin { get; set; }

        [StringLength(100)]
        public string shipaddress { get; set; }

        [StringLength(50)]
        public string shipMobile { get; set; }

        [StringLength(100)]
        public string shipname { get; set; }

        [StringLength(50)]
        public string shipemail { get; set; }

        public virtual Account Account { get; set; }

        public virtual Discount Discount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
