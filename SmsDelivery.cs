using SeatBooking.Entities;

namespace SeatBooking;

public class SmsDelivery : IMessageDelivery
{
    public string Message { get; set; }
    private readonly Table? _table;

    public SmsDelivery(Table? table)
    {
        _table = table;
        Message = _table == null
            ? "УВЕДОМЛЕНИЕ: К сожалению, все столики заняты"
            :$"УВЕДОМЛЕНИЕ: Готово! Ваш столик номер {_table.Id}";
    }

    public void Send()
    {
        Console.WriteLine(Message);
    }
}