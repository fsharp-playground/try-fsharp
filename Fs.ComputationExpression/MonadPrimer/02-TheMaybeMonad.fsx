open System

let addThreeNumbers() =
    let getNum msg =
        printf "%s" msg
        match Int32.TryParse (Console.ReadLine()) with
        | (true, n) when n >= 0 && n <= 100 -> Some(n)
        | _ -> None

    match getNum "#1:" with
    | Some x ->
        match getNum "#2:" with
        | Some y ->
            match getNum "#3:" with
            Some z -> Some(x + y + z)
            | None -> None
        | None -> None
    | None -> None

let addThreeNumbers2() =
    let bind(input, rest) =
        match Int32.TryParse(input()) with
        | (true, n) when n >= 0 && n <= 100 -> rest(n)
        | _ -> None

    let createMsg msg = fun () -> printf "%s" msg; Console.ReadLine()

    bind(createMsg "#1:", fun x ->
        bind(createMsg "#2:", fun y ->
            bind(createMsg "#3:", fun z ->
                Some(x + y + z))))