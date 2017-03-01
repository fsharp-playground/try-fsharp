open System

type TraceBuilder() =  
    member this.Zero()  =
        printfn "Zero"
        None
    
    member this.ReturnFrom(x) = x
    member this.Delay(f) = f()

    member this.Combine(a,b) =
        printfn "Combining %A with %A" a b
        match a with
        | Some _ -> a
        | None -> b

let traceBuilder = TraceBuilder()

let map1 = [ ("1","One"); ("2","Two") ] |> Map.ofList
let map2 = [ ("A","Alice"); ("B","Bob") ] |> Map.ofList

traceBuilder {
    return! map1.TryFind "A"
    return! map2.TryFind "A"
} |> printfn "%A"