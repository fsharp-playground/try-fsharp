
import Control.Arrow

data MyArr b c = MyArr (b -> (c, MyArr b c))
