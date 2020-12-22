namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slide")]
    public partial class Slide
    {
        public int id { get; set; }

        [StringLength(100)]
        public string image { get; set; }

        [StringLength(100)]
        public string link { get; set; }

        public DateTime? createday { get; set; }

        public bool? status { get; set; }
    }
}
