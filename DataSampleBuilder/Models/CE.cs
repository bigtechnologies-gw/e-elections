namespace DataSampleBuilder
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CE()
        {
            VoteTables = new HashSet<VoteTable>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int sectorId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VoteTable> VoteTables { get; set; }

        public virtual Sector Sector { get; set; }
    }
}
