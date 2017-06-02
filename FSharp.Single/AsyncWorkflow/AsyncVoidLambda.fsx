
open System.Threading.Tasks;

Parallel.For(0L , 10L, fun i -> 
    async { do! Async.Sleep(1000)  }  |> Async.Start
)
