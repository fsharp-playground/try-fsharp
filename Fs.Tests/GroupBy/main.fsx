open System.Linq
type Data = {
    X: int
    Y: int
}
let datas = [ { X = 100; Y = 200 }]

printfn "%A" <| datas.GroupBy(fun x -> "")
