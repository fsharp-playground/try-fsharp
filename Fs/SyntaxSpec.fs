module SyntaxSpec

open NUnit.Framework
open AutoMapper
open System
open System.Reflection
open System.Runtime.Serialization
open System.Collections.Generic

open FsUnit
open Xunit

[<Fact>]
let SoundSig() =
//    let asr = 100
//    let land = 100
//    let lor = 100
//    let lsl = 100
//    let lsr = 100
//    let lxor = 100
//    let mod = 100
//    let sig = 100

//    let process = 100;
    ()

[<Fact>]
let ``Compress a Sequence``() =

    let compress = function
        | [] -> []
        | ls -> List.fold (fun (acc:list<'a>) e -> if acc.Head = e then acc else e::acc) [ls.Head] ls.Tail |> List.rev

    [] |> compress |> should equal []
    [1; 1; 2; 3; 3; 3; 2; 2; 3] |> compress |> should equal  [1; 2; 3; 2; 3]
    [[1; 2]; [1; 2]; [3; 4]; [1; 2]] |> compress |> should equal  [[1; 2]; [3; 4]; [1; 2]]
    "Leeeeeerrroyyy" |> List.ofSeq |> compress |> should equal "Leroy"


type NestedType<'a> = List of NestedType<'a> list | Element of 'a

[<Fact>]
let ``Flatten 99``() =
    let flatNestedType ls =
        let rec start temp input =
            match input with
            | Element e -> e::temp
            | List es -> List.foldBack(fun x acc -> start acc x) es temp
        start [] ls

    (Element 5) |>  flatNestedType |> should equal [5]
    (List [Element 1; List [Element 2; List [Element 3; Element 4]; Element 5]]) |> flatNestedType |> should equal [1;2;3;4;5]
    (List []) |> flatNestedType |> should equal []

///
/// > flatten (Elem 5);;
/// val it : int list = [5]
/// > flatten (List [Elem 1; List [Elem 2; List [Elem 3; Elem 4]; Elem 5]]);;
/// val it : int list = [1;2;3;4;5]
/// > flatten (List [] : int NestedList);;
/// val it : int list = []

(*[omit:(Solution 1)]*)
(*
let flatten ls =
    let rec loop acc = function
        | Elem x -> x::acc
        | List xs -> List.foldBack(fun x acc -> loop acc x) xs acc
    loop [] ls
*)
(*[/omit]*)


[<Fact>]
let ``Flatten``() =
    //(a (b (c d) e)))
    let l = ("A", ("B", ("C", "D"), "E"))
    // let l = [|"A"; [|"B"; [|"C"; "D"|] |]; "E"|]; |]
    // klet l:list<obj> = ["A"; ["B"; ["C"; "D"]]; "E"]


    ()

[<Fact>]
let ``Palindrome``() =
    let inline palindrome l = List.rev l = l

    [1;2;3;4;5] |> palindrome |> should equal false;
    ["r"; "a"; "c"; "e"; "c"; "a"; "r"] |> palindrome |> should equal true;
    [1; 1; 3; 3; 1; 1] |> palindrome |> should equal true;

    //1, 2, 3, 4, 5] => false
    //["r", "a", "c", "e", "c", "a", "r"] => true
    //[1, 1, 3, 3, 1, 1] => true


[<Fact>]
let ``Other F# Operators``() =
    let f1 p1 = p1
    let f2 p1 p2 = p1 + p2
    let f3 p1 p2 p3 = p1 + p2 + p3

    let fn1 n = n * n
    let fn2 n = n + n

    let fn12 = fn1 >> fn2 // composes two functions.
    let fn21 = fn1 << fn2 // composes two functions with reverse order.

    f1 <| 1 |> should equal 1
    f2 <|| (1, 1) |> should equal 2
    f3 <||| (1, 1, 1) |> should equal 3

    (1, 1) ||> f2 |> should equal 2
    (1, 1, 1) |||> f3 |> should equal 3

    fn12 1 |> should equal 2
    fn21 1 |> should equal 4

type IA =
    abstract member F: int with get,set

[<Test>]
let ``Object Expression``() =

    let expression =
        let dataStore = ref 9
        {
            new IA with
                member this.F
                    with get() = !dataStore
                    and set(v) = dataStore := v
        }

    expression.F |> should equal 9;


type IB =
    abstract B : int

type A() =
    interface IB with
        member this.B = 1

[<Test>]
let ``TypeInfo``() =

        let test (x) = x * x

        let fix (x: #IB) =
            test x.B

        let a = A()
        let aa = [|a; a|]

        aa |> Array.map fix |> should equal [|1;1|]
        [|a|] |> Array.map fix  |> should equal [|1|]

type IAnimal =
    abstract member Roar:unit -> String

[<AbstractClass>]
type Human() =
    abstract member Roar:unit -> String

type Dog() =
    interface IAnimal with
        member this.Roar() = "DEE"
    member this.Run() = "..."

type Cat() = member this.Roar() = "CEE"
type Bird() = member this.Fly() = "^^^"

type Sumo() =
    inherit Human()
    override this.Roar() = "SEE"

[<Test>]
let ``Can Restrict Parameter Type With Generic Constraint``() =

    let inline roar animal =
        (^A : (member Roar : unit -> string) animal)

    let inline roar2 (animal: ^A when ^A : (member Roar:unit -> string)): string  =
        // this ok
        (^A : (member Roar : unit -> string) animal)
        //animal.Roar()

    let inline run animal =
        (^A : (member Run : unit -> string) animal)

    Dog() |> run |> should equal "..."
    Dog() :> IAnimal |> roar |> should equal "DEE"
    Cat() |> roar |> should equal "CEE"
    Sumo() |> roar |> should equal "SEE"

    // Ok, does not compile
    // Bird() |> roar |> should equal "..."

let inline inlineAdd a b = a + b
let add a b = a + b
let lpAdd<'a, 'b, 'c> (a:'a) (b:'b): 'c =
     LanguagePrimitives.AdditionDynamic<'a, 'b, 'c> a b

//let addNumber (a:^A ) (b:^A) : ^A  when ^A : (static member op_Addition : ^A) =
//    a + b

//let (++): a: ^a -> b: ^b ->  ^c
//    when ( ^a or  ^b) : (static member ( + ) :  ^a *  ^b ->  ^c) = (fun x y -> 0)

[<Test>]
let ``Can Use Generic Type With Inline Function``() =

    inlineAdd 1 2  |> should equal 3
    inlineAdd 1. 2. |> should equal 3.
    inlineAdd "a" "b" |> should equal "ab"

    add 1 2  |> should equal 3
//    lpAdd 1 2 |> should equal 3
//    lpAdd 1. 2. |> should equal 3.
//    lpAdd "a" "b" |> should equal "ab"

    // expected int
    // add 1. 2. |> should equal 3.
    // add "a" "b" |> should equal "ab"

let fb number =
    match number % 3, number % 5 with
    | 0, 0 -> "FizzBuzz"
    | 0, _ -> "Fizz"
    | _, 0 -> "Buzz"
    | _ -> number.ToString()

[<Test>]
let ``Can Play Fizz Buzz With Any Number``() =
    1  |> fb |> should equal "1"
    9  |> fb |> should equal "Fizz"
    10 |> fb |> should equal "Buzz"
    15 |> fb |> should equal "FizzBuzz"

type SType =
    struct
        val mutable A: int
    end

type RType  = {
    Z : int
    A : int
}

type CType() =
    member val A = 0 with get, set
    member val Z = 0 with get, set
    member val M = 0 with get, set

[<Test>]
let ``Can Initialize Object Via Parameter Constructor``() =
    let rType = typeof<RType>
    let rProperties = rType.GetProperties()

    let cType = typeof<CType>
    let cProperties = cType.GetProperties()
    let cInstance = new CType(A = 200, Z = 100)

    let cValue (name, propertyType:Type) =
        let p = cProperties |> Seq.tryFind (fun x -> x.Name = name)
        match p with
        | Some x -> Some(x.GetValue(cInstance))
        | _ -> if propertyType.IsValueType then
                Some(Activator.CreateInstance(propertyType)) else None

    let ctorParams = rProperties |> Seq.map (fun x -> cValue(x.Name, x.PropertyType).Value)
    let rInstance = Activator.CreateInstance(rType, Seq.toArray ctorParams) :?> RType
    rInstance.A |> should equal 200
    rInstance.Z |> should equal 100

[<Test>]
let ``Can Initialize Object Via Constructor``() =
    let s = SType()
    let c = CType(Z = 100, A = 200)

    // constructor 'RType' is not defined
    // let r = RType()

    Mapper.CreateMap<CType,RType>() |> ignore
    let r = Mapper.Map<RType>(c)

    Object.ReferenceEquals(c, r) |> should equal false
    r.GetType() |> should equal typeof<RType>
    r.Z |> should equal 100
    r.A |> should equal 200

    // no parameterless constructor
    // let ins = Activator.CreateInstance<RType>()

    let fr = FormatterServices.GetUninitializedObject(typeof<RType>) :?> RType
    fr.Z |> should equal 0

[<Test>]
let ``Can Map Value From CType To (RS)Type``() =
    let c = CType(A = 100)

    Mapper.CreateMap<CType, RType>() |> ignore
    let r = Mapper.Map<CType, RType>(c)
    r.A |> should equal 100

    Mapper.CreateMap<CType, SType>() |> ignore
    let s = Mapper.Map<CType, SType>(c)
    s.A |> should equal 100
