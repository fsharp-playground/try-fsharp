using System.Threading.Tasks;

class Main {
    public static async Task Handler() {
        Console.WriteLine("Before");
        Task.Delay(1000);
        Console.WriteLine("After");
    }
}

Main.Handler();