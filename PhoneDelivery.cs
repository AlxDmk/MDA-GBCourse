using SeatBooking.Entities;

namespace SeatBooking;

public class PhoneDelivery:IMessageDelivery
{
    public string Message { get; set; }
    private readonly Table? _table;
    public PhoneDelivery(Table? table)
    {
        _table = table;
        Message = _table == null
            ? "К сожалению, сейчас все столики заняты"
            :$"Готово! Ваш столик номер {_table.Id}";
    }
    
    public void Send()
    {
        Console.WriteLine("Добрый день! Подождите секунду, я подберу столик " +
                          "и подтвержу вашу бронь, оставайтесь на линии");

        Console.WriteLine(Message);
        
    }
}