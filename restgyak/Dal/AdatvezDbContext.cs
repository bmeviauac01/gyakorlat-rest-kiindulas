using Microsoft.EntityFrameworkCore;

namespace restgyak.Dal
{
    public partial class AdatvezDbContext : DbContext
    {
        public AdatvezDbContext()
        {
        }

        public AdatvezDbContext(DbContextOptions<AdatvezDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Afa> Afa { get; set; }
        public virtual DbSet<FizetesMod> FizetesMod { get; set; }
        public virtual DbSet<Kategoria> Kategoria { get; set; }
        public virtual DbSet<Megrendeles> Megrendeles { get; set; }
        public virtual DbSet<MegrendelesTetel> MegrendelesTetel { get; set; }
        public virtual DbSet<Statusz> Statusz { get; set; }
        public virtual DbSet<Szamla> Szamla { get; set; }
        public virtual DbSet<SzamlaKiallito> SzamlaKiallito { get; set; }
        public virtual DbSet<SzamlaTetel> SzamlaTetel { get; set; }
        public virtual DbSet<Telephely> Telephely { get; set; }
        public virtual DbSet<Termek> Termek { get; set; }
        public virtual DbSet<Vevo> Vevo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO connectionstring
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=adatvez;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Afa>(entity =>
            {
                entity.ToTable("AFA");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<FizetesMod>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Mod).HasMaxLength(20);
            });

            modelBuilder.Entity<Kategoria>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nev).HasMaxLength(50);

