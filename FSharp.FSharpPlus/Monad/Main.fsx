#r @"../../packages/FSharpPlus/lib/net40/FSharpPlus.dll"

open FSharpPlus

let some14 =
    monad {
        let! x1 = Some 4
        let! x2 = Some 10
        return ((+) x1 x2)
    }

some14 |> printfn "%A"
    