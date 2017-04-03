

module A = 
    let f1 xOpt =
        match xOpt with
        | Some x when x >= 0. -> Some (sqrt x)
        | _ -> None

    let f2 = Option.map sqrt << Option.filter ((<=) 0.)

    let filter = (Option.map sqrt) << Option.filter ((<=) 0.)

    f2 (Some 4.) |> printfn "%A"


//

module B = 
    let pair = (1,2)
    let x = pair |> fst

    let p13 (x,_,_) = x
    let p23 (_,x,_) = x
    let p33 (_,_,x) = x

    let le1 = List.exists (p23 >> (=) 3) [(1,3,3)]
    printfn "%A" le1

module C = 
    let pair = (1,2)
    let x, _ = pair
    List.exists (fun (_,y,_) -> y = 3) [(1,2,3)]

module D  =
    let flip f = fun x y -> f y x
    let x = List.filter ((=) 0 << flip (%) 2)
    x [1;2;3;4;5] |> printfn "%A"



