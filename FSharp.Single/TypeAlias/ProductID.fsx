open System

type ProductID = ProductID of Int32
type PersonID = PersonID of Int32
type ProductName = ProductName of string

let  getProductID (ProductID v) = v
let  getPersonID (PersonID v) = v
let  getProductName (ProductName v) = v

let show (id,name) = printfn "ID = %d, Name = %s" (getProductID id) (getProductName name)

let productID = ProductID(100)
let personID = PersonID(100)
let productName  = ProductName("Product NAME")

show (productID, productName) 
show (personID, productName)







