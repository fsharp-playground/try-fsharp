
type ('a, 'b) Either = This of 'a | That of 'b

//let (This a | That a) = This 10 

let (This c | That c) = 
    match c with
    | 100 -> That c
    | _ -> This c

let x = 10

let f a =
    match a with
    | That 10 -> "That 10"
    | This 20 -> "This 20"
    | That x -> x(100)
    | This x -> x(200)

let rs = 100 |> f
printfn "%A" rs