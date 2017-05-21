namespace ComputerScienceTsu.Models.Generated
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TsuModel : DbContext
    {
        public TsuModel()
            : base("name=TsuModel")
        {
        }

        public virtual DbSet<CS_Departments> CS_Departments { get; set; }
        public virtual DbSet<Lab> Labs { get; set; }
        public virtual DbSet<Learning_Courses> Learning_Courses { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CS_Departments>()
                .HasMany(e => e.Labs)
                .WithOptional(e => e.CS_Departments)
                .HasForeignKey(e => e.Department_id);

            modelBuilder.Entity<CS_Departments>()
                .HasMany(e => e.Subjects)
                .WithOptional(e => e.CS_Departments)
                .HasForeignKey(e => e.Department_id);

            modelBuilder.Entity<Learning_Courses>()
                .HasMany(e => e.Subjects)
                .WithOptional(e => e.Learning_Courses)
                .HasForeignKey(e => e.Course_id);

            modelBuilder.Entity<Lecturer>()
                .HasMany(e => e.Publications)
                .WithOptional(e => e.Lecturer)
                .HasForeignKey(e => e.Lecturer_id);

            modelBuilder.Entity<Lecturer>()
                .HasMany(e => e.Subjects)
                .WithOptional(e => e.Lecturer)
                .HasForeignKey(e => e.Lecturer_id);

            modelBuilder.Entity<Photo>()
                .HasMany(e => e.Lecturers)
                .WithOptional(e => e.Photo)
                .HasForeignKey(e => e.Photo_id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.News)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.Created_by);
        }
    }
}
