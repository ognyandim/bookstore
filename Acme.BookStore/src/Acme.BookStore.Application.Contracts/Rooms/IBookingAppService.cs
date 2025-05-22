using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.Hotel.Rooms
{
    public interface IBookingAppService : ICrudAppService<
        BookingDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateBookingDto>
    {
        // Command: Book Room
        // Command: Check In
        // Command: Check Out
    }
}
