
let go() : Result<string,string> =
    Result.Error("Eror")


let rs = go()

let msg = function
        | Error er -> "Error"
        | Ok x -> "OK"

msg rs |> printfn "%A"
