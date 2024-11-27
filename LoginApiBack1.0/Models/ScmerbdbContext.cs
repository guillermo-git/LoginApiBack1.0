using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LoginApiBack1._0.Models;

public partial class ScmerbdbContext : DbContext
{
    public ScmerbdbContext()
    {
    }

    public ScmerbdbContext(DbContextOptions<ScmerbdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accionistum> Accionista { get; set; }

    public virtual DbSet<Beneficiario> Beneficiarios { get; set; }

    public virtual DbSet<Certificado> Certificados { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<RepreLegal> RepreLegals { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accionistum>(entity =>
        {
            entity.HasKey(e => e.IdAccionista).HasName("PK__Accionis__1D5B9DC8F2415F2E");

            entity.Property(e => e.IdAccionista).HasColumnName("id_accionista");
            entity.Property(e => e.Beneficiarios)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("beneficiarios");
            entity.Property(e => e.Direccion)
                .HasMaxLength(2000)
                .HasColumnName("direccion");
            entity.Property(e => e.NCR)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("n_c_r");
            entity.Property(e => e.Nit)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nit");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");
            entity.Property(e => e.TipoPersona)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("tipo_persona");
        });

        modelBuilder.Entity<Beneficiario>(entity =>
        {
            entity.HasKey(e => e.IdBeneficiario).HasName("PK__Benefici__35B9C95C9AC66ADB");

            entity.Property(e => e.IdBeneficiario).HasColumnName("id_beneficiario");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Dui)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dui");
            entity.Property(e => e.Edad)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("edad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Porcentaje).HasColumnName("porcentaje");
        });

        modelBuilder.Entity<Certificado>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Certificado");

            entity.Property(e => e.FechaApertura)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fecha_apertura");
            entity.Property(e => e.FechaVencimiento)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fecha_vencimiento");
            entity.Property(e => e.FormaPago)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("forma_pago");
            entity.Property(e => e.IdAccionista).HasColumnName("id_accionista");
            entity.Property(e => e.IdBeneficiario).HasColumnName("id_beneficiario");
            entity.Property(e => e.IdCertifcado).HasColumnName("id_certifcado");
            entity.Property(e => e.IdRepreLegal).HasColumnName("id_repre_legal");
            entity.Property(e => e.Monto).HasColumnName("monto");
            entity.Property(e => e.NumCuenta)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("num_cuenta");
            entity.Property(e => e.Plazo).HasColumnName("plazo");
            entity.Property(e => e.TInteres).HasColumnName("t_interes");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("tipo_pago");

            entity.HasOne(d => d.IdAccionistaNavigation).WithMany()
                .HasForeignKey(d => d.IdAccionista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCertificad596738");

            entity.HasOne(d => d.IdBeneficiarioNavigation).WithMany()
                .HasForeignKey(d => d.IdBeneficiario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCertificad581822");

            entity.HasOne(d => d.IdRepreLegalNavigation).WithMany()
                .HasForeignKey(d => d.IdRepreLegal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCertificad286338");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Idmenu).HasName("PK__Menu__753CC850D31967A7");

            entity.ToTable("Menu");

            entity.Property(e => e.Idmenu).HasColumnName("idmenu");
            entity.Property(e => e.Icono)
                .HasMaxLength(255)
                .HasColumnName("icono");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.IdMenuRol).HasName("PK__MenuRol__D467FF5816B8C0D8");

            entity.ToTable("MenuRol");

            entity.Property(e => e.IdMenuRol).HasColumnName("id_menuRol");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdMenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKMenuRol34505");

            entity.HasOne(d => d.IdMenu1).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdMenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKMenuRol992093");
        });

        modelBuilder.Entity<RepreLegal>(entity =>
        {
            entity.HasKey(e => e.Idrepre).HasName("PK__Repre_le__4DDE5B7495254907");

            entity.ToTable("Repre_legal");

            entity.Property(e => e.Idrepre).HasColumnName("idrepre");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Dui)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dui");
            entity.Property(e => e.Edad)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("edad");
            entity.Property(e => e.EstadoFamiliar)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("estado_familiar");
            entity.Property(e => e.Nit)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nit");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Profesion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profesion");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Idrol).HasName("PK__Rol__24C6BB204A376827");

            entity.ToTable("Rol");

            entity.Property(e => e.Idrol).HasColumnName("idrol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaRegistro)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Usuarios__D2D146375B8895F7");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Activo)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("activo");
            entity.Property(e => e.Cargo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cargo");
            entity.Property(e => e.Contra)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contra");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombres)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombres");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKUsuarios43521");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
