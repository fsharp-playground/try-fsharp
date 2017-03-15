// http://fssnip.net/bE/title/Simple-builder-example-Nullable

open System

type NullableBuilder() =
    let hasValue (a: Nullable<'a>) = a.HasValue
    member t.Return(x) = Nullable(x)
    member t.Bind(x, rest) =
        match hasValue x with
        | false -> Nullable()
        | true -> rest(x.Value)

let nullable = NullableBuilder()
let test =
    nullable {
        let! a = Nullable(3)
        let! b = Nullable(5)
        let! c = Nullable()
        let mult = a * b * c
        let sum = mult + 1
        return sum
    }

test |> printfn "%A"