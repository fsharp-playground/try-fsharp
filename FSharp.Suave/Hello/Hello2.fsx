#r "../../packages/Suave/lib/net40/Suave.dll"

open Suave
open System.Threading
open System

let cts = new CancellationTokenSource()

let conf = { defaultConfig with cancellationToken = cts.Token }

let listeing, server = startWebServerAsync conf (Successful.OK "Hello world")
Async.Start(server, cts.Token)
printfn "Make request now"

Console.ReadKey true |> ignore
cts.Cancel()




