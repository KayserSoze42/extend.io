summa :: Integer -> Integer
summa 0 = 0
summa n = n + summa (n - 1)

main :: IO()

main = do

  print ("Summing all numbers up to 6 gets you " ++ show (summa 6) ++ ".")
  print ("But summing all numbers up to 9 gets you " ++ show (summa 9) ++ "!")
  print ("Together, they are " ++ show ((summa 6) + (summa 9)) ++ "..")
  print ("kek")
