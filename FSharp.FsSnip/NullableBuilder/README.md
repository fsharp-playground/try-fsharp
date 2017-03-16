
## Format.fsx

```fsharp

open System
printfn "%A" <| Nullable<int>()
printfn "%A" null

let s1 = sprintf "%s" null
let s2 = sprintf "%A" null 

printfn "%A %A" s1 s2
```
