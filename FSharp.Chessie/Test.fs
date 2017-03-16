module FSharpChessieTest

open System
open NUnit.Framework
open Chessie.ErrorHandling
open FsUnit

type Request = {
    Name: string
    Email: string
}

let validate1 input =
    if input.Name = "" then fail "Name must no be blank"
    elif input.Email = "" then fail "Emaiil mus not be blank"
    else ok input

let validate2 input =
    if input.Name.Length > 50 then fail "Name must not be longer then 50 chars"
    else ok input

let validate3 input =
    if input.Email = "" then fail "Email must not blank"
    else ok input

let combineValidation =
    validate1
    >> bind validate2
    >> bind validate3

[<Test>]
let shouldTest() = ()

[<Test>]
let shouldValidateInput() =
    let rs =
        { Name = "wk"; Email = "wk@gmail.com" }
        |> combineValidation

    match rs with
    | Bad x -> ()
    | Ok (x,y) -> ()