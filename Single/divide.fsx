
let divideBy buttom top =
    if buttom = 0 then None else Some(top/buttom)

(*------------------------------*)
let divideByWorkflow x y w z =
    let a = x |> divideBy y
    match a with
    | None -> None
    | Some a' ->
        let b = a' |> divideBy w
        match b with
        | None -> None
        | Some b' ->
            let c = b' |> divideBy z
            match c with
            | None -> None
            | Some c' -> Some c'

let pipeInfo (someExpression, lambda) =
    match someExpression with
    | None -> None
    | Some x -> x |> lambda

(*------------------------------*)
let divideByWorkflow2 x y w z =
    let a = x |> divideBy y
    pipeInfo (a, fun a' ->
        let b = a' |> divideBy w
        pipeInfo(b, fun b' ->
            let c = b' |> divideBy z
            pipeInfo (c, fun c' -> Some c') ) )

let divideByWorkflow3 x y w z =
    pipeInfo (x |> divideBy y, fun a ->
    pipeInfo (a |> divideBy w, fun b ->
    pipeInfo (b |> divideBy z, fun c -> Some c ) ) )

(*------------------------------*)
let return' c = Some c
let divideByWorkflow4 x y w z =
    pipeInfo(x |> divideBy y, fun a ->
    pipeInfo(a |> divideBy w, fun b ->
    pipeInfo(b |> divideBy z, fun c -> return' c ) ) )

divideByWorkflow4 12 3 2 1 |> printfn "%A"
divideByWorkflow4 12 3 0 1 |> printfn "%A"


