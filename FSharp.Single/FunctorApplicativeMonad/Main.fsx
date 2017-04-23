(*
let inline fmap f (x: ^t) =
    (^t : (static member fmap : unit -> ((^a -> ^b) -> ^t -> ^c)) ()) f x

let inline liftA f(x: ^t) =
    (^t : (static member liftA : uint -> (^a -> ^t -> ^b)) ()) f x

let inline liftM (x: ^t) =
    (^t : (static member liftM : unit -> (^t -> ^a -> ^b)) ()) x f
       *)

let inline fmap  f (x: ^t) =
    (^t : (static member fmap  : unit -> ((^a -> ^b) -> ^t -> ^c)) ()) f x
let inline liftA f (x: ^t) =
    (^t : (static member liftA : unit ->  (^a -> ^t  -> ^b)) ()) f x
let inline liftM (x: ^t) f =
  (^t : (static member liftM : unit ->  (^t -> ^a  -> ^b)) ()) x f

let inline (<@>) f m = fmap f m
let inline (<*>) fm m = liftA fm m
let inline (>>=) m f = liftM m f

type 'a Maybe =
    | Just of 'a
    | Nothing


// Functor
type 'a Maybe with
    static member fmap() : ('a -> 'b) -> 'a Maybe -> 'b Maybe =
        fun f -> function
            | Just x -> f x |> Just
            | Nothing -> Nothing

    static member liftA() : ('a -> 'b) Maybe -> 'a Maybe -> 'b Maybe =
        fun fm ->
            fun m ->
                match fm, m with
                    | Just f, Just x -> f x |> Just
                    | _ -> Nothing

    static member liftM(): 'a Maybe -> f: ('a -> 'b Maybe) -> 'b Maybe =
        fun m ->
            fun f ->
                match m with
                    | Nothing -> Nothing
                    | Just x -> f x

fmap ((+) 1)  (Just 42)
|> printfn "%A"

liftA (Just ((+) 1)) (Just 42)
|> printfn "%A"

liftM (Just 42) (fun x -> x + 1 |> Just)
|> printfn "%A"
