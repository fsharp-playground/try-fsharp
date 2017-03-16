
for i in 1..100 do
    match i % 3, i % 5 with
    | 0, 0 -> "FizzBuzz"
    | 0, _ -> "Fizz"
    | _, 0 -> "Buzz"
    | _ -> string i
    |> printfn "%s"

(* ################# *)

let fizzBuzz0 i =
    match i % 3, i % 5 with
    | 0, 0 -> "FizzBuzz"
    | 0, _ -> "Fizz"
    | _, 0 -> "Buzz"
    | _ -> string i

[1..100] |> Seq.map fizzBuzz0 |> Seq.iter (printfn "%s")




(* ################# *)

type M<'T>  = M of 'T
type MonadBuilder() =
    member this.Return x = M x
let m = new MonadBuilder()
let fizz = function
    | x when x % 3 = 0  -> m { return x, "Fizz"}
    | x -> m { return x, "" }
let buzz = function
    | M (x,s) when x % 5 = 0 -> m { return x, s + "Buzz" }
    | M (x,s) -> m { return x, s }
[1..100] |> List.map(fizz) |> List.map(buzz) |> printfn "%A"

(* ################# *)

let fizzBuzz number =
    match number with
    | n when n % 15 = 0 -> "FizzBuzz"
    | n when n % 3 = 0 -> "Fizz"
    | n when n % 5 = 0 -> "Buzz"
    | n -> sprintf "%d" n
[1..100]
|> List.map fizzBuzz
|> List.iter (printfn "%s")