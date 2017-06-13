open System

module Option =
    let bind f opt = 
        match opt with
        | Some x -> f x 
        | _ -> None

module List = 
    let bind (f: 'a -> 'b list) (xlist: 'a list) =
        [ for x in xlist do
            for y in f x do 
                yield y]

type Bind = Bind with
    static member (>>=) (_, x:option<_>) = fun f ->  Option.bind f x
    static member (>>=) (_, x:list<_>) = fun f -> List.bind  f x

let inline (>>=) f x = Bind >>= f <| x

let parse str =
    match Int32.TryParse str with
    | true, rs -> Some rs
    | _ -> None

let double input = 
    Some (input * 2)

let doubleList input = [input + input]

Some 5 >>= double >>= double
|> printfn "%A"

["A"; "B"; "C"] >>= doubleList >>= doubleList
|> printfn "%A"

None >>= (fun x -> 
double x    >>= (fun y ->
double y    >>= (fun z -> 
Some (x + y + z ))))
|> printfn "%A"

printfn "%A" None

// 3 + 6 + 12

