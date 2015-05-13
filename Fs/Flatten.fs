module Flatten

open System.Linq
open FsUnit
open Xunit

// Consider two distinct interfaces
type IA = interface end
type IB = interface end

// And two classes that implement both of the interfaces
type First() = 
  interface IA
  interface IB

type Second() = 
  interface IA
  interface IB

// Now, what implicit upcast should the compiler insert here?
// The return type could be either IA, IB or obj, but there is 
// no _unique_ solution.
//
// (This is an error in F# and it cannot be easily fixed by 
// trying to identify the most specific common supertype, because
// there is no single common supertype)

// Error, This expression was expected to have type First  but here has type Second
let test1 = 
//    if 1 = 1 then First() else Second()
    ()

let test2:_ =
//    if 1 = 1 then First() else Second()
    ()

// Error, This expression was expected to have type obj but here has type First/Second
let test3:obj = 
//    if 1 = 1 then First() else Second() 
    "" :>_

// Ok, The cast will be determined by the compiler, because of _
let test4:obj =
    if 1 = 1 then First() :> _
    else Second() :> _

// Ok, Explicit upcast to obj.
let test5 =
    if 1 = 1 then First() :> obj
    else Second() :> obj

// Ok
// Passing argument to a function or a method.
// The compiler knows what upcast to insert.
[<Fact>]
let test6() =
    let getType args = args.GetType()
    First() |> getType |> should equal typeof<First>
    Second() |> getType |> should equal typeof<Second>

    let first (items:seq<'a>) = items |> Seq.head
    first [|"a";"b"|] |> should equal "a"
    first ["a";"b"]   |> should equal "a"
    first (Enumerable.Range(1, 100))  |> should equal 1

// Original
type 'a NestedList = List of 'a NestedList list | Elem of 'a
let flatten ls = 
    let rec loop acc = function 
        | Elem x -> x::acc
        | List xs -> List.foldBack(fun x acc -> loop acc x) xs acc
    loop [] ls

// New Version 
type MyNestedList<'a> = List of MyNestedList<'a> list | Elem of 'a
let newFlatten ls = 
    let rec loop acc input = 
        match input with
        | Elem x -> x::acc
        | List xs -> List.foldBack(fun x acc -> loop acc x) xs acc
    loop [] ls


/// http://www.fssnip.net/an
/// > flatten (Elem 5);;
/// val it : int list = [5]
/// > flatten (List [Elem 1; List [Elem 2; List [Elem 3; Elem 4]; Elem 5]]);;
/// val it : int list = [1;2;3;4;5]
/// > flatten (List [] : int NestedList);;
/// val it : int list = []

