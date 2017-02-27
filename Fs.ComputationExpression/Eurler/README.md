
## Main.fsx

```fsharp
type Euler1Builder() =
    member b.Combine(x, y) = x + y
    member b.Zero() = 0
    member b.Yield(x) = if x % 5 = 0 || x % 3 = 0 then x else 0
    member b.For(vals, f) =
        vals |> Seq.fold(fun s n -> b.Combine(s, f n)) (b.Zero())

let eb = Euler1Builder()

let rs = 
    eb {
        for x = 0 to 10 - 1 do yield x
    }

rs |> printfn "%A"

type Euler1Build2() =
    member b.Yield(x) = if x % 5 = 0 || x % 3 = 0 then x else 0
    member b.For(generated, f) = generated |> Seq.map f
    member b.Run(filtered: int seq) = filtered |> Seq.sum

let eb2 = Euler1Build2()
eb2 {
    for x = 0 to 10 - 1 do yield x
} |> printfn "%A"

```
