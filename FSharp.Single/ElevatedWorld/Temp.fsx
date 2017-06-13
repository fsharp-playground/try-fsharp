let parseInt str  =
    match str with
    | "-1"  -> Some -1
    | "0"   -> Some 0
    | "1"   -> Some 1
    | "2"   -> Some 2
    | _     -> None

type OrderQty = OrderQty of int

let toOrderQty qty= 
    if qty >= 1 then
        Some (OrderQty qty)
    else
        None


parseInt "1"
|> Option.bind toOrderQty
|> printfn "%A"

parseInt "1"
>>= toOrderQty
|> printfn "%A"
