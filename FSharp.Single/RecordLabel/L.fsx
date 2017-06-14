
type R = { Number : int }

let data = [ for i in 1..10 do yield { Number = i } ]

let Number ({ Number = n }) = n

data 
|> List.filter (fun x -> 5 > x.Number) 
|> printfn "%A"

data 
|> List.filter ( (>) 5 << Number)       
|> printfn "%A"


