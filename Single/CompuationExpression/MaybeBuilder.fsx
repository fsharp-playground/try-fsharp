
type MaybeBuilder() =
    member this.Bind(x, f) =
        printfn "this.Bind: %A" f
        printfn "this.Bind: %A" x
        match x with
        | Some(x) when x >= 0 && x <= 100 -> f(x)
        | _ -> None
    member this.Delay(f) =
        printfn "this.Let: %A" f
        f()
    member this.Return(x) =
        printfn "this.Return: %A" x
        Some x

let maybe = MaybeBuilder()

maybe {
    let x = 12
    let! y = Some 11
    let! z = Some 30
    return x + y + z
} |> printfn "%A"