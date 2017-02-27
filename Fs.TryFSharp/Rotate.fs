module Rotate

open FsUnit
open NUnit.Framework
open System.IO

// test f# 4.0 constructor
type A(p1, p2) =
    member val F1:string = p1
    member val F2:string = p2

// test generic propery
type GA<'a>(p1:'a) =
    member val F1:'a = p1
    member this.F2<'b> (b:'b) = ()

[<Test>]
let ``Constructors as First-Class Functions``() =
    let up1 (a:A) = a.F1.ToUpper()
    ("Abc", "Abc") |> A |> up1 |> should equal "ABC"

    let f1 (a:GA<'a>) = a.F1;
    "Text"  |> GA |> f1 |> should equal "Text"
    1       |> GA |> f1 |> should equal 1
    ()      |> GA<obj> |> f1 |> should equal ()
    
    let ga = 5.5 |> GA
    1000 |> ga.F2 |> should equal ()
    //"xx" |> ga.F2<obj> |> should equal ()

    "../../AssemblyInfo.fs" |> FileInfo |> fun f -> f.Extension |> should equal ".fs"

(*
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

*)