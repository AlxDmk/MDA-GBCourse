using System.Diagnostics;
using System.Threading.Channels;
using SeatBooking.Entities;
using System.Timers;
using Timer = System.Timers.Timer;


Console.OutputEncoding = System.Text.Encoding.UTF8;

var rest = new Restaurant();

#region TIMER UNSET BOOKING

var timer = new Timer(20000);
timer.Elapsed += UnsetBooking;
timer.AutoReset = true;
timer.Enabled = true;

async void UnsetBooking(object? obj, ElapsedEventArgs e)
{
    await Task.Run(() => rest.UnsetBooking());
}
    
#endregion

while (true)
{
    Console.WriteLine("Привет! Желаете забронировать столик?\n1 - мы уведомим вас по смс (асинхронно)" +
                      "\n2 - подождите на линии, мы Вас оповестим (синхронно)");

    if (!int.TryParse(Console.ReadLine(), out int choice) && choice is not (1 or 2))
    {
        Console.WriteLine("Пожалуйста, введите 1 или 2");
        continue;
    }

    var stopWatch = new Stopwatch();
    
    stopWatch.Start();
    rest.BookFreeTable(1, choice);

    Console.WriteLine("Спасибо за ваше обращение!");
    stopWatch.Stop();

    var ts = stopWatch.Elapsed;

    Console.WriteLine($"{ts.Seconds:00} : {ts.Milliseconds:00}");

}
