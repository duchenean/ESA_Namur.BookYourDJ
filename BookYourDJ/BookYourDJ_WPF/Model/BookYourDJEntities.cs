namespace BookYourDJ_WPF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using BookYourDJ_WPF.DB.Seeders;
    using System.Data.SqlClient;

    public partial class BookYourDJEntities : DbContext
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private static Boolean Seeded = false;

        public BookYourDJEntities(): base("name=BookYourDJEntities")
        {
            if (Properties.Settings.Default.DropAndSeedDatabase && !Seeded)
            {
                logger.Info("Initializing the DB - DropAndSeedDatabase was selected in Properties.Settings");
                try
                {
                    Database.SetInitializer(new BookYourDJDBInitializer());
                    Database.Initialize(true);
                    Seeded = true;
                    logger.Info("Database Initialized");
                }
                catch (SqlException e)
                {
                    logger.Error("Couldn't intialize the DB - Is there a connection open ?");
                }

            }
        }

        public virtual DbSet<Animator_Skill> Animator_Skill { get; set; }
        public virtual DbSet<AnimatorAvailabilities> AnimatorAvailabilities { get; set; }
        public virtual DbSet<Animators> Animators { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animators>()
                .HasMany(e => e.Animator_Skill)
                .WithRequired(e => e.Animators)
                .HasForeignKey(e => e.AnimatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Animators>()
                .HasMany(e => e.AnimatorAvailabilities)
                .WithRequired(e => e.Animators)
                .HasForeignKey(e => e.AnimatorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Animators>()
                .HasMany(e => e.Regions)
                .WithMany(e => e.Animators)
                .Map(m => m.ToTable("Animator_Region").MapLeftKey("AnimatorId").MapRightKey("regionId"));

            modelBuilder.Entity<Skills>()
                .HasMany(e => e.Animator_Skill)
                .WithRequired(e => e.Skills)
                .HasForeignKey(e => e.SkillId)
                .WillCascadeOnDelete(false);
        }
    }
}
