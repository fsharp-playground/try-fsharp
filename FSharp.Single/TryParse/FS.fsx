open System

let stringValue = "100"
let success, intValue = Int32.TryParse stringValue

let mutable dt2 = System.DateTime.Now
let b2 = System.DateTime.TryParse("12-20-04 12:21:00", &dt2)



match Int32.TryParse stringValue with
| (true, value) ->
    printfn "Value is %d" value
| otherwise ->
    printfn "Not int"
