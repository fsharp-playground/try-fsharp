open System
open System.Threading
open System.Text.RegularExpressions

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
            | Some(z) -> Some(x + y + z)
            | None -> None
        | None -> None
    | None -> None

let addThreeNumbers2() =
    let bind(input, rest) =
        match System.Int32.TryParse(input()) with
        | (true, n) when n >= 0 && n <= 100 -> rest(n)
        | _ -> None

    let createMsg msg =
        fun() ->
            printf "%s" msg
            System.Console.ReadLine()

    bind(createMsg "#1: ", fun x ->
            bind(createMsg "#2: ", fun y ->
                bind(createMsg "#3: ", fun z -> Some(x + y + z) ) ) )

let download() =

    let bind(input, rest) =
        ThreadPool.QueueUserWorkItem(new WaitCallback( fun _ -> rest(input()) )) |> ignore

    let downloadAsync (url : string) =
        let printMsg msg = printfn "ThreadID = %i, Url = %s, %s" (Thread.CurrentThread.ManagedThreadId) url msg
        bind( (fun () -> printMsg "Creating webclient..."; new System.Net.WebClient()), fun webclient ->
            bind( (fun () -> printMsg "Downloading url..."; webclient.DownloadString(url)), fun html ->
                bind( (fun () -> printMsg "Extracting urls..."; Regex.Matches(html, @"http://\S+") ), fun matches ->
                        printMsg ("Found " + matches.Count.ToString() + " links")
                    )
                )
            )

    ["http://www.google.com/"; "http://microsoft.com/"; "http://www.wordpress.com/"; "http://www.peta.org"] |> Seq.iter downloadAsync


//addThreeNumbers()
//addThreeNumbers2()
download()

