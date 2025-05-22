using System;
using Volo.Abp.Application.Dtos;

namespace Acme.Hotel.Rooms
{
    public class BookingDto : AuditedEntityDto<Guid>
    {
        public Guid RoomId { get; set; }
        public Guid GuestId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}
