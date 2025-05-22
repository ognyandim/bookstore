using System;

namespace Acme.Hotel.Rooms
{
    public class CreateUpdateBookingDto
    {
        public Guid RoomId { get; set; }
        public Guid GuestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
