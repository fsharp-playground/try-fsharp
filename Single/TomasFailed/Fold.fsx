let lToS (l:char list) = System.String.Concat(Array.ofList(l))

let sumString =
    let parse (l:string) =
        let guessDelimeter (l:string) =
            match Seq.toList l with
                | '/'::'/'::c::'\n'::_ -> c
                | _ -> Seq.find (fun i -> i = ',' || i = '\n') l
        let valuePart = (fun (s:string) ->
            match Seq.toList s with
                | '/'::'/'::c::'\n'::r -> r
                | v -> v) >> lToS
        Array.map int ((valuePart l).Split(guessDelimeter l))
    (parse >> Array.fold (fun acc i -> acc + i ) 0)

 sumString "3,9,11"
 sumString "3\n9\n11"
 sumString "//;\n3;9;11"
