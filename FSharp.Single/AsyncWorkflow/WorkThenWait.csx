
using System.Threading.Tasks;
using System.Threading;

public class Main {
    public static  async Task WorkThenWait() {
        Thread.Sleep(1000);
        Console.WriteLine("work");
        await Task.Delay(1000);
    }
}

var child = Main.WorkThenWait();
Console.WriteLine("started");
child.Wait();
Console.WriteLine("completed");