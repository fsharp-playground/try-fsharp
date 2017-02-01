## Main.fsx

```fsharp

open System

let inline stringf format (input: ^a) = 
    (^a: (member ToString : string -> string) (input, format)) 

DateTime.Now |> stringf "dd/MM/yyyy"
10 |> stringf "D10"


```