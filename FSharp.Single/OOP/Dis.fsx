open System
open System.Text
type Car() =
    interface IDisposable with
        member this.Dispose() = 
            printfn "Gone"
    member this.Run() = 
        printfn "Run"

let go() =
    let block() =
        let sb = StringBuilder()
        use car = new Car()
        car.Run()
    block()
    printfn "End go"

go()

