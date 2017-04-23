
## Main.fsx

```fsharp
let viewName1 names =
    String.concat ", " (List.sort names)

let viewName2 names =
    names
    |> List.sort
    |> String.concat ", "

["a"; "c"; "b"] |> viewName1 |> printfn "%A" 
["a"; "c"; "b"] |> viewName2 |> printfn "%A" 


```
