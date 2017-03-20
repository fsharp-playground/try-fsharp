let reduce<'a> func (input: 'a list ) =
    let rec cal op l s =
        match l with
        | [] -> s
        | h:: t -> 
            let result = op h s
            cal op t result

    match input.Length > 1 with
    | true ->
        let h = input.Head
        let t = input.Tail
        let first = h
        let second = t.Head
        cal func t.Tail (func first second)
    | false
        -> failwith "Invalid input"

let x = [1;2;3]
x |> reduce (+) |> printfn "%A"
x |> reduce max |> printfn "%A"
x |> reduce min |> printfn "%A"

let y = ["Hello"; "world"]
y |> reduce (+) |> printfn "%A"