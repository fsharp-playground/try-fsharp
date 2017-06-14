-- (script)
module X where

data R = R { number :: Int }
    deriving Show

generate :: [R]
generate = [ R { number = i } | i <- [1..10] ]

main :: IO()
main = do
    let smallNumbers = filter ((< 5) . number)  generate
    putStrLn $ show smallNumbers
    
    