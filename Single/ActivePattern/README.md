## test.fsx

```fsharp

let (|Q1|Q2|Q3|) x =
    match x with
    | 100 -> Q1 100
    | 200 -> Q2 200
    | u -> Q3 300

let (|P3|_|) i = if i % 3 = 0 then Some i else None
let (|P5|_|) i = if i % 5 = 0 then Some i else None

let f = function
  | P3 _ & P5 _ -> printfn "FizzBuzz"
  | P3 _        -> printfn "Fizz"
  | P5 _        -> printfn "Buzz"
  | x           -> printfn "%d" x

Seq.iter f {1..100}
//or
for i in 1..100 do f i
```