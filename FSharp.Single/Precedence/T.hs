-- (script)
module X where

data Cond a = a :. a

infixl 0 ?

(?) :: Bool -> Cond a -> a
p ? (x :. y) = if p then x else y

main :: IO()
main = do
    let x = True ? "Yes" :. "No"
    putStrLn x