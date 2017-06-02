open System

let handler() = async {
    printfn "Before"
    do! Async.Sleep 1000
    printfn "After"
}

handler() |> Async.RunSynchronously