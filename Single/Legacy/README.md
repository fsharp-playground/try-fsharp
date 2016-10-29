## ActivePattern.fsx

```fsharp

open System.Collections.Generic
open System

let print k = printfn "%A" k

(* ---------------------------------------- *)
let (|LessThen10|_|) x = if x < 10 then Some x else None
let (|Between10And20|_|) x = if x > 10 && x < 20 then Some x else None

let (|Q1|Q2|Q3|Q4|) (date: DateTime) =
    let month = date.Month
    match month with
    | 1 | 2 | 3 -> Q1 month
    | 4 | 5 | 6 -> Q2 month
    | 7 | 8 | 9 -> Q3 month
    | _ -> Q4 month

let x =
    match DateTime.Now with
    | Q1 m -> print m
    | _-> print "_"

(* ---------------------------------------- *)

match 15 with
| LessThen10 x -> sprintf "%d less then 10" x
| Between10And20 x -> sprintf "%d bw 10 and 20" x
| _ -> "don't know"
|> print

(* ---------------------------------------- *)
let (|Remainder2|) x = x % 2

match 13 with
| Remainder2 1 -> "one"
| Remainder2 2 -> "two"
| _ -> "zero"
|> print

(* ---------------------------------------- *)
let (|SafeDict|) dict =
    if obj.ReferenceEquals(null, dict) then
        Dictionary<_,_>()
    else dict

let tryFind (SafeDict dict) key  =
    if dict.ContainsKey key then
        Some dict.[key]
    else None

let dict = Dictionary<string,string>()
tryFind dict "jw" |> print

```