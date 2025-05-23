using System;

namespace Acme.Hotel.Rooms.Events
{
    public class RoomAddedEvent
    {
        public Guid RoomId { get; }
        public string Number { get; }
        public string Type { get; }

        public RoomAddedEvent(Guid roomId, string number, string type)
        {
            RoomId = roomId;
            Number = number;
            Type = type;
        }
    }

    public class RoomBookedEvent
    {
        public Guid BookingId { get; }
        public Guid RoomId { get; }
        public Guid GuestId { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public RoomBookedEvent(Guid bookingId, Guid roomId, Guid guestId, DateTime startDate, DateTime endDate)
        {
            BookingId = bookingId;
            RoomId = roomId;
            GuestId = guestId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }

    public class RoomReadiedEvent
    {
        public Guid RoomId { get; }
        public RoomReadiedEvent(Guid roomId) => RoomId = roomId;
    }

    public class CheckedInEvent
    {
        public Guid BookingId { get; }
        public Guid GuestId { get; }
        public CheckedInEvent(Guid bookingId, Guid guestId)
        {
            BookingId = bookingId;
            GuestId = guestId;
        }
    }

    public class CheckedOutEvent
    {
        public Guid BookingId { get; }
        public Guid GuestId { get; }
        public CheckedOutEvent(Guid bookingId, Guid guestId)
        {
            BookingId = bookingId;
            GuestId = guestId;
        }
    }

    public class PaymentRequestedEvent
    {
        public Guid PaymentId { get; }
        public Guid BookingId { get; }
        public decimal Amount { get; }
        public PaymentRequestedEvent(Guid paymentId, Guid bookingId, decimal amount)
        {
            PaymentId = paymentId;
            BookingId = bookingId;
            Amount = amount;
        }
    }

    public class PaymentProcessedEvent
    {
        public Guid PaymentId { get; }
        public Guid BookingId { get; }
        public bool Success { get; }
        public PaymentProcessedEvent(Guid paymentId, Guid bookingId, bool success)
        {
            PaymentId = paymentId;
            BookingId = bookingId;
            Success = success;
        }
    }
}
