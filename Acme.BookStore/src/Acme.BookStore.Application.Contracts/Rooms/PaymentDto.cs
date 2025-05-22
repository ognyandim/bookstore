using System;
using Volo.Abp.Application.Dtos;

namespace Acme.Hotel.Rooms
{
    public class PaymentDto : AuditedEntityDto<Guid>
    {
        public Guid BookingId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }
    }
}
