
type M<'T>  = M of 'T

type MonadBuilder() =
    member this.Bind m f =  


let m = new MonadBuilder()

let fizz = function
    | x when x % 3 = 0  -> m { return x, "Fizz"}
    | x -> m { return x, "" }

let buzz = function
    | M (x,s) when x % 5 = 0 -> m { return x, s + "Buzz" }
    | M (x,s) -> m { return x, s }

[1..100] |> List.map(fizz) |> List.map(buzz) |> printfn "%A"