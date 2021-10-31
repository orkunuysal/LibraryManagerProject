using Microsoft.EntityFrameworkCore;
using ReservationManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReservationManager.Infrastructure.Context
{
    public interface IReservationsContext
    {
        DbSet<ReservationEntity> Reservations { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
