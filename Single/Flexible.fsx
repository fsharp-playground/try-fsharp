type Animal =
    abstract Speed: int with get

type Cat(s:int) =
    interface Animal with
        member this.Speed = s
    member this.Jump = 10
    override this.ToString() = s.ToString()

type Dog(s: int) =
    interface Animal with
        member this.Speed = s
    override this.ToString() = s.ToString()

let maxSpeed1(animals: #Animal list) =
    animals |> List.sortByDescending(fun x -> x.Speed) |> List.head

let maxSpeed2(animals: Animal list) =
    animals |> List.sortByDescending(fun x -> x.Speed) |> List.head

let maxSpeed3(animals: #seq<Animal>) =
    animals |> Seq.sortByDescending(fun x -> x.Speed) |> Seq.head

let max1  = maxSpeed1 [Cat(1); Dog(2); Dog(3)]
let max2  = maxSpeed2 [Cat(1); Dog(2); Dog(3)]
let max31 = maxSpeed3 [|Cat(1); Dog(2); Dog(3)|]
let max32 = maxSpeed3 [Cat(1); Dog(2); Dog(3)]
