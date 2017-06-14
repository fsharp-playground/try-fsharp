open System

let inline (^<|) f a = f a

{ 1..5 } |> Seq.map (fun x -> x + 3)     |> printfn "%A"
let x = { 1..5 } |> Seq.map ^<| fun x -> x + 3


let inline (|?) input value = 
    if isNull input then value else input
let inline (|??) (input: 'a Nullable) value = 
    if input.HasValue then input.Value  else value
let inline (|???) (input: 'a option) value = 
    if input.IsSome then input.Value else value

Unchecked.defaultof<string> |? "Apple"           
|> printfn "%A"    // "Apple"
new (DateTime Nullable) () |?? DateTime.MaxValue 
|> printfn "%A"    // 12/31/9999 11:59:59 PM

