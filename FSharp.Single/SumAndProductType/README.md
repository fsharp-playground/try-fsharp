
## Sum.fsx

```fsharp

type Part =
    { Price: int
      Count: int }

let partAdd p1 p2 =
    { Price = p1.Price + p2.Price
      Count = p1.Count + p2.Count }

let partList =
    [ { Price = 10; Count = 1 }
      { Price = 20; Count = 2 }
      { Price = 30; Count = 3 }]

partList |> List.reduce partAdd |> printfn "%A" // { Price = 60; Count = 6 }




```
