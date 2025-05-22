using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.Hotel.Rooms
{
    public class Booking : AuditedAggregateRoot<Guid>
    {
        public Guid RoomId { get; set; }
        public Guid GuestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public BookingStatus Status { get; set; }
    }

    public enum BookingStatus
    {
        Booked,
        CheckedIn,
        CheckedOut,
        Cancelled
    }
}
