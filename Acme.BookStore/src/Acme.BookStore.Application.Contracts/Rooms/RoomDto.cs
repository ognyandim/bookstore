using System;
using Volo.Abp.Application.Dtos;

namespace Acme.Hotel.Rooms
{
    public class RoomDto : AuditedEntityDto<Guid>
    {
        public required string Number { get; set; }
        public required string Type { get; set; }
        public bool IsAvailable { get; set; }
    }
}
