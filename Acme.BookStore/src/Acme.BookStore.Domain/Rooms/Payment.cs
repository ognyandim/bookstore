using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.Hotel.Rooms
{
    public class Payment : AuditedAggregateRoot<Guid>
    {
        public Guid BookingId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; set; }
    }

    public enum PaymentStatus
    {
        Requested,
        Succeeded,
        Failed
    }
}
