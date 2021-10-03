using Microsoft.EntityFrameworkCore;
using PhinanceManager_REST.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhinanceManager_REST.PhinanceManagerContext
{
    public partial class PhinanceManagerDbContext : DbContext
    {
        public PhinanceManagerDbContext()
        {
        }

        public PhinanceManagerDbContext(DbContextOptions<PhinanceManagerDbContext> options): base(options)
        {
        }

        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<IncomeCategory> IncomeCategory { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentCategory> PaymentCategory { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Reciepent> Reciepent { get; set; }
        public virtual DbSet<Sender> Sender { get; set; }

        protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
