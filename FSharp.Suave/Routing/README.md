
## Main.fsx

```fsharp
#r "../../packages/Suave/lib/net40/Suave.dll"

open Suave
open Suave.Files
open Suave.Operators
open Suave.Successful

let requiresAuthentication _ =
    choose
        [ GET >=> path "/public" >=> OK "Default GET"
          // Access to handlers after this one will require authentication
          Authentication.authenticateBasic 
            (fun (user,pwd) -> user = "foo" && pwd = "bar") 
            (choose [
                GET >=> path "/whereami" >=> OK (sprintf "Hello authenticated person ")
                GET >=> path "/" >=> dirHome
                GET >=> browseHome // Serves file if exists 
             ])]


let app =
    choose
        [ GET >=> choose 
            [ path "/hello" >=> OK "Hello GET"
              path "/goodbye" >=> OK "Good bye GET" ]
          POST >=> choose
            [ path "/hello" >=> "Hello POST"
              path "/goodbye" >=> OK "Good bye POST" ] ]

startWebServer defaultConfig app
```
