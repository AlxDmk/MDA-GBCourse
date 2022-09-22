using SeatBooking.Entities;

namespace SeatBooking;

public interface IMessageDelivery
{
    string Message { get; set; }
    void Send();
}