let log p = printfn "expression is %A" p

let loggedWorkflow =
    let x = 42
    log x
    let y = 43
    log y
    let z = x + y
    log z

type LoggingBuilder() =
    let log p = printfn "expression is %A" p

    member this.Bind(x, f) =
        log x
        f x
    
    member this.Return x =
        x + x

let logger = LoggingBuilder()
let k = logger {
    let! x = 1
    let! y = 2
    let! z = x + y
    return x
}

printfn "%A" k