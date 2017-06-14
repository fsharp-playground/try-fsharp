
module X where

-- import qualified Prelude

data Cond a = a :? a
infixl 0 ?
infixl 1 :?

(?) :: Bool -> Cond a -> a
True  ? (x :? _) = x
False ? (_ :? y) = y