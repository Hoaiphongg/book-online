namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillDetail")]
    public partial class BillDetail
    {
        public int id { get; set; }

        public int idBill { get; set; }

        public int quantity { get; set; }

        public double price { get; set; }

        public virtual Bill Bill { get; set; }
    }
}
