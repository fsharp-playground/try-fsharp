
type TraceBuilder() =
    member this.Bind(m, f) =
        match m with
        | None ->
            printfn "Binding with None. Existing."
        | Some a ->
            printfn "Binding with Som(%A). Continuing" a

        Option.bind f m

    member this.Return(x) =
        printfn "Returning a unwarpped %A as an option" x
        Some x
    member this.ReturnFrom(m) =
        printfn "Returning an option (%A) directly" m
        m
    member this.Zero() = 
        printfn "Zero"
        None
    
    member this.Yield(x) =
        printfn "Yield an unwrapped %A as an option" x
        Some x
    
    member this.YieldFrom(x) =
        printfn "Yield an option (%A) directy" x
        x

let trace = TraceBuilder()

trace {
    //yield 1
    yield! Some 2
} |> printfn "Result for yield: %A"