## Main.fsx

```fsharp

[<StructuredFormatDisplay("My name is {First} {Last}")>]
type Person = {First:string; Last:string}

let me = { First = "wk"; Last = "wk"}
printfn "%A" me
```