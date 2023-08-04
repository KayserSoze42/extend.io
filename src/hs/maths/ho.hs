pair :: (Int, Int)
pair = (9, 6)

doubled :: Int -> Int
doubled x = 2 * x

mapPair :: (a -> b) -> (a, a) -> (b, b)
mapPair f (a1, a2) = (f a1, f a2)

doubledPair :: (Int, Int)
doubledPair = mapPair doubled pair

leest :: [Int]
leest = [420, 69]

doubledLeest :: [Int]
doubledLeest = map (*2) leest

addSome :: Int -> Int -> Int -> Int
addSome x y z = x + y + z

add6And9 :: Int -> Int
add6And9 x = addSome x 6 9

leestButAdd6And9 :: [Int]
leestButAdd6And9 = map (add6And9) leest

main :: IO()
main = do
  
  print ("A pair: " ++ show (pair))

  print ("A doubledPair: " ++ show (doubledPair))

  print ("A leest: " ++ show (leest))

  print ("A doubled leest: " ++ show (doubledLeest))

  print ("A leest but to each number we add first 6 and then 9: " ++ show (leestButAdd6And9))
