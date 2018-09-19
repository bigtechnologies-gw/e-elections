namespace DataSampleBuilder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VoteTable
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CEId { get; set; }

        public int TotalRegisted { get; set; }

        public int InvalidVotes { get; set; }

        public virtual CE CE { get; set; }
    }
}
