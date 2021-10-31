using ReservationManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationManager.Application.Contracts
{
    public interface IReservationRepository : IAsyncRepository<ReservationEntity>
    {
        Task<IEnumerable<ReservationEntity>> GetReservationsByUserId(string userId);

    }
}
