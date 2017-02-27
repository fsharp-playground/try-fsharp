
let (|Q1|Q2|X|) month =
    match month with
    | 1 | 2 | 3 -> Q1 (month, "Q1")
    | 4 | 5 | 6 -> Q2 (month, "Q2")
    | _ -> X (month,"QX")
(**************************)
let qv1(Q1 q | Q2 q | X q) =
    sprintf "%d is %s" <| fst q <| snd q

qv1(1)
qv1(4)
qv1(9)

(**************************)
let qv2= function
    | Q1 (m, q) -> "First"
    | Q2 (m, q) -> "Second"
    | X (m, q) -> "X"

qv2(1)
qv2(4)
qv2(9)
