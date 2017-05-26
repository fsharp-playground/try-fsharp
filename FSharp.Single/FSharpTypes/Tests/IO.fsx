
type IO<'a> = IO of (unit -> 'a)

let runIO (IO f) = f()

let getLine = IO(fun() -> System.Console.ReadLine())
