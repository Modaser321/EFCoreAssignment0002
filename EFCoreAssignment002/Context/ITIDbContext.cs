using EFCoreAssignment002.Model001;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EFCoreAssignment002.Model001.ITI;

namespace EFCoreAssignment002.Context
{
    public class ITIDbContext : DbContext
    {
        public ITIDbContext()
        {
        }

        public ITIDbContext(DbContextOptions<ITIDbContext> options) : base(options)
        {
        }
        public DbSet<ITI.Student> Students { get; set; }
        public DbSet<ITI.Department> Departments { get; set; }
        public DbSet<ITI.Instructor> Instructors { get; set; }
        public DbSet<ITI.Course> Courses { get; set; }
        public DbSet<ITI.Topic> Topics { get; set; }
        public DbSet<ITI.Stud_Course> StudCourses { get; set; }
        public DbSet<ITI.Course_Inst> CourseInsts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=CoursCenterDbD01; Trusted_Connection=True; TrustServerCertificate=True;");
        }
        public class ITIDbContextFactory : IDesignTimeDbContextFactory<ITIDbContext>
        {
            public ITIDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ITIDbContext>();
                optionsBuilder.UseSqlServer("Server=.;Database=CoursCenterDbD01;Trusted_Connection=True;TrustServerCertificate=True;");
                return new ITIDbContext(optionsBuilder.Options);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stud_Course>()
                .HasKey(sc => new { sc.stud_ID, sc.Course_ID });

            modelBuilder.Entity<Course_Inst>()
                .HasKey(ci => new { ci.inst_ID, ci.Course_ID });

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.Dep_Id);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.Dept_ID);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Topic)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.Top_ID);
        }
    }
}
