(* ----------------------- *)
let x = 42
let y = 43
let z = x + y
printfn "z: %A" z

(* ----------------------- *)
let x = 42 in
    let y = 43 in
        let z = x + y
printfn "z: %A" z

(* ----------------------- *)
let x = 100 in x + 100 |> ignore
printfn "x: %A" x

(* ----------------------- *)
42 |> (fun x ->
        43 |> (fun y ->
                x + y |> (fun z -> z))) |> printfn "%A"




