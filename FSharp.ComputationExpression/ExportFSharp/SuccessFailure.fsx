


type 'a Attempt = (unit -> 'a option)

let succeed x   = (fun () -> Some(x)) : 'a Attempt
let fail        = (fun () -> None) : 'a Attempt
let runAttempt (a: 'a Attempt) = a()

let bind p rest = 
    match runAttempt p with 
    | None -> fail 
    | Some r -> (rest r)

let delay f = (fun () -> runAttempt(f()))

type AttemptBuilder() =
    member b.Return(x) = succeed x
    member b.ReturnFrom(x) = x
    member b.Bind(p, rest) = bind p rest
    //member b.Delay(f) = delay f
    //member b.Let(p, rest) : 'a Attempt = rest p 

let attempt = AttemptBuilder()

let failIfBig n = 
    attempt {
        if n > 1000 then 
            return! fail 
        else return n
    }

attempt {
    let! n1 = failIfBig 1000
    let! n2 = failIfBig 100
    let sum = n1 + n2
    return sum
}  |> runAttempt
    
let sumIfBothSmall inp1 inp2 =
  attempt {
    let k =100
    let! n1 = failIfBig inp1
    do printfn "Hey, n1 was small!" 
    let! n2 = failIfBig inp2
    do printfn "n2 was also small!" 
    let sum = n1 + n2
    return sum 
  }

sumIfBothSmall 100 100 |> runAttempt


(*
type AttemptBuilder =
    member Bind : 'a Attempt * ('a -> 'b Attempt) -> 'b Attempt 
    member Delay : (unit -> 'a Attempt) -> 'a Attempt
    member Let : 'a * ('a -> 'a Attempt) -> 'a Attempt
    member Return: 'a -> 'a Attempt
*)


(*
type AttemptBuilder =
    member Bind : Attempt<'a> * ('a -> Attempt<'b>) -> Attempt<'b> 
    member Delay : (unit -> Attempt<'a>) -> Attempt<'a>
    member Let : a * ('a -> Attempt<'a>) -> Attempt<'a>
    member Return : 'a -> Attempt<'a>
*)
