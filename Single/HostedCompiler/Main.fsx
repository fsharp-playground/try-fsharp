#r "../../packages/FSharp.Compiler.Service/lib/net45/FSharp.Compiler.Service.dll"

open Microsoft.FSharp.Compiler.SimpleSourceCodeServices
open System.IO

let tempFile = "Output/Hello.fs" 
let sourceFile = Path.ChangeExtension(tempFile, ".fs")
let dllFile = Path.ChangeExtension(tempFile, ".dll")

File.WriteAllText(sourceFile, """
module M

type C() = 
   member x.P = 1

let x = 3 + 4

""")

let scs = SimpleSourceCodeServices()
let commands = [
    "fsharpc"
    "-o:" + dllFile
    "-a"
    sourceFile ]  |> List.toArray
    
let error, existCode = scs.Compile(commands)

printfn "%A" (System.String.Join(" ", commands))
printfn "%A" error
printfn "%A" existCode