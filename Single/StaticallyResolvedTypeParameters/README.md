## Main.fsx

```fsharp
// http://tomasp.net/blog/fsharp-generic-numeric.aspx
// https://docs.microsoft.com/en-us/dotnet/articles/fsharp/language-reference/generics/statically-resolved-type-parameters

type String() = member this.AppendX(x) = sprintf "%s --X" x

let inline go input (x: ^a) = 
    (^a : (member AppendX : string -> string) (x, input))

let x = String()
x |> go "Hello" |> printfn "%A"

```