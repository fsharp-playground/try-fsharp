
type Fmap = Fmap with
    static member ($) (_, x:option<_>) = fun f -> Option.map f x
    static member ($) (_, x:list<_>) = fun f -> List.map f x

let inline fmap f x = (Fmap $ x) f

printfn "%A" <| fmap ((+) 2) [1;2;3;]

let map2 = fmap ((+) 2) (Some 5)

