
open System.Runtime.CompilerServices

type M() =
    member self.f([<CallerLineNumber>]?line : int) =
        printfn "Line %d" line.Value

(*
    member self.f() =
        printfn "Line f"
*)


let m = M()

let foo () =
    m.f()

foo ()