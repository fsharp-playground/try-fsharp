
## test.fsx

```fsharp
// http://blogs.msdn.com/b/dsyme/archive/2007/09/22/some-details-on-f-computation-expressions-aka-monadic-or-workflow-syntax.aspx

seq { for i in 0..3 -> (i, i*i )} |> printfn "%A"
```
