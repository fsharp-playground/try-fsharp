
## Main.fsx

```fsharp

[<StructuredFormatDisplay("My name is {First} {Last}")>]
type Person = { 
    First:string
    Last:string }

let me = { 
    First = "John"
    Last = "Wick" }

printfn "%A" me // My name is John Wick


```
