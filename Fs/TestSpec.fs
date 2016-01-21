

module Fs.TestSpec
open System
open FsUnit
open NUnit.Framework

[<Test>]
let shouldTest() =
    1 = 1 |> should equal true

