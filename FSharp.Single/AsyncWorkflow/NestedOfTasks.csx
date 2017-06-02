using System.Threading.Tasks;

public class Main {
    public static async Task Start1() {
        Console.WriteLine("Before");
        await Task.Factory.StartNew(
            async () => { 
                await Task.Delay(1000); 
                Console.WriteLine("Done");
            }
        );
        Console.WriteLine("After");
    }

    public static async Task Start2() {
        Console.WriteLine("Before");
        await Task.Run(
            async () => { 
                await Task.Delay(1000); 
                Console.WriteLine("Done");
            }
        );
        Console.WriteLine("After");
    }

    public static async Task Start3() {
        Console.WriteLine("Before");
        await Task.Factory.StartNew();
        Console.WriteLine("After");
    }
}

var k = Main.Start3();
//Consolke.ReadLine();