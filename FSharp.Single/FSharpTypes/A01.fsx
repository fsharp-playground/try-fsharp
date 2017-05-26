
type Person = 
    { FirstName : string 
      LastName: string }

type Customer =
    { FirstName : string
      Id : int
      LastName: string  }

type Foo = { FirstName : string }

let inline fullName (a: ^a) =
    let firstName  = ((^a) : (member FirstName: string) (a))
    let lastName   = ((^a) : (member LastName: string) (a))
    sprintf "%s %s" firstName lastName

let person = { FirstName = "First"; LastName = "Last" }
let customer = { FirstName = "First"; LastName = "Last"; Id = 100 }
let foo = { FirstName = "First" }

let fullPersonName = fullName person
let fullCustomerName = fullName customer
// let fullFooName = fullName foo // not support