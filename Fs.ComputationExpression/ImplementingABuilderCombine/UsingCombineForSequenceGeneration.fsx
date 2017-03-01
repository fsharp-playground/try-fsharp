type ListBuilder() =
    member this.Bind(m ,f) =
        m |> List.collect f

    member this.Zero() =
        printfn "Zero"
        []

    member this.Yield(x) =
        printfn "Yield an unwrapped %A as a list" x
        [x]

    member this.YieldFrom(m) =
        printfn "Yield a list (%A) directly" m
        m

    member this.For(m, f) =
        printfn "For %A" m
        this.Bind(m, f)

    member this.Combine(a,b) =
        printfn "Combining %A and %A" a b
        List.concat [a;b]

    member this.Delay(f) =
        printfn "Delay"
        f()

let listBuilder = ListBuilder()
listBuilder {
    yield 1
    yield 2
} |> printfn "Result for yield then yield: %A"