
## M01VisualizeMonadsWithFSharp.fsx

```fsharp
open System

(*
let readLine() = Console.ReadLine()
let printString(s) = printf "%s" s

printString "What's your name? "
let name = readLine()
printString ("Hello, " + name)
*)

let readLine(f) = f(Console.ReadLine())
let printString(s, f) = f(printf "%s" s)

printString("What's your name? ", fun() ->
    readLine(fun name ->
        printString("Hello, " + name, fun () -> () ) ) )



```
