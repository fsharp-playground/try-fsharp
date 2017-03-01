open System
open System.Threading
open System.Net
open System.Text.RegularExpressions

let bind(input, rest) =
    let execute(o) =
        let input = input()
        rest(input)

    //ThreadPool.QueueUserWorkItem(new WaitCallback(fun _ -> rest(input()))) |> ignore
    ThreadPool.QueueUserWorkItem(new WaitCallback(execute)) |> ignore

let downloadAsync(url) =
    let printMsg msg = printfn "TheadID = %i, Url = %s, %s" (Thread.CurrentThread.ManagedThreadId) url msg

    let createWebClient() =
        printMsg "Create webclient .."
        new WebClient() 

    bind(createWebClient, fun webClient ->
        let downloadString() =
            printMsg "Download url..."
            webClient.DownloadString(url)
        bind(downloadString, fun html -> 
            let extractUrl() =
                printMsg "Extracting urls ..."
                Regex.Matches(html, @"http://\S+") 
            bind(extractUrl, fun matches ->
                printMsg <| "Found " + matches.Count.ToString() + " links"
            )
        )
    )

["http://www.google.com/"; "http://microsoft.com/"; "http://www.wordpress.com/"; "http://www.peta.org"] 
|> Seq.iter downloadAsync

Console.ReadLine()