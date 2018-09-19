namespace DataSampleBuilder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Partidos")]
    public partial class Partido
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool Enabled { get; set; }
    }
}
