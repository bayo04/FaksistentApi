using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Faksistent.Authorization.Roles;
using Faksistent.Authorization.Users;
using Faksistent.MultiTenancy;
using Faksistent.Semesters;
using Faksistent.Courses;

namespace Faksistent.EntityFrameworkCore
{
    public class FaksistentDbContext : AbpZeroDbContext<Tenant, Role, User, FaksistentDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<UserSemester> UserSemesters { get; set; }
        public DbSet<SemesterCourse> SemesterCourses { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseTemplate> CourseTemplates { get; set; }
        public DbSet<CoursePartition> CoursePartition { get; set; }
        public DbSet<CourseTest> CourseTests { get; set; }
        public DbSet<CourseRestriction> CourseRestrictions { get; set; }
        public DbSet<CourseRestrictionTest> CourseRestrictionTests { get; set; }

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

            base.OnModelCreating(modelBuilder);
        }
    }
}
