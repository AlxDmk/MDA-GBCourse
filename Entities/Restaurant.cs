namespace SeatBooking.Entities;

public class Restaurant
{
    private readonly List<Table> _tables = new();
    private NotificationsHub? _notificationsHub;
    
    public Restaurant()
    {
        for (ushort i = 1; i <= 10; i++)
        {
            _tables.Add(new Table(i));
        }
    }

    public void BookFreeTable(int countOfSeats, int choice)
    {

        var table = _tables.FirstOrDefault(t => t.SeatsCount >= countOfSeats && t.State == State.Free);
        table?.SetState(State.Booked);

        _notificationsHub = choice == 2 
                ? new NotificationsHub(new PhoneDelivery(table))
                : new NotificationsHub(new SmsDelivery(table));
        _notificationsHub.Booking();

    }

    public void UnsetBooking(int id) =>
        _tables.FirstOrDefault(t => t.Id == id && t.State == State.Booked)?.SetState(State.Free);
    

    public void UnsetBooking() =>
        _tables.ForEach(t => t.SetState(State.Free));
    

    // public void BookFreeTableAsync(int countSeats)
    // {
    //     var table = _tables.FirstOrDefault(t => t.SeatsCount >= countSeats && t.State == State.Free);
    //     Task.Run(async () =>
    //     {
    //         var table = _tables.FirstOrDefault(t => t.SeatsCount >= countSeats && t.State == State.Free);
    //         
    //         table?.SetState(State.Booked);
    //
    //         _communicator = new SmsCommunicator();
    //         await _communicator.Send(table);
    //
    //     });

}