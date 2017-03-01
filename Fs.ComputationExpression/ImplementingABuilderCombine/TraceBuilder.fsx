type TraceBuilder() =
    member this.Bind(m, f) =
        match m with
        | None ->
            printfn "Binding with None. Existing"
            None
        | Some a ->
            printfn "Binding with Some(%A). Continuing " a
            f m

    member this.Return(x) =
        printfn "Returning a unwrapped %A as an option" x
        Some x

    member this.ReturnFrom(m) =
        printfn "Returning an option (%A) directly" m

    member this.Zero() =
        printfn "Zero"
        None

    member this.Yield(x) =
        printfn "Yield an unwrapped %A as an option" x
        Some x

    member this.YieldFrom(m) =
        printfn "Yield an option (%A) directly" m
        m
    member this.Combine(a, b) =
        match a, b with
        | Some a, Some b -> 
            printfn "Combining %A and %A" a b
            Some(a+b)
        | Some a, None ->
            printfn "Combining %A with None" a
            Some a
        | None, Some b ->
            printfn "Combining %A with None" b
            Some b
        | None, None ->
            printfn "Combining None with None"
            None
    member this.Delay(f) = f() 

let trace = TraceBuilder()

trace {
    yield 1
    return 2
} |> printfn "%A"
