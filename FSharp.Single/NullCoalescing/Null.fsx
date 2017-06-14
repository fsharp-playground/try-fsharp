open System

[<AutoOpen>]
module NC = 
    let inline private defaultObject input value = 
        if isNull input then value else input

    let inline private defaultNullable (input: 'a Nullable) value = 
        if input.HasValue then input.Value  else value

    let inline private defaultOption (input: 'a option) value = 
        if input.IsSome then input.Value else value

    type NullCoalescing = NC with
        static member (|?) (_, x: 'a) = defaultObject x
        static member (|?) (_, x: 'a Nullable) = defaultNullable x
        static member (|?) (_, x: 'a option) = defaultOption x

    let inline (|?) d1 d2 = NC |? d1 <| d2

let n = Unchecked.defaultof<string>

n |? n |? n |? n |? "Apple"
|> printfn "%A"    // "Apple"
new (DateTime Nullable) () |? DateTime.MaxValue 
|> printfn "%A"    // 12/31/9999 11:59:59 PM
None |? Some("Apple")                          
|> printfn "%A"    // Some "Apple"


