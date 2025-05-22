using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.Hotel.Rooms
{
    public interface IRoomAppService : ICrudAppService<
        RoomDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateRoomDto>
    {
        // Command: Add Room
        // Command: Room Availability (projection)
    }
}
