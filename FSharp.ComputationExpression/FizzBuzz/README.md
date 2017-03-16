
## Error.fsx

```fsharp

open System

type Builder() =
    member this.Bind(m, f) = Option.bind f m
    member this.Return(x) = Some x

let getValue s = 
    match Int32.TryParse s with
    | (true, x) -> Some x
    | _ -> None

let (>>=) m f = Option.bind f m

let divideBy b t =
    match b with 
    | 0 -> None
    | _ -> Some (t / b)

let m = Builder();

getValue("1") >>= divideBy 2  |> printfn "%A"

let rs = 
    m {
        let! a = getValue("1")
        let! b = getValue("0")
        return divideBy a b
    } |> printfn "%A"

```
