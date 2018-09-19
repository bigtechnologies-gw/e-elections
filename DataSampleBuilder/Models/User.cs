namespace DataSampleBuilder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Password { get; set; }

        public bool Enabled { get; set; }

        public DateTime DateCreation { get; set; }

        public int OwnerId { get; set; }

        public int Type { get; set; }

        public int ProvinceId { get; set; }

        [Required]
        public string Salt { get; set; }
    }
}
