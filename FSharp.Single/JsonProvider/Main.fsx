#r "packages/FSharp.Data/lib/net40/FSharp.Data.dll"
open FSharp.Data

type Settings = JsonProvider<"settings.json">

let sample = Settings.Parse("settings.json")
let w = sample.WindowWidth
let h = sample.WindowHeight
let font = sample.EditorFontFamily