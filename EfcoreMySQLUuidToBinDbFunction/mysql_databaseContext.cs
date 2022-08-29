using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EfcoreMySQLUuidToBinDbFunction.Tables;

namespace EfcoreMySQLUuidToBinDbFunction
{
    public partial class mysql_databaseContext : DbContext
    {
        public mysql_databaseContext()
        {
        }

        public mysql_databaseContext(DbContextOptions<mysql_databaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<test_table> test_table { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=<your server>;uid=<database user id>;pwd=<database user password>;database=mysql_database", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<test_table>(entity =>
            {
                entity.HasKey(e => e.uuid_to_bin_column)
                    .HasName("PRIMARY");

                entity.Property(e => e.uuid_to_bin_column).IsFixedLength();

                entity.Property(e => e.uuid_column).IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
