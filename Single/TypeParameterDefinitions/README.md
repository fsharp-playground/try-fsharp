## Main.fsx

```fsharp
type R() = class
    end

let t1 (x: #R) = ()
let t2 (x: R) = ()
```