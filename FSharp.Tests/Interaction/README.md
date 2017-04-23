
## Main.fsx

```fsharp
let a = Set.ofList [1; 2; 4; 6;]
let b = Set.ofList [1; 3; 5; 7;]
let x = Set.intersect a b |> Set.toList |> List.length > 0
printfn "%A" x
Set.intersect a b |> printfn "%A"


open System.Linq

let l1 = [1;2;3;4]
let l2 = [1;2;3]

List.forall(fun el -> List.contains el l1) l2  |> printfn "%A"

let www = [1;2;3].All(fun x -> [1;2].Contains x)








```
