using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RPGVideoGameLibrary.Models
{
    public partial class OnlineRPGContext : DbContext
    {
        public OnlineRPGContext()
        {
        }

        public OnlineRPGContext(DbContextOptions<OnlineRPGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<CharacterSkill> CharacterSkills { get; set; }
        public virtual DbSet<CharactersPassive> CharactersPassives { get; set; }
        public virtual DbSet<CharactersSkill> CharactersSkills { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentType> EquipmentTypes { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<InventoryEquipment> InventoryEquipments { get; set; }
        public virtual DbSet<InventoryItem> InventoryItems { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Passive> Passives { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OnlineRPG;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Character>(entity =>
            {
                entity.Property(e => e.CharacterId).HasColumnName("Character_Id");

                entity.Property(e => e.CharacterName)
                    .IsRequired()
                    .HasMaxLength(18)
                    .HasColumnName("Character_Name");

                entity.Property(e => e.Hp).HasColumnName("HP");

                entity.Property(e => e.LeftHand).HasColumnName("Left_Hand");

                entity.Property(e => e.RightHand).HasColumnName("Right_Hand");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.HasOne(d => d.ChestNavigation)
                    .WithMany(p => p.CharacterChestNavigations)
                    .HasForeignKey(d => d.Chest)
                    .HasConstraintName("FK__Character__Chest__34C8D9D1");

                entity.HasOne(d => d.FeetNavigation)
                    .WithMany(p => p.CharacterFeetNavigations)
                    .HasForeignKey(d => d.Feet)
                    .HasConstraintName("FK__Characters__Feet__37A5467C");

                entity.HasOne(d => d.HandsNavigation)
                    .WithMany(p => p.CharacterHandsNavigations)
                    .HasForeignKey(d => d.Hands)
                    .HasConstraintName("FK__Character__Hands__35BCFE0A");

                entity.HasOne(d => d.HeadNavigation)
                    .WithMany(p => p.CharacterHeadNavigations)
                    .HasForeignKey(d => d.Head)
                    .HasConstraintName("FK__Characters__Head__33D4B598");

                entity.HasOne(d => d.LeftHandNavigation)
                    .WithMany(p => p.CharacterLeftHandNavigations)
                    .HasForeignKey(d => d.LeftHand)
                    .HasConstraintName("FK__Character__Left___38996AB5");

                entity.HasOne(d => d.LegsNavigation)
                    .WithMany(p => p.CharacterLegsNavigations)
                    .HasForeignKey(d => d.Legs)
                    .HasConstraintName("FK__Characters__Legs__36B12243");

                entity.HasOne(d => d.RightHandNavigation)
                    .WithMany(p => p.CharacterRightHandNavigations)
                    .HasForeignKey(d => d.RightHand)
                    .HasConstraintName("FK__Character__Right__398D8EEE");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Characters__UID__32E0915F");
            });

            modelBuilder.Entity<CharacterSkill>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CharacterSkills");

                entity.Property(e => e.CharacterId).HasColumnName("Character_Id");

                entity.Property(e => e.CharacterName)
                    .IsRequired()
                    .HasMaxLength(18)
                    .HasColumnName("Character_Name");

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("Skill_Name");
            });

            modelBuilder.Entity<CharactersPassive>(entity =>
            {
                entity.HasKey(e => new { e.CharacterId, e.PassiveName })
                    .HasName("PK__Characte__938C7154635F4204");

                entity.ToTable("Characters_Passives");

                entity.Property(e => e.CharacterId).HasColumnName("Character_Id");

                entity.Property(e => e.PassiveName)
                    .HasMaxLength(30)
                    .HasColumnName("Passive_Name");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharactersPassives)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Character__Chara__46E78A0C");

                entity.HasOne(d => d.PassiveNameNavigation)
                    .WithMany(p => p.CharactersPassives)
                    .HasForeignKey(d => d.PassiveName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Character__Passi__47DBAE45");
            });

            modelBuilder.Entity<CharactersSkill>(entity =>
            {
                entity.HasKey(e => new { e.CharacterId, e.SkillName })
                    .HasName("PK__Characte__077172C782DA1B17");

                entity.ToTable("Characters_Skills");

                entity.Property(e => e.CharacterId).HasColumnName("Character_Id");

                entity.Property(e => e.SkillName)
                    .HasMaxLength(30)
                    .HasColumnName("Skill_Name");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharactersSkills)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Character__Chara__4AB81AF0");

                entity.HasOne(d => d.SkillNameNavigation)
                    .WithMany(p => p.CharactersSkills)
                    .HasForeignKey(d => d.SkillName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Character__Skill__4BAC3F29");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.HasIndex(e => e.EquipmentType, "IX_Equipment_Type");

                entity.Property(e => e.EquipmentId).HasColumnName("Equipment_Id");

                entity.Property(e => e.Atk).HasDefaultValueSql("((0))");

                entity.Property(e => e.Def).HasDefaultValueSql("((0))");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Hp)
                    .HasColumnName("HP")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.EquipmentTypeNavigation)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.EquipmentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipment__Equip__300424B4");
            });

            modelBuilder.Entity<EquipmentType>(entity =>
            {
                entity.ToTable("EquipmentType");

                entity.Property(e => e.EquipmentTypeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EquipmentType_Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.InventoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("Inventory_Id");

                entity.Property(e => e.MaximumSpace).HasColumnName("Maximum_Space");

                entity.Property(e => e.OccupiedSpace).HasColumnName("Occupied_Space");

                entity.HasOne(d => d.InventoryNavigation)
                    .WithOne(p => p.Inventory)
                    .HasForeignKey<Inventory>(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Inven__3C69FB99");
            });

            modelBuilder.Entity<InventoryEquipment>(entity =>
            {
                entity.HasKey(e => new { e.InventoryId, e.EquipmentId })
                    .HasName("PK__Inventor__676AF355F12C51CB");

                entity.ToTable("Inventory_Equipment");

                entity.Property(e => e.InventoryId).HasColumnName("Inventory_Id");

                entity.Property(e => e.EquipmentId).HasColumnName("Equipment_Id");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.InventoryEquipments)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Equip__440B1D61");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.InventoryEquipments)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Inven__4316F928");
            });

            modelBuilder.Entity<InventoryItem>(entity =>
            {
                entity.HasKey(e => new { e.InventoryId, e.ItemName })
                    .HasName("PK__Inventor__03F90BB581D6AAF5");

                entity.ToTable("Inventory_Items");

                entity.Property(e => e.InventoryId).HasColumnName("Inventory_Id");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(30)
                    .HasColumnName("Item_Name");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.InventoryItems)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Inven__3F466844");

                entity.HasOne(d => d.ItemNameNavigation)
                    .WithMany(p => p.InventoryItems)
                    .HasForeignKey(d => d.ItemName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Item___403A8C7D");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ItemName)
                    .HasName("PK__Items__89CFF9E34090D1E0");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(30)
                    .HasColumnName("Item_Name");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Passive>(entity =>
            {
                entity.HasKey(e => e.PassiveName)
                    .HasName("PK__Passives__CED0D26D7F889660");

                entity.Property(e => e.PassiveName)
                    .HasMaxLength(30)
                    .HasColumnName("Passive_Name");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__Profiles__C5B196026CD8FE51");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(14);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasKey(e => e.SkillName)
                    .HasName("PK__Skills__8100EB5448F3F745");

                entity.Property(e => e.SkillName)
                    .HasMaxLength(30)
                    .HasColumnName("Skill_Name");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
