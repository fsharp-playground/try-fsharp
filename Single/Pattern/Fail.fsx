
let (|Fail|) s v = failwith s
let getAge (Some age | Fail "Age is missing!" age) = age


let getAge2 = function
   | Some age | Fail "Age is missing" age -> age

let a: int = getAge (None) 