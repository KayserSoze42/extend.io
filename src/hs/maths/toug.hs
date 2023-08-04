divBy :: Int -> Int -> Bool
divBy x y
  |  x == 0 || y == 0 = False
  |  x `mod` y == 0   = True                
  |  otherwise        = False

isNum :: Int -> [Char]
isNum n
  |  n == 0        = "idk.."
  |  otherwise     = "Yeah!"

main :: IO()
main = do

  print ("Is number nine divisible by number six? " ++ show (9 `divBy` 6))
  print ("Is number four hunder and twenty divisible by number two? " ++ show (420 `divBy` 2))
  print ("Is number zero divisible by number zero? " ++ show (0 `divBy` 0))
  print ("Is zero even a number? " ++ (isNum 0))
  
