open System

let userTimerWithCallback =
    let event = new System.Threading.AutoResetEvent(false)
    let timer = new System.Timers.Timer(2000.0)
    timer.Elapsed.Add(fun _ -> event.Set() |> ignore)

    printfn "Waiting for timer at %O" DateTime.Now.TimeOfDay
    timer.Start()

    printfn "Doing someting useful while waiting for event"

    event.WaitOne() |> ignore

    printfn "Timer ticked at %O" DateTime.Now.TimeOfDay
