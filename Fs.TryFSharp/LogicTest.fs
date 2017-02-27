
module LogicTest

open FsUnit
open Xunit
open System.Diagnostics
open NLog

let logger = LogManager.GetCurrentClassLogger()

[<Fact>]
let X() =

    let inline replace1 list a b = list |> Seq.map (fun x -> if x = a then b else x)
    let inline replace2 list func = list |> Seq.map func
    let cp a b = 
        logger.Info(a.ToString());
        logger.Info(b.ToString());
        a.ToString() = b.ToString(); 

    let r1 = replace1 "hello, how are you?" 'e' 'a' |> cp "hallo, how ara you?"
    let r2 = replace1 [1;2;3;4;5;4;3;2;1] 3 9  |> cp [1;2;9;4;5;4;9;2;1]

    let r3 = replace2 "hello, how are you?" (fun x -> if x = 'e' then 'a' else x) |> cp "hallo, how ara you?"
    let r4 = replace2 [1;2;3;4;5;4;3;2;1] (fun x -> if x = 3 then 9 else x) |> cp [1;2;9;4;5;4;9;2;1]

    r1 |> should equal true
    r2 |> should equal true
    r3 |> should equal true
    r4 |> should equal true
   

[<Fact>]
let Transform() =
    let inline replace1 list a b = list |> Seq.map (fun x -> if x = a then b else x)
    let inline replace2 list func = list |> Seq.map func

    let inline m3 tr el time = 
        let mv = tr el 
        if mv = el then [el] else [for x in 1..time -> mv]
    let inline replace3 list tr time =  
        let db = List.foldBack(fun el acc -> (m3 tr el time)::acc) list [];
        [for x in db do yield! x]

    replace1 "hello, how are you?" 'e' 'a' |> should equal "hallo, how ara you?"
    replace1 [1;2;3;4;5;4;3;2;1] 3 9 |> should equal [1;2;9;4;5;4;9;2;1]

    replace2 "hello, how are you?" (fun x -> if x = 'e' then 'a' else x) |> should equal "hallo, how ara you?"
    replace2 [1;2;3;4;5;4;3;2;1] (fun x -> if x = 3 then 9 else x) |> should equal  [1;2;9;4;5;4;9;2;1]
    
    replace3 (List.ofSeq "hello, how are you?") (fun x -> if x = 'e' then 'a' else x)  3 |> should equal "haaallo, how araaa you?"
    replace3 [1;2;3;4;5;4;3;2;1] (fun x -> if x = 3 then 9 else x) 3 |> should equal [1;2;9;9;9;4;5;4;9;9;9;2;1] 

type NestedType<'a> = List of NestedType<'a> list | E of 'a

[<Fact>]
let ``Flat``() =
    let flatten ls =
        let rec start temp input = 
            match input with
            | E e -> e::temp
            | List es -> List.foldBack(fun x acc -> start acc x) es temp
        start [] ls

    // (a (b (c d) e)))
    (List [E "a"; List [E "b" ; List [E "c";  E "d"]; E "e"]]) |> flatten = ["a";"b";"c";"d";"e";]

[<Fact>]
let ``Test Join``() =
    let a = [1;2;3]
    let y = List.fold (fun acc el -> [for i in 1..3 -> el]::acc)  [] a
    [for x in y do yield! x] |> should equal 10;


[<Fact>]
let ``Fold back``() =
    let x = [1;2;3;4]
    let y = List.foldBack (fun e acc -> e::acc) x []
    y |> should equal [1;2;3;4]

type Hello<'a> = List of Hello<'a> list

[<Fact>]
let ``Hello world``() =
    let x = (List [])
    let y = match x with 
            | List xs -> [100]
    
    y |> should equal [100]

