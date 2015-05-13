namespace Tester

open System
open AutoMapper
open FsUnit
open Xunit
open NLog
open FsUnit
open NUnit.Framework
open System
open System.Reflection

type A() = member val FA = 0 with set,get
type B() = member val FB = 0 with set,get

type LanguageSpec() =
    member this.GenericF<'R>(t: int): 'R =
        let tr = typeof<'R>
        let rs = Activator.CreateInstance(tr) :?> 'R
        match tr.Name with
        | "A" -> tr.GetProperty("FA").SetValue(rs, t * 2)
        | "B" -> tr.GetProperty("FB").SetValue(rs, t * 2)
        | _ -> ()
        rs

    [<Fact>]
    member this.ShowForwardToGenericF() =
        let fa:int -> A = this.GenericF
        let fb:int -> B = this.GenericF
        (fa 10).FA |> should equal 20
        (fb 20).FB |> should equal 40

    [<Fact>]
    member this.ShouldEvaluateOperatorsAsFunction() =

        (=) 1 1 |> should equal true
        (<>) 1 1 |> should equal false
        (%) 5 2 |> should equal 1

        1 |> (=) 1 |> should equal true
        1 |> (<>) 1 |> should equal false
        2 |> (%) 5 |> should equal 1

        let (!) = (<>)
        1 |> (!) 1 |> should equal false

        let eq a b = a = b
        1 |> eq 1 |> should equal true
        1 |> eq 0 |> should  equal false

    member this.Bar<'T> (arg0:string) : 'T = 
        Unchecked.defaultof<'T>


    member this.GenericFunc<'T,'R> (p:'T): 'T * 'R * Type =
        p, Unchecked.defaultof<'R>, typeof<'R>

    member this.GenericFn<'T, 'R> (p: 'T) : 'R =
        Unchecked.defaultof<'R>

    [<Fact>]
    member this.ShouldForwardToGenericFn() =
        let fs = (this.GenericFn : _ -> string) 
        let fi = (this.GenericFn : _ -> int)
        let fb = (this.GenericFn : _ -> bool)
        "hello" |> fs |> should equal null
        "hello" |> fi |> should equal 0
        "hello" |> fb |> should equal false

        let f:string->string*string*Type = this.GenericFunc
        let f:string->string*'R*Type = this.GenericFunc
        //let result:string*string*Type = "Hello" |> f 
        //result |> should equal ("Hello", null, typeof<string>)
        ()

    [<Fact>]
    member this.ShouldForwardToGeneraticFunc() =
        ("string", null, typeof<String>) |> should equal ("string", null, typeof<string>)

        //"string" |> (this.GenericFunc : _ -> string * string * Type) |> should equal ("string", null, typeof<string>)
        //let f = (this.GenericFunc: _ -> string * string * Type)
        //"string" |> f |> should equal ("string", None, typeof<string>)

    [<Fact>]
    member this.ShouldForwardToGenericFunction() =

        "Hello" |> fun x -> this.GenericFunc<string, int> x |> should equal ("Hello", 0, typeof<int>)
        "Hello" |> this.GenericFunc |> should equal ("Hello", null, typeof<obj>)
        "string" |> (this.Bar : _ -> Int32) |> should equal 0
        "string" |> (this.GenericFunc : _ -> string * int * Type) |> should equal ("string", 0, typeof<int>)