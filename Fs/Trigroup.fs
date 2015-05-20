﻿module Trigroup

open NUnit.Framework
open FsUnit

(*
trigroup [1, 2, 3, 4, 5, 6] => [[nil, 1, 2], [1, 2, 3], [2, 3, 4], [3, 4, 5], [4, 5, 6], [5, 6, nil]]
trigroup [9, 8, 7, 6] => [[nil, 9, 8], [9, 8, 7], [8, 7, 6], [7, 6, nil]]
ถ้าภาษาไหนไม่มี nil/null (มีป่าวหว่า?) เอาแบบด้านล่างนี้ อันไหนก็ได้
*)


[<Test>]
let Trigroup() = 

    let drop n ls =
        None :: (ls |> List.map (fun x -> Some(x))) @ [None]
        |> List.skip n |> List.take (List.length ls)
    let tg ls = 
        List.zip3 (drop 0 ls) (drop 1 ls) (drop 2 ls) 
        |> List.map (fun (x,y,z) -> [ x;y;z ] |> List.filter (fun x -> x <> None) |> List.map Option.get)

    [1;2;3;4;5;6] |> tg |> should equal [[1;2;]; [1;2;3]; [2;3;4]; [3;4;5]; [4;5;6]; [5;6]]
    [9;8;7;6] |> tg |> should equal [[9;8]; [9; 8; 7]; [8; 7; 6]; [7; 6]]






        