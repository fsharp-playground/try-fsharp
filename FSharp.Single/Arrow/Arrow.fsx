open System

type App<'F, 'T> private (value : obj) =
    private new(token : 'F, value : obj) = 
        if Object.ReferenceEquals(token, Unchecked.defaultof<'F>) then
            raise <| new System.InvalidOperationException("Invalid token")
        App<'F, 'T>(value)
    private new(token : 'F) = App<'F, 'T>(token, null) 
    // Apply the secret token to have access to the encapsulated value
    member self.Apply(token : 'F) : obj =
        if Object.ReferenceEquals(token, Unchecked.defaultof<'F>) then
            raise <| new System.InvalidOperationException("Invalid token")
        value 
    static member Create<'F, 'T>(token : 'F, value : obj) = new App<'F, 'T>(token , value)
    static member Create<'F, 'T>(token : 'F) = new App<'F, 'T>(token)

type App2<'F, 'T1, 'T2> = App<App<'F, 'T1>, 'T2>

/// Category Class
[<AbstractClass>]
type Category<'F>() =
    abstract Ident<'A> : unit -> App2<'F, 'A, 'A>
    abstract Compose<'A, 'B, 'C> : App2<'F, 'A, 'B> -> App2<'F, 'B, 'C> -> App2<'F, 'A, 'C>

[<AbstractClass>]
type Arrow<'F>() =
  inherit Category<'F>()
    abstract Arr : ('A -> 'B) -> App2<'F, 'A, 'B>
    abstract First : App2<'F, 'A, 'B> -> App2<'F, 'A * 'C, 'B * 'C>
    member self.MapIn (f : 'C -> 'A) (ab : App2<'F, 'A, 'B>) : App2<'F, 'C, 'B> =
      self.Compose (self.Arr f) ab
    member self.MapOut (f : 'B -> 'C) (ab : App2<'F, 'A, 'B>) : App2<'F, 'A, 'C> =
      self.Compose ab (self.Arr f)
    member self.Second (ab : App2<'F, 'A, 'B>) : App2<'F, 'C * 'A, 'C * 'B> =
      let swap (a,b) = b,a in
      self.First ab |> self.MapIn swap |> self.MapOut swap
    member self.Split (a : App2<'F, 'A, 'B>) (b : App2<'F, 'C, 'D>) : App2<'F, 'A * 'C, 'B * 'D> =
      self.First a |> self.Compose (self.Second b)
    member self.Fanout (a : App2<'F, 'A, 'B>) (b : App2<'F, 'A, 'C>) : App2<'F, 'A, 'B * 'C> =
      self.Split a b |> self.MapIn (fun a -> a,a)