using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.Hotel.Rooms
{
    public class BookingAppService :
        CrudAppService<
            Booking, BookingDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookingDto>,
        IBookingAppService
    {
        public BookingAppService(IRepository<Booking, Guid> repository)
            : base(repository)
        {
        }
    }
}
