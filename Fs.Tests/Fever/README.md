
## test2.fsx

```fsharp
let (|Fail|) s v = failwith s

let getAge (Some age | Fail "Age is missing!" age)
    = age

getAge(Some 10)
getAge(None)

```
