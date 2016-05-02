
open System

let (|Fail|) s v = failwith s

let getAge(Some age | Fail "Age is missing" age) = age

let getAge2 = function
    | Some age -> age
    | Fail "Age is missing age" age -> age


let a: int = getAge(Some 10)

let (|Q1|Q2|X|) month =
    match month with
    | 1 | 2 | 3 -> Q1 (month, "Q1")
    | 4 | 5 | 6 -> Q2 (month, "Q2")
    | _ -> X (month,"QX")

let qv1( Q1 q | Q2 q | X q) = sprintf "%d is %s" <| fst q <| snd q
qv1(1) |> printfn "%A" // 1 is Q1
qv1(4) |> printfn "%A" // 4 is Q2
qv1(9) |> printfn "%A" // 9 is QX

let qv2= function
    | Q1 (m, q) -> "First"
    | Q2 (m, q) -> "Second"
    | X (m, q) -> "X"
qv2(1) |> printfn "%A"
qv2(4) |> printfn "%A"
qv2(9) |> printfn "%A"