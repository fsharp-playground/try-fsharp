## Main.fsx

```fsharp

open System

let inline stringf format (x: ^a) = 
    (^a: (member ToString : string -> string) (x, format)) |> printfn "%A"

DateTime.Now |> stringf "dd/MM/yyyy"
10 |> stringf "D10"


```