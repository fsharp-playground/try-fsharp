
let rec fold func init data = 
    match data with
    | h:: t -> 
        (func h) (fold func init t)
    | [] -> init

let x = [1]
x |> fold (+) 100 |> printfn "%A"

let y = ["Hello"; "World"]
y |> fold (+) "xxx" |> printfn "%A"