// http://fssnip.net/lB/title/Monad-Bind-1-of-3

open System

type A = int
type S = float
type B = S
type T = DateTime
type C = T
type U = string

let today = DateTime.Now

let f (noWeeks:A) : S = float(7 * noWeeks)
let g (noDays: B) : T = today.AddDays noDays
let h (date: C) : U = date.ToShortDateString()

let fghExplicit = fun x -> h(g(f(x)))
//let fghExplicit2 = f >> g >> h

let compose (fun1, fun2) = fun arg -> fun2 (fun1 (arg))
//let compose2 (fun1, fun2) = fun1 >> fun2

let fghOne = compose(compose(f, g), h)
let fghTwo = compose(f, compose(g, h))

let fghExplicitResult = fghExplicit 100

let fghOneResult = fghOne 100
let fghTwoResult = fghTwo 100

fghExplicitResult   |> printfn "%A"
fghOneResult        |> printfn "%A"
fghTwoResult        |> printfn "%A"