module EnumSpec
open System


type FileTypeU =
    | Pdf
    | Png

type FileTypeE =
    | Pdf = 1
    | Png = 2

let getUnoinDesc = function
    | Pdf -> ".pdf"
    | Png -> ".png"
    // don't need _

let getEnumDesc = function
    | FileTypeE.Pdf -> ".pdf"
    | FileTypeE.Png -> ".png"
    | _ -> "Unknow"

let u = Pdf
let e = FileTypeE.Png

u |> getUnoinDesc |> Console.WriteLine
e |> getEnumDesc |> Console.WriteLine
