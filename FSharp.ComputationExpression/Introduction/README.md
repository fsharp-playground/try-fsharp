
## ChainsOfOrElseTests.fsx

```fsharp
let map1 = [ ("1","One"); ("2","Two") ] |> Map.ofList
let map2 = [ ("A","Alice"); ("B","Bob") ] |> Map.ofList
let map3 = [ ("CA","California"); ("NY","New York") ] |> Map.ofList


let multiLookup key =
    match map1.TryFind key with
    | Some result1 -> Some result1
    | None ->
        match map2.TryFind key with
        | Some result2 -> Some result2
        | None ->
            match map3.TryFind key with
            | Some result3 -> Some result3
            | None -> None

multiLookup "A" |> printfn "Result for A is %A" 
multiLookup "CA" |> printfn "Result for CA is %A" 
multiLookup "X" |> printfn "Result for X is %A" 

// ==================

type OrElaseBuilder() =
    member this.ReturnFrom (x) = x
    member this.Combine (a, b) =
        match a with
        | Some _ -> a
        | None -> b
    member this.Delay(f) = f()

let orElse = OrElaseBuilder()

let multiLookup2 key = 
    orElse {
        return! map1.TryFind key
        return! map2.TryFind key
        return! map3.TryFind key
    }

multiLookup "A" |> printfn "Result for A is %A" 
multiLookup "CA" |> printfn "Result for CA is %A" 
multiLookup "X" |> printfn "Result for X is %A" 
```
