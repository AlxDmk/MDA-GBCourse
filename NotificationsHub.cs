using SeatBooking.Entities;

namespace SeatBooking;

public class NotificationsHub
{
    private readonly IMessageDelivery _messageDelivery;

    public NotificationsHub(IMessageDelivery messageDelivery)
    {
        _messageDelivery = messageDelivery;
    }

    public void Booking()
    {
        Task.Run(async () =>
        {
            await Task.Delay(5000);
            _messageDelivery.Send();
        });

    }
}