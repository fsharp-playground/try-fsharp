using System.Threading.Tasks;
using System.Threading;

class Main {
    public static async void ThrowExceptionAsync() {
        throw new InvalidOperationException();
    }

    public static void CallThrowExceptionAsync() {
        try {
            ThrowExceptionAsync();
        } catch(Exception ex) {
            Console.WriteLine("Failed");
        }
    }
}

Main.CallThrowExceptionAsync();