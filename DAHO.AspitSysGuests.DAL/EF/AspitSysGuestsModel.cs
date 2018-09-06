namespace DAHO.AspitSysGuests.DAL.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AspitSysGuestsModel : DbContext
    {
        public AspitSysGuestsModel()
            : base("name=AspitSysGuestsModelConnectionString")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<MultiChoice> MultiChoices { get; set; }
        public virtual DbSet<Municipality> Municipalities { get; set; }
        public virtual DbSet<Questionnaire> Questionnaires { get; set; }
        public virtual DbSet<Question> Questions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasMany(e => e.Questionnaires)
                .WithRequired(e => e.Admin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Guest>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Guest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipality>()
                .HasMany(e => e.Departments)
                .WithRequired(e => e.Municipality)
                .HasForeignKey(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Municipality>()
                .HasMany(e => e.Guests)
                .WithRequired(e => e.Municipality)
                .HasForeignKey(e => e.From)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Questionnaire>()
                .HasMany(e => e.Questions)
                .WithRequired(e => e.Questionnaire)
                .HasForeignKey(e => e.QuestionaireId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.Answers)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.MultiChoices)
                .WithRequired(e => e.Question)
                .WillCascadeOnDelete(false);
        }
    }
}
