open System.Runtime.CompilerServices

type Person() = 
    member val FirstName = "" with set, get
    member val LastName = "" with set, get

module Extension1 = 
    type Person with
        member this.PrettyString separator =
            sprintf "FirstName = %s %s LastName = %s" 
                this.FirstName separator this.LastName

module Extension2 = 
    type Person with
        member this.PrettyString(str: string)  =
            sprintf "%s %s" this.FirstName this.LastName
        member this.PrettyString(str:string, str2:string) =
            this.PrettyString ""

//open Extension1
open Extension2

[<Extension>]
type Extensions() =
    [<Extension>]
    static member GetFullName(p: Person) = 
        sprintf "%s %s" p.FirstName p.LastName

    static member GetFullName(p: Person, x: string) =
        p.GetFullName()

let person = Person(FirstName = "Perter", LastName = "Morris")
person.PrettyString("|") |> printfn "%A"
person.PrettyString( ",") |> printfn "%A"
person.PrettyString("s", "s")  |> printfn "%s"
