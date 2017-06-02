open System.Threading;
open System.Threading.Tasks;

let workThenWait() =
    Thread.Sleep(1000)
    printfn "work done"
    async { do! Async.Sleep 1000 }

let workThenWait2() = async {
    Thread.Sleep(100)
    printfn "work done"
    do! Async.Sleep 1000
}

let domo1() =
    let work = workThenWait() |> Async.StartAsTask
    printfn "started"
    work.Wait()
    printfn "completed"

let domo2() =
    let work = workThenWait2() |> Async.StartAsTask
    printfn "started"
    work.Wait()
    printfn "completed"

domo2()