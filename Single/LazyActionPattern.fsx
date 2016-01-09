let print x = printfn "%A" x

let rec factorial n =
    match n with
    | 0 | 1 -> 1
    | n -> n * (factorial (n-1))

let lazyValue = lazy (factorial 10)
match lazyValue with
| Lazy value -> printfn "10 factorial is %d" value
|> print
