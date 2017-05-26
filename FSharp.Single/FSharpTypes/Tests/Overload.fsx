
type Vector(x: float, y : float) =
    member this.X = x
    member this.Y = y
    static member (~-) (v: Vector) =
        Vector(-1.0 * v.X, -1.0 * v.Y)

    static member (*) (v: Vector, a) =
        Vector(a * v.X, a * v.Y)

let v1 = Vector(1.0, 2.0)
let v2 = v1 * 2.0
let v3 = - v2

printfn "%A" v1
printfn "%A" v2
printfn "%A" v3

