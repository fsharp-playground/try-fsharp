﻿module Rotate

open FsUnit
open NUnit.Framework

[<Test>]
let FsRotate() =

    let slice step ls = 
        let input = ls |> List.ofSeq
        match step < 0 with
        | false -> List.splitAt step input |> fun (x,y)-> List.append y x
        | _ -> List.splitAt (List.length input + step) input |> fun (x,y) -> List.append y x

    let rotate step input =
        let  ls = input |> List.ofSeq
        List.fold (fun (s, c) e -> if s <> 0 then (s-1 , List.append c.Tail [e]) else (0, c)) (step, ls) ls
        |> fun (x,y) -> y |> List.ofSeq

    [1;2;3;4] |> rotate 1 |> should equal [2;3;4;1]
    "hello" |> rotate  2 |> should equal "llohe"

    [1;2;3;4] |> slice 1 |> should equal [2;3;4;1]
    "hello" |> slice 2 |> should equal "llohe"
    "negative ok" |> slice -2 |> should equal "oknegative "
