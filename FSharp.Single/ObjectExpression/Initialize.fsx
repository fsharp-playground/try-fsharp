type Title = Mr | Mrs | Miss

type Person (?title)= 
    member val FirstName = "" with set,get
    member val LastName = "" with set,get
    member val Title = defaultArg title Mr with get

let person1 = Person()
let person2 = Person(FirstName = "Graham", LastName = "Wardle")
let person3 = Person(Miss, FirstName = "Amber", LastName = "Marshall")
