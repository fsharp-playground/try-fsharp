
## FizzBuzz001.fsx

```fsharp
type FB<'T> = FB of 'T * string 

let inline (>>=) (FB (x, y)) f : FB<'b> = f (x,y) 
let fbreturn x = FB x

type FizzBuzzBuilder () =
  member this.Return (x) = fbreturn x
  member this.Bind (m,f) = m >>= f

let fb = FizzBuzzBuilder ()

let fizz = function
| x when x % 3 = 0 -> fb { return x,"Fizz" }
| x -> fb { return x,"" }

let buzz = function
| x,s when x % 5 = 0 -> fb { return x, s + "Buzz" }
| x,s -> fb { return x,s }

let printFB  = function 
  | FB(x,"") -> printfn "%A" x
  | FB(_,y)  -> printfn "%s" y

let fizzbuzz = Seq.iter (fun x -> (fizz x >>= buzz) |> printFB)

[1..100] |> fizzbuzz
System.Console.ReadLine () |> ignore
```
