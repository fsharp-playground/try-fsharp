// https://fsharpforfunandprofit.com/posts/elevated-world/

let mapOption f opt =
    match opt with
    | None ->
        None
    | Some x ->
        Some (f x)

let rec mapList f list =
    match list with
    | [] -> []
    | h::t ->
        (f h) :: (mapList f t)


let add1 x = x + 1
let add1IfSomething = Option.map add1
let add1ToEachElement = List.map add1

Some 2 |> add1IfSomething |> printfn "%A"
[1;2;3] |> add1ToEachElement |> printfn "%A"

mapOption add1 (Some 2) |> printfn "%A"
mapList add1 [1;2;3] |> printfn "%A"