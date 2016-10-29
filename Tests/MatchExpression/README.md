## test.fsx

```fsharp


let (|Fail|) s v = failwith s

let getAge2 = function
    | Some age | Fail "Age is missing" age -> age

let getAge(Some age | Fail "Age is missing" age) = age

let (|Odd|Even|) i =
    match i % 2 with
    | 0 -> Even i
    | x -> Odd i

let check i =
    match i with
    | Even i -> sprintf "%i is even nunber" i
    | Odd i -> sprintf "%i is odd number" i

let check2(_ | _) = ()



```