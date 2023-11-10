using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend_api_univalle.Models;

public partial class DbUnivalleV5Context : DbContext
{
    public DbUnivalleV5Context()
    {
    }

    public DbUnivalleV5Context(DbContextOptions<DbUnivalleV5Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrera> Carreras { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Facultad> Facultads { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-MAQ800B\\SQLEXPRESS;Initial Catalog=DB_UnivalleV5;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Carrera__3214EC07AD8C16A1");

            entity.ToTable("Carrera");

            entity.Property(e => e.Brochure).HasColumnType("text");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Imagen).HasColumnType("text");
            entity.Property(e => e.PlanDeEstudios).HasColumnType("text");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TituloOtorgado)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Facultad).WithMany(p => p.Carreras)
                .HasForeignKey(d => d.FacultadId)
                .HasConstraintName("FK__Carrera__Faculta__398D8EEE");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departam__3214EC07180F262F");

            entity.ToTable("Departamento");

            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Facultad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Facultad__3214EC07A872A884");

            entity.ToTable("Facultad");

            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Imagen).HasColumnType("text");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ubicacio__3214EC07A293863F");

            entity.ToTable("Ubicacion");

            entity.HasOne(d => d.Carrera).WithMany(p => p.Ubicacions)
                .HasForeignKey(d => d.CarreraId)
                .HasConstraintName("FK__Ubicacion__Carre__3E52440B");

            entity.HasOne(d => d.Departamento).WithMany(p => p.Ubicacions)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("FK__Ubicacion__Depar__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
