using System;

namespace Acme.Hotel.Rooms
{
    public class CreateUpdateRoomDto
    {
        public required string Number { get; set; }
        public required string Type { get; set; }
    }
}
