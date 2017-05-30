
let childTask() =
    for i in [1..100] do
        for i in [1..1000] do
            do "Hello".Contains("H") |> ignore


#time
childTask()
#time

let parentTask =
    childTask
    |> List.replicate 20
    |> List.reduce (>>)

#time
parentTask()
#time


let asyncChildTask = async  { return childTask() }
let asyncParentTask =
    asyncChildTask
    |> List.replicate 20
    |> Async.Parallel

#time
asyncParentTask
|> Async.RunSynchronously
#time

[1,2,3]
|> List.replicate 5
|> printfn "%A"


let a() = ()

a
|> List.replicate 5
|> List.reduce (>>)
|> printfn "%A"