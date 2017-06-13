
module Option = 
    let apply f x = 
        match f, x with
        | Some f, Some x -> Some (f x)
        | _ -> None

module List = 
    let apply (fl : ('a -> 'b) list) (xl : 'a list) =
        [ for f in fl do 
            for x in xl do
                yield f x ]

type Fmap = Fmap with
    static member ($) (_, x:option<_>) = fun f -> Option.map f x
    static member ($) (_, x:list<_>  ) = fun f -> List.map   f x

type Apply = Apply with
    static member (*) (_, x: option<_>) = fun f -> Option.apply f x 
    static member (*) (_, x: list<_>) = fun f -> List.apply f x
    
let inline (<!>) f x = Fmap $ x <| f
let inline (<*>) f x = Apply * x <| f

let inline lift2 f x y = 
    f <!> x <*> y

let inline lift3 f x y z = 
    f <!> x <*> y <*> z

(+) <!> Some 5  <*> Some 10     |> printfn "%A"
(+) <!> [5]     <*> [10;20;30]  |> printfn "%A"  

lift2 (+) (Some 1) (Some 2)  |> printfn "%A"
lift3 (fun x y z -> x + y + z) (Some 1) (Some 2) (Some 3)  |> printfn "%A"

let inline tuple x y = x , y

let combineOpt x y = lift2 tuple x y

combineOpt (Some 1) (Some 2)




