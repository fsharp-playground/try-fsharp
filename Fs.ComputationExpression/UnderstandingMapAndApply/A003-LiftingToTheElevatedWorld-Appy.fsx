module Option =

    let apply fopt xopt =
        match fopt, xopt with
        | Some f, Some x -> Some(f x)
        | _ -> None

module List =

    let apply (flist: ('a -> 'b) list) (xlist: 'a list) =
        [ for f in flist do
            for x in xlist do  
                yield f x ]

/// Infix
let add x y = x + y 

let resultOption = 
    let (<*>) = Option.apply
    let k = (Some add) <*> (Some 2)
    let j = k <*> (Some 3)
    j

resultOption |> printfn "%A"


let resultList =
    let (<*>) = List.apply
    let k = [add] <*> [1;2]
    let j = k <*> [3;4]
    j

let resultOptions2 =
    let (<!>) = Option.map
    let (<*>) = Option.apply
    add <!> (Some 2) <*> (Some 3)

let resultList2 =
    let (<!>) = List.map
    let (<*>) = List.apply
    add <!> [1;2] <*> [10;20]

let batman =
    let (<!>) = List.map
    let (<*>) = List.apply
    (+) <!> ["bam"; "kapow"; "zap"] <*> ["!"; "!!"]

batman |> printfn "%A"