

type Person = { FirstName: string; LastName: string }

//let fullName { FirstName = "wk"; LastName = l} = 
//    sprintf "%s %s" "wk" l    

let fullName { FirstName = f; LastName = l } = 
    sprintf "%s %s" f l    

printfn "%A" <| fullName { FirstName = "F"; LastName = "L"}

