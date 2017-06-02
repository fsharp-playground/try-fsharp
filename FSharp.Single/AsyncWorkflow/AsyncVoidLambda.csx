using System.Threading.Tasks;

class Main {
    public static void Start() {
        Parallel.For(0, 10, async i => {
            Console.WriteLine(i);
            await Task.Delay(1000);
            Console.WriteLine($"Finish {i}");
        });
    }
}

Main.Start();
Console.ReadLine();