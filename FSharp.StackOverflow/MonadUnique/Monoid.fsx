open System

type StringMonoid() =
    member x.Combine(s1, s2) = String.Concat(s1, s2)
    member x.Zero() = ""
    member x.Yield(s) = s
    member x.Delay(f) = f()

let str = StringMonoid() 
str {
    yield "A"
    yield "E" 
    yield "I" 
    yield "O"
    yield Console.ReadLine()
} |> printfn "%A"