using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.Hotel.Rooms
{
    public class Room : AuditedAggregateRoot<Guid>
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
