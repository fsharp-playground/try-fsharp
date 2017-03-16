
## Main.fsx

```fsharp
open System

let strToInt str =
    let ok, rs = Int32.TryParse str
    match ok with
    | true -> Some rs
    | false -> None

type B() =
    member b.Bind(x, f) =
        match x with
        | Some x -> f x
        | None -> None

    member b.Return(x) = Some x

let b = B()

let flow x y z =
    b {
        let! a = strToInt x
        let! b = strToInt y
        let! c = strToInt z
        return a + b + c
    }

let x = 
    b.Bind(Some 1, fun x ->
        b.Bind(Some 2, fun y ->
            b.Bind(Some 3, fun z -> 
                b.Return(x + y + z ))))

x |> printfn "X - %A"


let strAdd str i =
    strToInt str |> Option.map ((+) i)

let (>>=) m f = Option.bind f m

let good = strToInt "1" >>= strAdd "2" >>= strAdd "3"
let bad = strToInt "1" >>= strAdd "xyz" >>= strAdd "3"

good    |> printfn "Good %A" 
bad     |> printfn "Bad %A"     

flow "1" "2" "3" |> printfn "Flow %A"
```
