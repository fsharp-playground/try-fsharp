let divideBy bottom top =
    if bottom = 0 then None
    else Some (top / bottom)

let divideByWorkflow init x y z = 
    let a = init |> divideBy x
    match a with
    | None -> None
    | Some a ->
        let b = a |> divideBy y
        match b with
        | None -> None
        | Some b ->
            let c = b |> divideBy z
            match c with 
            | None -> None
            | Some c -> Some c

divideByWorkflow 12 3 2 1 |> printfn "%A"
divideByWorkflow 12 3 0 1 |> printfn "%A"