
## Main.fsx

```fsharp

#r "../../packages/Suave/lib/net40/Suave.dll"
#r "../../packages/Suave.Testing/lib/net40/Suave.Testing.dll"
#r "../../packages/Expecto/lib/net40/Expecto.dll"

open Suave
open Expecto
open Suave.Testing

testCase "Parsing a large multiplart form" <| fun x ->
    let res = 
        runWith (Ok "hi")
        |> req HttpMethod.POST "/" (Some contentByteArray)

    Expect.equal res "hi" "Should get the current result"
        


```