                entity.HasOne(d => d.SzuloKategoriaNavigation)
                    .WithMany(p => p.InverseSzuloKategoriaNavigation)
                    .HasForeignKey(d => d.SzuloKategoria)
                    .HasConstraintName("FK__Kategoria__Szulo__29572725");
            });

            modelBuilder.Entity<Megrendeles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.FizetesModId).HasColumnName("FizetesModID");

                entity.Property(e => e.Hatarido).HasColumnType("datetime");

                entity.Property(e => e.StatuszId).HasColumnName("StatuszID");

                entity.Property(e => e.TelephelyId).HasColumnName("TelephelyID");

                entity.HasOne(d => d.FizetesMod)
                    .WithMany(p => p.Megrendeles)
                    .HasForeignKey(d => d.FizetesModId)
                    .HasConstraintName("FK__Megrendel__Fizet__37A5467C");

                entity.HasOne(d => d.Statusz)
                    .WithMany(p => p.Megrendeles)
                    .HasForeignKey(d => d.StatuszId)
                    .HasConstraintName("FK__Megrendel__Statu__36B12243");

                entity.HasOne(d => d.Telephely)
                    .WithMany(p => p.Megrendeles)
                    .HasForeignKey(d => d.TelephelyId)
                    .HasConstraintName("FK__Megrendel__Telep__35BCFE0A");
            });

            modelBuilder.Entity<MegrendelesTetel>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MegrendelesId).HasColumnName("MegrendelesID");

                entity.Property(e => e.StatuszId).HasColumnName("StatuszID");

                entity.Property(e => e.TermekId).HasColumnName("TermekID");

                entity.HasOne(d => d.Megrendeles)
                    .WithMany(p => p.MegrendelesTetel)
                    .HasForeignKey(d => d.MegrendelesId)
                    .HasConstraintName("FK__Megrendel__Megre__3A81B327");

                entity.HasOne(d => d.Statusz)
                    .WithMany(p => p.MegrendelesTetel)
                    .HasForeignKey(d => d.StatuszId)
                    .HasConstraintName("FK__Megrendel__Statu__3C69FB99");

                entity.HasOne(d => d.Termek)
                    .WithMany(p => p.MegrendelesTetel)
                    .HasForeignKey(d => d.TermekId)
                    .HasConstraintName("FK__Megrendel__Terme__3B75D760");
            });

            modelBuilder.Entity<Statusz>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nev).HasMaxLength(20);
            });

            modelBuilder.Entity<Szamla>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FizetesiHatarido).HasColumnType("datetime");

                entity.Property(e => e.FizetesiMod).HasMaxLength(20);

                entity.Property(e => e.KiallitasDatum).HasColumnType("datetime");

                entity.Property(e => e.KiallitoId).HasColumnName("KiallitoID");

                entity.Property(e => e.MegrendelesId).HasColumnName("MegrendelesID");

                entity.Property(e => e.MegrendeloIr)
                    .HasColumnName("MegrendeloIR")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.MegrendeloNev).HasMaxLength(50);

                entity.Property(e => e.MegrendeloUtca).HasMaxLength(50);

                entity.Property(e => e.MegrendeloVaros).HasMaxLength(50);

                entity.Property(e => e.TeljesitesDatum).HasColumnType("datetime");

                entity.HasOne(d => d.Kiallito)
                    .WithMany(p => p.Szamla)
                    .HasForeignKey(d => d.KiallitoId)
                    .HasConstraintName("FK__Szamla__Kiallito__412EB0B6");

                entity.HasOne(d => d.Megrendeles)
                    .WithMany(p => p.Szamla)
                    .HasForeignKey(d => d.MegrendelesId)
                    .HasConstraintName("FK__Szamla__Megrende__4222D4EF");
            });

            modelBuilder.Entity<SzamlaKiallito>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Adoszam)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ir)
                    .HasColumnName("IR")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Nev).HasMaxLength(50);

                entity.Property(e => e.Szamlaszam)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Utca).HasMaxLength(50);

                entity.Property(e => e.Varos).HasMaxLength(50);
            });

            modelBuilder.Entity<SzamlaTetel>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Afakulcs).HasColumnName("AFAKulcs");

                entity.Property(e => e.MegrendelesTetelId).HasColumnName("MegrendelesTetelID");

                entity.Property(e => e.Nev).HasMaxLength(50);

                entity.Property(e => e.SzamlaId).HasColumnName("SzamlaID");

                entity.HasOne(d => d.MegrendelesTetel)
                    .WithMany(p => p.SzamlaTetel)
                    .HasForeignKey(d => d.MegrendelesTetelId)
                    .HasConstraintName("FK__SzamlaTet__Megre__45F365D3");

                entity.HasOne(d => d.Szamla)
                    .WithMany(p => p.SzamlaTetel)
                    .HasForeignKey(d => d.SzamlaId)
                    .HasConstraintName("FK__SzamlaTet__Szaml__44FF419A");
            });

            modelBuilder.Entity<Telephely>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Fax)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Ir)
                    .HasColumnName("IR")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Utca).HasMaxLength(50);

                entity.Property(e => e.Varos).HasMaxLength(50);

                entity.Property(e => e.VevoId).HasColumnName("VevoID");

                entity.HasOne(d => d.Vevo)
                    .WithMany(p => p.Telephely)
                    .HasForeignKey(d => d.VevoId)
                    .HasConstraintName("FK__Telephely__VevoI__31EC6D26");
            });

            modelBuilder.Entity<Termek>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Afaid).HasColumnName("AFAID");

                entity.Property(e => e.KategoriaId).HasColumnName("KategoriaID");

                entity.Property(e => e.Kep).HasColumnType("image");

                entity.Property(e => e.Leiras).HasColumnType("xml");

                entity.Property(e => e.Nev).HasMaxLength(50);

                entity.HasOne(d => d.Afa)
                    .WithMany(p => p.Termek)
                    .HasForeignKey(d => d.Afaid)
                    .HasConstraintName("FK__Termek__AFAID__2C3393D0");

                entity.HasOne(d => d.Kategoria)
                    .WithMany(p => p.Termek)
                    .HasForeignKey(d => d.KategoriaId)
                    .HasConstraintName("FK__Termek__Kategori__2D27B809");
            });

            modelBuilder.Entity<Vevo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Jelszo).HasMaxLength(50);

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Nev).HasMaxLength(50);

                entity.Property(e => e.Szamlaszam)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vegosszeg).HasColumnName("vegosszeg");

                entity.HasOne(d => d.KozpontiTelephelyNavigation)
                    .WithMany(p => p.VevoNavigation)
                    .HasForeignKey(d => d.KozpontiTelephely)
                    .HasConstraintName("Vevo_KozpontiTelephely");
            });
        }
    }
}
