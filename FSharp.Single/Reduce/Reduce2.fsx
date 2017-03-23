
let rec fold func init input = 
    match input with
    | h::t -> 
        (func h) (fold func init t)
    | [] -> init

let reduce func input = 
    match input with
    | [] -> failwith "Invalid input"
    | h::t -> fold func h t

["a";"b";"c";"d";"e"]   |> fold (+) "-"     |> printfn "%A"     // abcde-
["a";"b";"c";"d";"e"]   |> reduce (+)       |> printfn "%A"     // bcdea
