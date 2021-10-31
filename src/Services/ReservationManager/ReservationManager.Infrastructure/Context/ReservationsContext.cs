using Microsoft.EntityFrameworkCore;
using ReservationManager.Domain.Common;
using ReservationManager.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationManager.Infrastructure.Context
{
    public class ReservationsContext : DbContext, IReservationsContext
    {
        public ReservationsContext(DbContextOptions<ReservationsContext> options): base(options)
        {
        }
        public DbSet<ReservationEntity> Reservations { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "Reservation Manager";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.ModifiedBy = "Reservation Manager";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
