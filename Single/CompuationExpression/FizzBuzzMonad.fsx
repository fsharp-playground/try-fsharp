
type FizzBuzzMonad() =
    member this.ReturnFrom x =
        printfn "-- return! ReturnFrom: %A" x
        x
    member this.Bind( (x, s1), f) =
        printfn "-- let! Bind: (%A %A) %A"  x s1 f
        f x |> fun (x, s2) -> x, s1 + s2

let fzb = FizzBuzzMonad()
let fizz = function
    | x when x % 3 = 0 -> fzb { return! x, "Fizz" }
    | x -> fzb { return! x, "" }
let buzz = function
    | x when x % 5 = 0 -> fzb { return! x, "Buzz" }
    | x -> fzb { return! x, ""}
let print = function
    | x, "" -> printfn "%A" x
    | _, y -> printfn "%s" y

let cal x = fzb {
    let! x = fizz x
    return! buzz x
}

[1..10] |> Seq.iter( cal >> print)

