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

type IntOrBool = 
    | I of int 
    | B of bool

let parseInt s  =
    match Int32.TryParse s with
    | true, i -> Some(I i)
    | false, _ -> None

let parseBool s =
    match Boolean.TryParse s with
    | true, i -> Some (B i)
    | false, _ -> None

traceBuilder {
    return! parseBool "42"
    return! parseInt "42"
} |> printfn "Result for parsing: %A"




