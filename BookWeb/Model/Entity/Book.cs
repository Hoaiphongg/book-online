namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string metatitle { get; set; }

        [Required]
        [StringLength(50)]
        public string author { get; set; }

        public int idCategory { get; set; }

        public double price { get; set; }

        public bool status { get; set; }

        [Required]
        [StringLength(100)]
        public string image { get; set; }

        public virtual Category Category { get; set; }
    }
}
