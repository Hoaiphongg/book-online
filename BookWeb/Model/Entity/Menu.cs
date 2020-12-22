namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string link { get; set; }

        public int? displayorder { get; set; }

        public bool? status { get; set; }

        public int? typeid { get; set; }

        public virtual MenuType MenuType { get; set; }
    }
}
