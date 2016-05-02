let (|Fail|) s v = failwith s
let getAge (Some age | Fail "Age is missing!" age) = age

let a = getAge(Some 10)
let b = getAge(None)




let c = getAge(None) |> sprintf "%A"
let d : int option = getAge(None)
