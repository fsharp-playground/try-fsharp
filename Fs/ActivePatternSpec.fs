

module ActivePatternSpec

open FsUnit
open NUnit.Framework

module Single = 
    let (|Remainder2|) x = x % 2
    let checkNumber = function
        | Remainder2 1 -> "even number"
        | Remainder2 2 -> "odd number"
        | _ -> "don't know"

    [<Test>]
    let shouldCheckNumber() =
        checkNumber 2 |> should equal "don't know"
        checkNumber 1 |> should equal "even number"

module Partail = 
    let (|LessThen10|_|) x = if x < 10 then Some x else None
    let (|Btw10And20|_|) x = if x >= 10 && x < 20 then Some x else None

    let checkNumber x = 
        match x with
        | LessThen10 a -> sprintf "less then 10, the value is %d" a
        | Btw10And20 a -> sprintf "between 10 and 20, the value is %d" a
        | _ -> sprintf "that's a big number %d" x

    [<Test>]
    let shouldCheckNumber() =
        checkNumber 20 |> should equal "that's a big number 20"

module Multicase =

    let (|Q1|Q2|Q3|Q4|) (date:System.DateTime) =
        let month = date.Month
        match month with
        |1|2|3 -> Q1 month
        |4|5|6 -> Q2 month
        |7|8|9 -> Q3 month
        |_ -> Q4 month

    let newYearResolution date =
        match date with
        | Q1 _ -> "read"
        | Q2 _ -> "write"
        | Q3 _ -> "execute"
        | Q4 _ -> "sleep"

    [<Test>]
    let shouldCheckResolution() =
        newYearResolution <| System.DateTime(2015,10,10) |> should equal "sleep"


 module Parameterize =
     let(|Divisible|_|) x y =
         if y % x = 0 then Some Divisible
         else None

     let f2 = function
         | Divisible 2 & Divisible 3 -> "divisible by 6"
         | _-> "other"

     [<Test>]
     let shouldDivideBy6() =
         f2 12 |> should equal "divisible by 6"
