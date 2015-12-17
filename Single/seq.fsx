
let s1 = (..) 1 5
let s2 = {1..5}
let s3 = seq [1;2;3;4;5]

// check
let compare = Seq.compareWith Operators.compare
compare s1 s2 = 0               // true
compare s1 s3 = 0               // true
(s1, s2) ||> Seq.forall2 (=)    // true
(s1, s3) ||> Seq.forall2 (=)    // true


