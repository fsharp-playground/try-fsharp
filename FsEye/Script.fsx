// Learn more about F# at http://fsharp.org. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load @"FsEye.fsx"

open Swensen.FsEye.Fsi 

// Define your library scripting code here

type TypeEnum =
    | A
    | B


async {
    for i in 1..40 do
        eye.Watch("i", i)
        eye.Watch("i*2", i*2)
        eye.Archive()
        if i % 10 = 0 then
            do! eye.AsyncBreak()
} |> Async.StartImmediate


