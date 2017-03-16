
## FizzBuzzBuilder.fsx

```fsharp
// http://tryjoinads.org/docs/computations/monads.html

type FizzBuzz =
    | Fizz
    | Buzz
    | FizzBuzz
    | Num of int

type FizzBuzzBuilder() =
    let (|DivisibleBy|_|) divisor i = if i % divisor = 0 then Some () else None 
    member b.Yield(v) = 
        match v with
        | DivisibleBy 3 & DivisibleBy 5 -> FizzBuzz
        | DivisibleBy 3 -> Fizz
        | DivisibleBy 5 -> Buzz
        | _ -> Num v
    member b.For(generated, f) = generated |> Seq.map f

let fb = FizzBuzzBuilder()

let toText = function
    | Fizz -> "Fizz"
    | Buzz -> "Buzz"
    | FizzBuzz -> "FizzBuzz"
    | Num n -> sprintf "%i" n

let rs = fb { for x in 1 .. 100 do yield x }  
rs |> Seq.iter  (toText >> printfn "%s ")





```
