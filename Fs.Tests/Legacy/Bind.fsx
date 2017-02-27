
let (>>=) m f = f m
1 >>= (+) 2 >>=  (*) 42 >>= id |> printfn "%A"

