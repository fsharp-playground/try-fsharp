

module  M1 = 

    type Vector = 
        val mutable X : int
        val mutable Y : int 
        new() = { X = 0; Y = 0 }

    let v = Vector()
    v.X <- 100
    v.Y <- 100


module M2 = 
    [<Struct>]
    type Vector2 =
        val mutable public x : int
        val mutable public y : int

    let mutable v2 = Vector2()
    v2.x <- 10
    v2.y <- 10


module M3 = 
    type Vector(x : float, y : float) =
        member private this.X = x
        member this.Y = y
        new(v : Vector, s) = Vector(v.X * s, v.Y * s)
    // Usage:
    let v = Vector(10., 10.)
    let w = Vector(v, 0.5)


module M4 = 
    type Vector(x : float, y : float) =
      member this.Scale(s : float) =
        Vector(x * s, y * s)
    // Usage:
    let v = Vector(10., 10.)
    let v2 = v.Scale(0.5)


module M5 = 

    type Factory<'T>(f : unit -> 'T) =
        member this.Create() =
            f()
    // Usage:
    let strings = Factory<string>( fun () -> "Hello!")

    let res = strings.Create()
    let ints = Factory<int>(fun () -> 10)
    let resk = ints.Create()


module M6 =

    type BarkArgs(msg:string) =
        inherit System.EventArgs()
        member this.Message = msg
    type BarkDelegate =
        delegate of obj * BarkArgs -> unit
    type Dog() =
        let ev = Event<BarkDelegate, BarkArgs>()
        member this.Bark(msg) =
            ev.Trigger(this, BarkArgs(msg))
        [<CLIEvent>]
        member this.OnBark = ev.Publish
    // Usage:
    let snoopy = Dog()
    snoopy.OnBark.Add( fun ba -> printfn "%s" (ba.Message))
    snoopy.Bark("Hello")

    