
let data = [7;0;0;0;1;1;1;1;]
let ones, others = data |> List.partition ((=) 1)

let a & b = 42

let (hd::tl, _) | ([] as tl, hd) = data, 42

let def(x, None | _, Some x) = x

let k = def (10, Some 100)
let j = def ("k", None)

printfn "ss %A" k
printfn "ss %A" j


let ss & kk = 42




