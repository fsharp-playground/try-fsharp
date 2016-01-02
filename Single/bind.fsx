
let (>>=) m f =
    printfn "expression is %A" m
    f m

1 >>= (+) 2 >>=  (*) 42 >>= id |> printfn "%A"

