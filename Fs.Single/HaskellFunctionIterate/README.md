
## Main.fsx

```fsharp
let rec iterate f value = seq {
    yield value
    yield!  iterate f (f value) }
    
Seq.take 10 (iterate ((*)2) 1) |> Seq.toList |> printfn "%A"


let a = seq { yield! [1;2;3;] }
let b = seq { yield 2 }

a |> printfn "%A" 
b |> printfn "%A"
```
