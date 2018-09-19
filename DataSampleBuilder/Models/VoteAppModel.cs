namespace DataSampleBuilder
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VoteAppModel : DbContext
    {
        public VoteAppModel()
            : base("name=VoteAppDB")
        {
        }

        public virtual DbSet<CE> CEs { get; set; }
        public virtual DbSet<Partido> Partidos { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<VoteTable> VoteTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CE>()
                .HasMany(e => e.VoteTables)
                .WithRequired(e => e.CE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Sectors)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sector>()
                .HasMany(e => e.CEs)
                .WithRequired(e => e.Sector)
                .WillCascadeOnDelete(false);
        }
    }
}
