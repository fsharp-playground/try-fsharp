// https://fsharpforfunandprofit.com/posts/computation-expressions-builder-part1

type TraceBuilder() =
    member this.Bind(m, f) =
        match m with
        | None ->
            printfn "Binding with None. Existing."
        | Some a ->
            printfn "Binding iwth Som(%A). Continuing" a

        Option.bind f m

    member this.Return(x) =
        printfn "Returning a unwarpped %A as an option" x
        Some x
    member this.ReturnFrom(m) =
        printfn "Returning an option (%A) directly" m
        m

let trace = TraceBuilder()

trace {
    return 1
} |> printfn "Result 1: %A \n"

trace {
    return! Some 2
} |> printfn "Result 2: %A \n"

trace {
    let! x = Some 1
    let! y = Some 2
    return x + y
} |> printfn "Result 3: %A \n"

trace {
    let! x = None
    let! y = Some 1
    return x + y
} |> printfn "Result 4: %A \n"