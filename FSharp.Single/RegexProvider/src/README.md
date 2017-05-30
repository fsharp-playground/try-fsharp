
## Main.fsx

```fsharp
#r "../packages/FSharp.Text.RegexProvider/lib/net40/FSharp.Text.RegexProvider.dll"

open FSharp.Text.RegexProvider

type PhoneRegex = Regex< @"(?<AreaCode>^\d{3})-(?<PhoneNumber>\d{3}-\d{4}$)", noMethodPrefix = true>

let m = PhoneRegex().Match("425-123-2345")

printfn "%A" m.AreaCode.Value
printfn "%A" m.PhoneNumber.Value

type WordRegex2 = Regex< @"(?<Word>fox|dog)" >
let input = @"The fox jumps over the lazy dog"

let m2 = WordRegex2().Match(input)

type WordRegex = Regex< @"(?<Word>\w+)" >

let wordsReg input =
    let matcher = WordRegex().TypedMatches
    let matches = matcher input 
    matches |> Seq.map (fun m -> m.Word.Value)
let words: string seq = wordsReg "The fox jumps over the lazy dog"


type NumberRegex = Regex< @"(?<Number>\d+)\s(?<Word>[A-Z]+)" >

let values input =
    let matcher = NumberRegex().TypedMatches
    let matches = matcher input
    matches |> Seq.map (fun m -> m.Number.Value, m.Word.Value)

let numbers: (string * string) seq = values "100 ABC 200 DEF 300 GHI"

printfn "%A" numbers 
// seq [("100", "ABC"); ("200", "DEF"); ("300", "GHI")]


let s = System.Text.StringBuilder().Append("Hello")













```
