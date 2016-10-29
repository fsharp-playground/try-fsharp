## Main.fsx

```fsharp

let check = function
    | true -> Ok("ok")
    | false -> Error("error")

let rs = check(true)
let value = 
    match rs with
    | Ok rs -> rs 
    | Error err -> err 

value = "ok" |> printfn "%A"

```