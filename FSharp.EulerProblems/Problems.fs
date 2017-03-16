
module EulerProblems.Problems
//#nowarn "40"

open FsUnit
open NUnit.Framework
open System

let rec primes = 
    Seq.cache <| seq { yield 2UL; yield! Seq.unfold nextPrime 3UL }
and nextPrime n =
    if isPrime n then Some(n, n + 2UL) else nextPrime(n + 2UL)
and isPrime n =
    if n >= 2UL then
        primes 
        |> Seq.tryFind (fun x -> n % x = 0UL || x * x > n)
        |> fun x -> x.Value * x.Value > n
    else false

[<Test>]
let Problem003() =
    let n = 600851475143UL;
    let max = uint64 (Math.Sqrt(float (n + 1UL)))
    let factors = 
        seq { 
            for x in 3UL..2UL..max do
                if n % x = 0UL then yield x
        }

    let isPrimes =
        let primeSet = primes |> Seq.takeWhile(fun p -> p < max) |> Set.ofSeq
        fun n -> primeSet.Contains(n)

    let biggest = factors |> Seq.filter isPrimes |> Seq.max
    biggest |> should equal 6857

[<Test>]
let Problem002() =
    let rec fib start next ls =
        if start < 4000000 then fib next (start + next) (start::ls) else ls
    fib 1 2 [] |> List.filter (fun x -> x % 2 = 0)
    |> List.sum |> should equal 4613732

[<Test>]
let Problem001() =
    seq { 1 .. 999 }
    |> Seq.filter(fun x -> x % 3 = 0 || x % 5 = 0)
    |> Seq.sum |> should equal 233168

    // watr
    // luta
