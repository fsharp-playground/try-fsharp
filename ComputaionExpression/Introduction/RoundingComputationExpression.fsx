
type RoundComputationBuilder(digits: int) =
    let round(x: decimal) = System.Math.Round(x, digits)
    member this.Bind(result, rest) =
        rest (round result)
    member this.Return(x) = round x

let bankInterest = RoundComputationBuilder 2

let rs =
    bankInterest {
        let! x = 1.0m * 2.0m
        let! y = x * 2.0M
        return y
    } 
    
rs |> printfn "%A"
