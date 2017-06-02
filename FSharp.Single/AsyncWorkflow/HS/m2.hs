#!/usr/bin/env stack
-- stack --resolver lts-8.12 script
{-# LANGUAGE OverloadedStrings #-}
import Data.Aeson
import Data.Text (Text)
import qualified Data.ByteString as B
import qualified Data.Vector as V
import qualified Data.HashMap.Strict as HashMap

main :: IO ()
main = do
  bs <- B.readFile "colors.json"
  case eitherDecodeStrict' bs of
    Left e -> error e
    Right (Array array) -> do
      colors <- V.forM array $ \v ->
        case v of
          Object o ->
            case HashMap.lookup "color" o of
              Nothing -> error "Didn't find color key"
              Just (String c) -> return c
              Just v' -> error $ "Expected a String, got: " ++ show v'
          _ -> error $ "Expected an object, got: " ++ show v
      print colors
    Right v -> error $ "Unexpected top level type: " ++ show v