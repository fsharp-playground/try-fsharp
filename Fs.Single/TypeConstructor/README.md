
## Main.fsx

```fsharp
type Foo = Items of list<int>

let items = Items

[1;2;3] |> Items
[1;2;3] |> items


```
