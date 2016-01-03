let inline print x = printfn "%A" x

do
    ['a'..'m']          |> printfn "list  a-m = %A"
    seq { 'a'..'m' }    |> printfn "seq   a-m = %A"
    [| 'a'..'m' |]      |> printfn "array a-m = %A"
    [| 'a'..'m' |]      |> System.String    |> printfn "convert to string = %A"

do
    [ 0..10 ]                     |> printfn "%A"
    [ 'a'..'k']                   |> printfn "%A"
    [ for i in 'a'..'k' -> int i] |> printfn "%A"

do
    let mutable ten  = 10
    let list = [ for i in 0..10 do yield i + ten]
    let seq = seq { for i in 0..10 do yield i + ten }
    ten <- 0

    list |> printfn "%A"
    seq |> printfn "%A"

do
    printfn "== yield =="
    [ yield! {1..10} ; yield! {1..10} ] |> printfn "%A"
    [ yield {1..10} ; yield {1..10} ] |> printfn "%A"

do
    printfn "== get =="
    let mutable t = 0
    let getX() = (t <- t + 1); t;
    seq { yield getX() } |> printfn "%A"

do
    printfn "== step =="
    [2..2..20]  |> printfn "%A"
    [20..-2..2] |> printfn "%A"

do
    printfn "== slice =="
    [0..9].[5..]    |> printfn "%A"
    [0..9].[..5]    |> printfn "%A"
    [0..9].[5..7]   |> printfn "%A"
    [2..5].[*]      |> printfn "%A"
    [| for i in 1..6 do yield! [| i; i+1; i+2; i+3; i+4 |] |] |> print

do
    printfn "== var =="
    let start,end'= (0, 10)
    [start..end'] |> print

do
    printfn "== float =="
    [1.0..0.1..2.0] |> print
    [1..+2..20] |> print


do
    printfn "== alias =="
    let go = (..)
    go 1 10 |> print

do
    printfn "== when =="

    let inline go(x: ^T when (^T) : (static member (+): ^T * ^T -> ^T)) =
        x + 100.0

    let inline add(value1 : ^T when (^T or ^U) : (static member (+) : ^T * ^U -> ^T), value2 : ^U) =
        value1 + value2

    add(100.0, 200.0) |> print
    go(100.0) |> print

