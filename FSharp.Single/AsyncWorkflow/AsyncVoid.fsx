
open System

let throwExceptionAsync() = async {
    raise <| InvalidOperationException()
}

let callThrowExceptionAsync() =
    try 
        throwExceptionAsync() |> Async.Start
    with e ->
        printf "Failed"

callThrowExceptionAsync()
Console.ReadLine()

