doubled :: Int -> Int
doubled x = x * 2

main :: IO()
main = do

  print ("Enter any number:")
  input <- getLine

  let number = read input :: Int
  print ("Number: " ++ show (number))

  let doubledNumber = doubled number

  print ("Doubled number: " ++ show (doubledNumber))
