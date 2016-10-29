
// seq [1; 2; 3; 4; 5]
let s1 = (..) 1 5
let s2 = {1..5}

// seq [1; 3; 5]
let s3 = (.. ..) 1 2 5
let s4 = {1..2..5}

// check
let compare = Seq.compareWith Operators.compare
compare s1 s2 = 0               // true
(s1, s2) ||> Seq.forall2 (=)    // true

compare s3 s4 = 0               // true
(s3, s4) ||> Seq.forall2 (=)    // true


