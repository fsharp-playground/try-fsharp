
type IFullName =
    abstract FirstName : string
    abstract LastName : string

let fullName (name: IFullName) = 
    sprintf "%s %s" name.FirstName name.LastName