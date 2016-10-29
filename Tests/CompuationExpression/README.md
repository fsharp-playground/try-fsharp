## Bank.fsx

```fsharp

type RoundComputationBuilder(digits: int)  =
    let round(x: decimal) = System.Math.Round(x, digits)
    member this.Bind(result, restComputation) =
        restComputation (round result)
    member this.Return x = round x

let bankInterest = RoundComputationBuilder 2

bankInterest {
    let! x = 23231.34m * 0.002m
    return x
} |> printfn "%A"


```