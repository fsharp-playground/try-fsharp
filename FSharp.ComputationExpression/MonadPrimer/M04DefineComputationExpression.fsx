// https://en.wikibooks.org/wiki/F_Sharp_Programming/Computation_Expressions

type MaybeBuilder() =
    member this.Bind(x, f) =
        match x with
        | Some x when x >= 0 && x <= 100 -> f x
        | _ -> None
    member this.Delay(f) = f()
    member this.Return(x) = Some x

let maybe = MaybeBuilder()

maybe.Delay(fun () ->
    let x = 12
    maybe.Bind(Some 11, fun  y ->
        maybe.Bind(Some 30, fun z ->
            maybe.Return(x + y + z)
        )
    )
) |> printfn "%A"

maybe {
    let x = 12
    let! y = Some 11
    let! z = Some 30
    return z + y + z
} |> printfn "%A"
 