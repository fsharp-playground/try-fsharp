let x = (Array.choose (fun x -> if x % 2 = 0 then Some (x/2) else None) [|0..100|] = [|0..50|])
printfn "%A" x

// Get Some and Ignore None
printfn "%A" (Array.choose (fun x -> if x = 1 then Some(x) else None) [|1;2;3|])

printf "%A" (Array.collect)

printfn "Hello, world!"