using System;

namespace Acme.Hotel.Rooms
{
    public class CreateUpdatePaymentDto
    {
        public Guid BookingId { get; set; }
        public decimal Amount { get; set; }
    }
}
