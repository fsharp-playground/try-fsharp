
open System
open System.IO

let fileWriteWithAsync =
    use stream = new FileStream("test.txt", FileMode.Create)

    printfn "Starting async write"

    let asyncResult = stream.BeginWrite(Array.empty, 0, 0, null, null)
    let async = Async.AwaitIAsyncResult(asyncResult) |> Async.Ignore

    printfn "Doing something useful while waiting for write to complete"

    Async.RunSynchronously async

    printfn "Async write completed"
