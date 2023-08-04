primos :: Int -> Bool
primos n
  |  n == 1         = True
  |  n == 2         = True
  |  n `mod` 2 == 0 = False
  |  otherwise      = True

main :: IO()

main = do

  let sumNumz = [1,2,3,4,5,6,7,8,9]

  let bulRulez = map (primos) sumNumz

  print (sumNumz)

  print ("**And**")

  print (bulRulez)

  print ("**")

  print ("Yeah... it's just evenly wrong..")

