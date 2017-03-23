
## Main.fsx

```fsharp
#r "../../packages/Expecto/lib/net40/Expecto.dll"

open Expecto

type Maybe<'a> =
    | Just of 'a
    | Nothing

// lift
let fmap f v =
    match v with
    | Just x -> Just (f x)
    | Nothing -> Nothing

let return' v = Just v
let bind v f =
    match v with
    | Just x -> f x
    | Nothing -> Nothing

let (>>=) = bind

type MaybeBuilder() =
    member x.Bind(v,f) = bind v f
    member x.Return(v) = return' v

let maybe = MaybeBuilder()
let result =
    maybe {
        let! x = Just 1
        let! y = Nothing
        return 5
    }

printfn "%A" result

let simpleTest =
     testCase "A simple test" <| fun () ->
        Expect.equal result Nothing "Nothing"

//error FS0193: internal error:
//runTests defaultConfig simpleTest

let test =
    testCase "Hello" <| fun () ->
        Expect.equal 1 1 "1 = 1"

//error FS0193: internal error:
//runTests defaultConfig test
```
