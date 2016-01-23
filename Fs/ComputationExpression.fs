module CompuationExpression

open NUnit.Framework
open FsUnit


type MyWriterFormat<'T>(fmt: string) =
    do printfn "%A" fmt
    member this.Value = fmt

let  myPrinter = MyWriterFormat

let createMyFormat() =
    let printer = myPrinter "Hello"
    printer.Value |> should equal "Hello"

    let hello = "Hello"
    let con = myPrinter hello
    con.Value |> should equal "Hello"

    let f = Printf.TextWriterFormat<int -> int -> int -> unit>("%d %d = %d")
    printfn f 10 10 20

[<Test>]
let printString() =
    let str = "Say %s" |> Printf.TextWriterFormat<_>
    printfn str "Hello" 


type MyCP() =
    member this.Combine(a, b) = 
        match a with 
        | Some _ -> a
        | None -> b

    member this.Delay(f) = f()
    member this.ReturnFrom(x) = x

[<Test>]
let shouldWriteCP() =

    let map1 = [ ("1","One"); ("2","Two") ] |> Map.ofList
    let map2 = [ ("A","Alice"); ("B","Bob") ] |> Map.ofList
    let map3 = [ ("CA","California"); ("NY","New York") ] |> Map.ofList

    let multiLookup key =
        match map1.TryFind key with
        | Some result1 -> Some result1   // success
        | None ->   // failure
            match map2.TryFind key with
            | Some result2 -> Some result2 // success
            | None ->   // failure
                match map3.TryFind key with
                | Some result3 -> Some result3  // success
                | None -> None // failure

    let cp = MyCP()
    let find key = 
        cp {
            return! map1.TryFind key
            return! map2.TryFind key
            return! map3.TryFind key
        }

    find "A" |> should equal (Some "Alice")


(* -------------------------- *)

let map1 = [ ("1","One"); ("2","Two") ] |> Map.ofList
let map2 = [ ("A","Alice"); ("B","Bob") ] |> Map.ofList
let map3 = [ ("CA","California"); ("NY","New York") ] |> Map.ofList

let multiLookup key =
    match map1.TryFind key with
    | Some result1 -> Some result1
    | None -> 
        match map2.TryFind key with
        | Some result2 -> Some result2
        | None ->
            match map3.TryFind key with
            | Some result3 -> Some result3
            | None -> None

type OrElseBuilder() =
    member this.Combine(a, b) = 
        match a with
        | Some _ -> a
        | None -> b

    member this.ReturnFrom(x) = x
    member this.Delay(f) = f()

[<Test>]
let shouldLookupWithCompatationExpression() =
    let builder = OrElseBuilder()

    let tryFind key = 
        builder {
            return! map1.TryFind key
            return! map2.TryFind key
            return! map3.TryFind key
        }

    tryFind "A" |> should equal (Some "Alice")
    tryFind "C" |> should equal None
        

[<Test>]
let shouldLookup() =
    multiLookup "A" |> should equal (Some "Alice")
    multiLookup "B" |> should equal (Some "Bob")
    multiLookup "C" |> should equal None

(* -------------------------- *)

type MaybeBuilder() = 
    
    member this.Bind(x, f) = 
        match x with
        | None -> None
        | Some x -> f x
    
    member this.Return(x) = Some x

[<Test>]
let shouldExecuteWithComputationExpression() = 

    let divideBy buttom top = 
        if buttom = 0 then None
        else Some <| top / buttom

    let maybe = MaybeBuilder()
    let divideByWorkflow init x y z = maybe { let! a = init |> divideBy x
                                              let! b = a |> divideBy y
                                              let! c = b |> divideBy z
                                              return c }
    divideByWorkflow 12 3 2 1 |> should equal (Some 2)
    divideByWorkflow 12 3 0 1 |> should equal None

(* -------------------------- *)

let divideByWorkflow init x y z = 

    let divideBy buttom top = 
        if buttom = 0 then None
        else Some <| top / buttom

    let a = init |> divideBy x
    match a with
    | None -> None
    | Some a' -> 
        let b = a' |> divideBy y
        match b with
        | None -> None
        | Some b' -> 
            let c = b' |> divideBy z
            match c with
            | None -> None
            | Some c' -> Some c'

[<Test>]
let shouldExecuteWorkflow() = 
    let good = divideByWorkflow 12 3 2 1
    let bad = divideByWorkflow 12 3 0 1
    good
    |> should equal
    <| Some 2
    bad |> should equal None


(* -------------------------- *)

type LoggingBuilder() = 
    let log p = printfn "expression is %A" p
    
    member this.Bind(x, f) = 
        log x
        f x
    
    member this.Return(x) = x

[<Test>]
let shouldLog() = 
    let logger = new LoggingBuilder()
    let loggedFlow = logger { let! x = 42
                              let! y = 43
                              let! z = x + y
                              return z }
    ()