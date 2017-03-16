
module ConstantPattern =
    let isEvenNumber x = x % 2 = 0
    let transformEvenToZero x =
        match isEvenNumber x with
        | true -> 0
        | false -> x
    let r = seq {0..100} |> Seq.sumBy transformEvenToZero

module UsingFunctionKeyWord =
    let matchSample x =
        match x with
        | 1 -> printfn "this is one"
        | 2 -> printfn "this is two"
        | 3 -> printfn "this is three"
        | _ -> printfn "other value"

    let functionSample = 
        function 
        | 1 -> printfn "this is one"
        | 2 -> printfn "this is two"
        | 3 -> printfn "this is three"
        | _ -> printfn "other value"

module TuplePattern =
    let orFunction (x,y) =
        match x, y with
        | true, true -> true
        | true, false -> true
        | false, true -> true
        | false, false -> false
    let orFunction2 (x, y) =
        match x, y with
        | false, false -> false
        | _ -> true

   
    let rs1 = orFunction (true, false) 
    let rs2 = orFunction (false, false)


    let f x =
        let dict = System.Collections.Generic.Dictionary()
        dict.[0] <- "0"
        dict.[1] <- "1"

        match dict.TryGetValue x with
        | true, v -> sprintf "found %A mapped to %A" x v
        | false, _ -> "cannot find"

module UsingListAndArrayPattern =
    let arrayLength array =
        match array with
        | [||] -> 0
        | [| _ |] -> 1
        | [| _; _|] -> 2
        | [| _; _; _|] -> 3
        | _ -> Array.length array


    let rec length list =
        match list with
        | head:: tail -> 1 + (length tail)
        | [] -> 0

    let rec lengthTail list acc =
        match list with
        | head::tail -> lengthTail tail (acc + 1)
        | [] -> acc


module PatternMatchingOfList =
    let list = [1;2;3;4]
    match list with
    | h0::h1::t -> printfn "tow element %A %A and tail %A" h0 h1 t
    | _ -> ()

    let obj = [box(1); box("a"); box('c')]
    match obj with
    | [:? int as i;
        :? string as str;
        :? char as ch] -> printfn "value are %A %A %A" i str ch
    | _ -> ()


module NullPattern =
    let extractOption x =
        match x with
        | Some x -> printfn "option has value %A" x
        | None -> printfn "option has no value"

    let toOption x =
        match x with
        | null -> None
        | _ -> Some x


module RecordAndIdentifierPattern =
    type Shape =
        | Circle of double
        | Triangle of double * double * double
        | Rectangle of double * double

    let getArea shape =
        match shape with
        | Circle r -> r * r * System.Math.PI
        | Triangle (x,y,z) -> 
            let s = (x + y + z) / 2.
            sqrt s * (s - x) * (s - y) * (s - z)
        | Rectangle(a,b) -> a * b


module RecordPattern =
    type Point2D = { x: float; y: float }

    let osOnXAxis p =
        match p with
        | { x = 0. ; y = _ } -> true
        | _ -> false


module CurrencyCalculation =
    type Currency =
        | USD of decimal
        | CAD of decimal

        with 
            static member (+) (x:Currency, y:Currency) =
                match x, y with
                | USD a, USD b -> USD(a+b)
                | CAD a, CAD b -> CAD(a+b)
                | _ -> failwith "cannot add different unit value"

            static member (-) (x:Currency, y:Currency) =
                match x, y with
                | USD a, USD b -> USD(a-b)
                | CAD a, CAD b -> CAD(a-b)
                | _ -> failwith "cannot add different unit value"


    try 
        printfn "result = %A" (USD 1M + USD 11M) 
        printfn "result = %A" (CAD 1M + CAD 11M)
        printfn "result = %A" (USD 1M + CAD 11M)

    with
        | _ as e -> printfn "%A" e


module MatchRecord =
    type MyRecord = { x:int list; y: string }
    type MyRecord2 = { xx: int; yy:string; z:int }

    let rr = { x = [100;200;300]; y = "aa" }
    let r0 = { x = [100;200;3]; y = "aa" }
    let r1 = { xx = 1; yy = "bb"; z = 9 }

    let rs = 
        match r1 with 
        | rr -> "a" 
        | _ -> "b"


    let rs2 =
        match r1 with
        | { xx = 2 } -> "match"
        | _ -> "no"


module AnoOrGroup =
    let testPoint2 point  =
        match point with
        | x, y & (0, 0) -> "origin point"
        | x, y & (0, _ | _, 0) -> "on axis"
        | _ -> "other"


module WhenGard =
    let testPoint tuple =
        match tuple with
        | x, y when x = y -> "on the line"
        | x, y when x > y -> "below the line"
        | _ -> "up the line"


module AsPattern =
    let testType(x:obj) =
        match x with 
        | :? float as f -> printfn "float value %f" f
        | :? int as i -> printfn "int value %d" i
        | _ -> printfn "type cannot process"


module ChoiceHelper =
    open System

    //let a:Choice<int,int> = Choice2Of2 1
    let a = Choice2Of2 88
    let b = Choice7Of7 "Hello world"

    let f x =
        match x with
        | Choice1Of2 e -> printfn "_value is %A" e
        | Choice2Of2 e -> printfn "value is %A" e
        //| Choice7Of7 e -> printfn "__value is %A" e

    f a


module SingleCaseActivePattern =
    let (| Remainder2 |) x = x % 2
    let checkNumber x =
        match x with
        | Remainder2 0 -> "even number"
        | Remainder2 1 -> "odd number"
        | _ -> "impossible"


module SingleCaseActivePatternAsFunction =
    open System.Collections.Generic

    let (|SafeDict|) (d: Dictionary<_,_>) = 
        if d = null then Dictionary<_,_>()
        else d

    let tryFind (SafeDict dic) key =
        if dic.ContainsKey key then
            Some dic.[key]
        else None

    let dic = Dictionary<int, int>()
    dic.Add(5, 10)

    let rs = tryFind dic 5


module PartialCaseActivePattern =
    let (|LessThen10|_|) x = if x < 10 then Some x else None
    let (|Btw10And20|_|) x = if x >= 10 && x < 20 then Some x else None

    let checkNumber2 x =
        match x with
        | LessThen10 a -> printfn "less then 10, the value is %d" a
        | Btw10And20 a -> printfn "beetween 10 and 20, the value is %d" a
        | _ -> printfn "that's a big number %d" x

module MulticaseActivePattern =
    let (|FirstQuarter|SecondQuarter|ThirdQuarter|FourthQuarter|) (date: System.DateTime) =
        let month = date.Month
        match month with
        | 1 | 2 | 3 -> FirstQuarter month
        | 4 | 5 | 6 -> SecondQuarter month
        | 7 | 8 | 9 -> ThirdQuarter month
        | _ -> FourthQuarter month