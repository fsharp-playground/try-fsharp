
## Main.fsx

```fsharp

type A = { Thing: int }
type B = { Label: string }


type Shows = 
    //static member show { Thing = 10 } = printfn "%A" "wk"
    static member Show { Thing = t } = printfn "%A" t
    static member Show { Label = l } = printfn "%A" l 
```
