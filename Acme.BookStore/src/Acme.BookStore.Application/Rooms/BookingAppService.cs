using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Marten;
using Acme.Hotel.Rooms.Events;
using System.Threading.Tasks;

namespace Acme.Hotel.Rooms
{
    public class BookingAppService :
        CrudAppService<
            Booking, BookingDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateBookingDto>,
        IBookingAppService
    {
        private readonly IDocumentSession _documentSession;

        public BookingAppService(IRepository<Booking, Guid> repository, IDocumentSession documentSession)
            : base(repository)
        {
            _documentSession = documentSession;
        }

        public async Task<BookingDto> BookRoomAsync(CreateUpdateBookingDto input)
        {
            var booking = new Booking
            {
                RoomId = input.RoomId,
                GuestId = input.GuestId,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                Status = BookingStatus.Booked
            };
            await Repository.InsertAsync(booking);
            var @event = new RoomBookedEvent(booking.Id, booking.RoomId, booking.GuestId, booking.StartDate, booking.EndDate);
            _documentSession.Events.StartStream(booking.Id, @event);
            await _documentSession.SaveChangesAsync();
            return ObjectMapper.Map<Booking, BookingDto>(booking);
        }
    }
}
