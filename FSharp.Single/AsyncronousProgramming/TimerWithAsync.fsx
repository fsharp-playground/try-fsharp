open System

let userTimerWithAsync =
    let timer = new System.Timers.Timer(2000.0)
    let timerEvent = Async.AwaitEvent (timer.Elapsed) |> Async.Ignore

    printfn "Waiting for timer a %O" DateTime.Now.TimeOfDay
    timer.Start()

    printfn "Doing something useful while waiting for event"
    
    Async.RunSynchronously timerEvent

    printfn "Waiting for timer a %O" DateTime.Now.TimeOfDay
