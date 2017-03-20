
let rec fold func init data = 
    match data with
    | h:: t -> 
        (func h) (fold func init t)
    | [] -> init

let reduce func input = 
    match input with
    | [] -> failwith "Invalid input"
    | h::t -> fold func h t

let x = [1;2;3]
x |> reduce (+) |> printfn "%A"
