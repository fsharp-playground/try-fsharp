
## Main.fsx

```fsharp
open Microsoft.FSharp.Quotations
open System

let codeAsData = <@ 2 + 3 * 7 @>

let rec prettyPrint(e:Expr) = 
    match e with
    | Patterns.Call(None, m, [p1; p2]) when m.Name = "op_Addition" ->
        sprintf "(%s + %s)" (prettyPrint p1) (prettyPrint p2)
    | Patterns.Call(None, m, [p1; p2]) when m.Name = "op_Multiply" ->
        sprintf "(%s * %s)" (prettyPrint p1) (prettyPrint p2)
    | Patterns.Value(o, t) -> o.ToString()
    | _ -> raise(Exception("I can't translate this type!!! :'("))
  //"Let's print this!"

let rs = codeAsData |> prettyPrint
printfn "%A" rs

```
