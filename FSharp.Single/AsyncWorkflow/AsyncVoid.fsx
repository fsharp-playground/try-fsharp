open System
let mainThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId

let throwExceptionAsync() = async {
    printfn "Enter ..."
    raise <| InvalidOperationException()
    printfn "Leave ..."
}

let callThrowExceptionAsync() =
    try 
        throwExceptionAsync() |> Async.Start
    with e ->
        printf "Failed"

callThrowExceptionAsync()
Console.ReadLine()

