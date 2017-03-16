
## ComputationExpression.fsx

```fsharp
module MonadSpec

let primer() =

    let readLine() = System.Console.ReadLine()
    let printString(s) = printf "%s" s

    printString "What's your name? "
    let name = readLine()

    printString ("Hello, " + name)
   

let extraParams() =
    let readLine(f) = f(System.Console.ReadLine())
    let printString(s, f) = f(printf "%s" s)

    printString("What's your name? ", fun () ->
        readLine(fun name ->
                printString("Hello, " + name, fun () -> ())))

let maybeMonad() =

    let addThreeNumbers() =
        let getNum msg =
            printf "%s" msg
            match System.Int32.TryParse(System.Console.ReadLine()) with
            | (true, n) when n >= 0 && n <= 100 -> Some(n)
            | _ -> None

        match getNum "#1: " with
        | Some(x) ->
            match getNum "#2: " with
            | Some(y) ->
                match getNum "#3: " with
                | Some(z) -> Some( x + y + z)
                | None -> None
            | None -> None
        | None -> None

    addThreeNumbers()

let monadic() =

    let addThreeNumbers() =
        let bind(input, rest) =
            match System.Int32.TryParse (input()) with
            | (true, n) when n > 0 && n <= 100 -> rest(n)
            | _ -> None

        let createMsg msg = fun() -> printf "%s" msg; System.Console.ReadLine()

        bind(createMsg "#1: ", fun x ->
            bind(createMsg "#2: ", fun y ->
                bind(createMsg "#3: ", fun z -> Some( x + y + z))))

    addThreeNumbers()


module Monad =
    open System.Threading
    open System.Text.RegularExpressions

    let bind(input, rest) =
        ThreadPool.QueueUserWorkItem(new WaitCallback(fun _ -> rest(input()))) |> ignore


    let downloadAsync (url : string) =
        let printMsg msg = printfn "ThreadID = %i, Url = %s, %s" (Thread.CurrentThread.ManagedThreadId) url msg
        bind( (fun () -> printMsg "Creating webclient..."; new System.Net.WebClient()), fun webclient ->
            bind( (fun () -> printMsg "Downloading url..."; webclient.DownloadString(url)), fun html ->
                bind( (fun () -> printMsg "Extracting urls..."; Regex.Matches(html, @"http://\S+") ), fun matches ->
                        printMsg ("Found " + matches.Count.ToString() + " links")
                    )
                )
            )

    let go() =
        ["http://www.google.com/"; "http://microsoft.com/"; "http://www.wordpress.com/"; "http://www.peta.org"] |> Seq.iter downloadAsync;;


module CX =

    type MaybeBuilder() =
        member this.Bind(x, f) =
            match x with
            | Some(x) when x >= 0 && x <= 100 -> f(x)
            | _ -> None

        member this.Delay(f) = f()
        member this.Return(x) = Some x


    let maybe = MaybeBuilder()

    let rs = maybe.Delay (fun x ->
        let x = 12
        maybe.Bind(Some 11, fun y ->
            maybe.Bind(Some 30, fun z ->
                maybe.Return(x + y + z)
            )
        )
    )
```
