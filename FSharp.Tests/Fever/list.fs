// list
let a = [0..10]

a |> List.length

a |> List.head

a |> List.tail

a |> List.filter(fun x -> x % 2 = 0)

a |> List.sum

a |> List.averageBy (fun x -> float x)

// string
let s = "This is string"

s.ToUpper()

s.ToCharArray()
