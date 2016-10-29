open System.Runtime.CompilerServices

type M() =
    member self.f([<CallerLineNumber>]?line : int) =
        line.Value
let m = M()
m.f() = 8 |> printfn "%A"