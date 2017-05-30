#load "SleepWorkflow.fsx"

let nestedWorkflow = 
    async {
        printfn "Starting parent"
        let! childWorkflow = Async.StartChild SleepWorkflow.sleepWorkflow

        do! Async.Sleep 100
        printfn "Doing someting usefull while waiting"

        let! result = childWorkflow
        printfn "Finised parent"
    }

Async.RunSynchronously nestedWorkflow 