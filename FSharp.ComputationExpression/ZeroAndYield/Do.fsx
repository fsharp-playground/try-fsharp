
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

let trace = TraceBuilder()

trace {
    do! Some (printfn "...expression that return unit")
    do! Some (printfn "...another expression that return unit")
    let! x = Some(1)
    return x
} |> printfn "Return from do: %A"