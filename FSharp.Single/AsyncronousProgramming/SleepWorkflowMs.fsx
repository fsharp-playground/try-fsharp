open System


let sleepWorkflowMs ms = 
    async {
        printfn "%i ms workflow started" ms
        do! Async.Sleep ms
        printfn "%i ms workflow finished" ms
    }

let workflowSeries = 
    async {
        let! sleep1 = sleepWorkflowMs 1000
        printfn "Finished on"
        let! sleep2 = sleepWorkflowMs 2000
        printfn "Finished two"
    }

#time
Async.RunSynchronously workflowSeries
#time


let sleep1 = sleepWorkflowMs 1000
let sleep2 = sleepWorkflowMs 2000

#time
[sleep1; sleep2]
|> Async.Parallel
|> Async.RunSynchronously
#time