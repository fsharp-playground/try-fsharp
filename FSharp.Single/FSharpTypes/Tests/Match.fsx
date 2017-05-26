
let (|Float|_|) input = 
    let ok, rs = System.Double.TryParse input
    if ok then Some rs else None
let (|Date|_|) input = 
    let ok, rs = System.DateTime.TryParse input
    if ok then Some rs else None

let rs = 
    match "2015/05/05" with
    | Float x -> "Float"
    | Date k -> "Date"
    | otherwise -> "Other"

printfn "%A" rs


[<CompiledName("F1")>]
let f1 = 1 + 1

let [<CompiledName("F2")>] f2 = 2 + 2



