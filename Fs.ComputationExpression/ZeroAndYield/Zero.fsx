
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

let trace = TraceBuilder()

trace {
    let! a = Some 100;
    printfn "hello world"
    //return a;
} |> printfn "Result for somple expression %A"