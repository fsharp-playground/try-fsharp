
[<Measure>] type baht
[<Measure>] type dollar

let bInD= 34.38<baht/dollar>
let dInB = 0.03438<dollar/baht>

let processBaht (a: float<baht>) = ()

let inline (==) x y =
    abs(x - y) < 0.0000001<_>

(100.0<dollar> * bInD) == 3438.0<baht>  // true
(100.0<baht>   * dInB) == 3.438<dollar> // true

processBaht(100.0<baht>)   // ok
processBaht(100.0<dollar>) // error








