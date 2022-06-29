using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Faksistent.Authorization.Roles;
using Faksistent.Authorization.Users;
using Faksistent.MultiTenancy;
using Faksistent.Semesters;
using Faksistent.Courses;
using Faksistent.Comments;

namespace Faksistent.EntityFrameworkCore
{
    public class FaksistentDbContext : AbpZeroDbContext<Tenant, Role, User, FaksistentDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<UserSemester> UserSemesters { get; set; }
        public DbSet<SemesterCourse> SemesterCourses { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CourseTemplate> CourseTemplates { get; set; }
        public DbSet<CoursePartition> CoursePartition { get; set; }
        public DbSet<CourseTest> CourseTests { get; set; }
        public DbSet<CourseRestriction> CourseRestrictions { get; set; }
        public DbSet<CourseRestrictionTest> CourseRestrictionTests { get; set; }

        public DbSet<SemesterCoursePartition> SemesterCoursePartitions { get; set; }
        public DbSet<SemesterCourseTest> SemesterCourseTests { get; set; }

        public FaksistentDbContext(DbContextOptions<FaksistentDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseRestriction>()
                .HasOne(c => c.CourseTemplate)
                .WithMany(c => c.CourseRestrictions)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SemesterCoursePartition>()
                .HasOne(c => c.SemesterCourse)
                .WithMany(c => c.SemesterCoursePartitions)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SemesterCourseTest>()
                .HasOne(c => c.SemesterCourse)
                .WithMany(c => c.SemesterCourseTests)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Parent)
                .WithMany(c => c.Children)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
