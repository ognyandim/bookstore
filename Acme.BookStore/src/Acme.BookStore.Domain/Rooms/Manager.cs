using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.Hotel.Rooms
{
    public class Manager : AuditedAggregateRoot<Guid>
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
