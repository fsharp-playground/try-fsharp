
type DbResult<'a> =
    | Success of 'a
    | Error of string

let getCustomerId name =
    if name = "" then Error "getCustomerId failed"
    else Success "Cust42"

let getLastOrderForCustomer custId =
    if custId = "" then Error "getLastOrderForCustomer failed"
    else Success "Order123"

let getLastProductForORder orderId =
    if orderId = "" then Error "getLastProductForOrder failed"
    else Success "Product456"

let product =
    let r1 = getCustomerId "Alice"
    match r1 with
    | Error _ -> r1
    | Success custId ->
        let r2 = getLastOrderForCustomer custId
        match r2 with
        | Error _ -> r2
        | Success orderId ->
            let r3 = getLastProductForORder orderId
            match r3 with
            | Error _ -> r3
            | Success productId ->
                printfn "Product is %s" productId
                r3

product |> printfn "%A"
