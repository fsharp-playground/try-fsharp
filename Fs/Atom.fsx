#I "..\\packages\\FsUnit\\Lib\\Net40"
#I "..\\packages\\NUnit\\Lib\\"
#r "FsUnit.NUnit.dll"
#r "nunit.framework.dll"

open FsUnit
open NUnit.Framework
open System

module Atom =
    let [<Test>] ``a should equal to 200``() =
        let a = 100
        let b = a + a
        a |> should equal 200
