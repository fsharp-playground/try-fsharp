
type MaybeBuilder() =
    member this.Bind(x, f) =
        printfn "this.Bind: %A" x
        match x with
        | Some(x) when x >= 0 && x <= 100 -> f(x)
        | _ -> None
    member this.Delay(f) = f()
    member this.Return(x) = Some <| x + 1

let maybe = MaybeBuilder()

let cp =
    maybe {
        let x = 1
        let! y = Some 2
        let! z = Some 30
        return x + y + z
    }

let rs = maybe.Delay(fun () ->
    let x = 1
    maybe.Bind(Some 2, fun y ->
            maybe.Bind(Some 3, fun z ->
                    maybe.Return(x + y + z) ) ) )

printfn "rs: %A" rs
printfn "cp: %A" cp