using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Marten;
using Acme.Hotel.Rooms.Events;
using Volo.Abp.ObjectMapping;

namespace Acme.Hotel.Rooms
{
    public class RoomAppService :
        CrudAppService<
            Room, RoomDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateRoomDto>,
        IRoomAppService
    {
        private readonly IDocumentSession _documentSession;

        public RoomAppService(IRepository<Room, Guid> repository, IDocumentSession documentSession)
            : base(repository)
        {
            _documentSession = documentSession;
        }

        public async Task<RoomDto> AddRoomAsync(CreateUpdateRoomDto input)
        {
            var room = new Room
            {
                Number = input.Number,
                Type = input.Type,
                IsAvailable = true,
                Bookings = new List<Booking>()
            };
            await Repository.InsertAsync(room);
            var @event = new RoomAddedEvent(room.Id, room.Number, room.Type);
            _documentSession.Events.StartStream(room.Id, @event);
            await _documentSession.SaveChangesAsync();
            return ObjectMapper.Map<Room, RoomDto>(room);
        }
    }
}
