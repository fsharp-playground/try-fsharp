#!/usr/bin/env stack
-- stack --resolver lts-8.12 script
{-# LANGUAGE OverloadedStrings #-}
import Data.Aeson
import Data.Text (Text)
import qualified Data.ByteString as B

data Color = Color { colorName :: !Text }

instance FromJSON Color where
  parseJSON = withObject "Color" $ \o -> Color <$> o .: "color"

main :: IO ()
main = do
  bs <- B.readFile "colors.json"
  case eitherDecodeStrict' bs of
    Left e -> error e
    Right colors -> print $ map colorName colors