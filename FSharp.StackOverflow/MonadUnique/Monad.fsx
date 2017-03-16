// http://stackoverflow.com/questions/5996239/is-fs-implementation-of-monads-unique-with-respect-to-the-amount-of-keywords-a

type MaybeMonad() =
    member x.Bind(m, f) =
        match m with
        | Some v -> f v
        | None -> None
    member x.Return(v) =
        Some(v)

let maybe = MaybeMonad()
let rec productNameById() = 
    maybe {
        let! id = Some 1
        let! proc = Some "X"
        return proc
    }

productNameById() |> printfn "%A"