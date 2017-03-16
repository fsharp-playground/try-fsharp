module Main where

data Maybe a = Nothing | Just a

let rs = 
    fmap (+3) (Just 2)

main = putStrLn "Hello World" 