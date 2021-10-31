using Microsoft.EntityFrameworkCore;
using ReservationManager.Application.Contracts;
using ReservationManager.Domain.Entities;
using ReservationManager.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationManager.Infrastructure.Repositories
{
    public class ReservationRepository : RepositoryBase<ReservationEntity>, IReservationRepository
    {
        public ReservationRepository(ReservationsContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<ReservationEntity>> GetReservationsByUserId(string userId)
        {
            var reservationList = await _dbContext.Reservations
                                .Where(o => o.UserId == userId)
                                .ToListAsync();
            return reservationList;
        }
       
    }
}
