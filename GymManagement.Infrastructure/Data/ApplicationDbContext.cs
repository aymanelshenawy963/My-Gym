using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using GymManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // الـ DbSets السبعة بتوعنا
        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<MembershipPlan> MembershipPlans { get; set; }
        public DbSet<MemberSubscription> MemberSubscriptions { get; set; }
        public DbSet<GymClass> GymClasses { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ClassEnrollment> ClassEnrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
