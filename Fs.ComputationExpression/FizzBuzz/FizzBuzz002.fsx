type FB<'T> = FB of 'T 

let inline (>>=) (FB (x, y)) f : FB<'b> = f (x,y) 
let fbreturn x = FB x

type FizzBuzzBuilder () =
  member this.Return (x) = fbreturn x
  member this.Bind (m,f) = m >>= f