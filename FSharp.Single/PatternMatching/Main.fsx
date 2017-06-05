type Vector(x : float, y : float) =
    member this.X = x
    member this.Y = y
    new(v : Vector, s) = 
        Vector(v.X * s, v.Y * s)
    new(s: string, k: string) =
        ()

printfn "%A" (1 + 1)