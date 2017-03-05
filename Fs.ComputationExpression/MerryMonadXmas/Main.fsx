// http://jeremyabbott.github.io/blog/2016/12-03-merry/
// https://medium.com/real-world-fsharp/understanding-monads-db30eeadf2bf#.i97nh4b3w

open System

type Gift =
    | Wants of string
    | Coal

type Person = {
    Name: string
    SharedToys: bool
    IsANastyWoman: bool
    Wants: string
}

let giftIf behavior person =
    let gift = if behavior then Wants person.Wants else Coal
    person.Name, gift