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

//divideByWorkflow 12 3 2 1 |> printfn "%A"
//divideByWorkflow 12 3 0 1 |> printfn "%A"


type MaybeBuilder() =
    member this.Bind(x, f) =

        printfn "Bind - %A - %A" x f

        let rs = 
            match x with
            | None -> None
            | Some a -> f a

        printfn "RS - %A" rs
        (rs)

    member this.Return x =
        printfn "Return - %A" x
        Some x

let maybe = MaybeBuilder()
let divideByWorkflow2 init x y z =
    maybe {
        let! a =  init |> divideBy x
        let! b =  a |> divideBy y
        let! c =  b |> divideBy z
        return c
    }

printfn "\n"
divideByWorkflow2 12 3 2 1 |> printfn "Final %A"


let div2 init x y z =

    maybe.Bind(Some init, fun init ->
        let a = init |> divideBy x
        maybe.Bind(a, fun b -> 
            let c = b |> divideBy y
            maybe.Bind(c, fun c ->
                maybe.Return(c))))

    
printfn "\n"
div2 12 3 2 1 |> printfn "Final %A"
