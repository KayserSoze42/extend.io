summa :: Integer -> Integer
summa 0 = 0
summa n = n + summa (n - 1)

facto :: Integer -> Integer
facto 0 = 1
facto n = n * (facto (n - 1))

main :: IO()

main = do

  print ("Summing all numbers up to (and including) 6 gets you: " ++ show (summa 6) ++ ".")
  print ("But summing all numbers up to (and including) 9 gets you: " ++ show (summa 9) ++ "!")
  print ("Together, they are: " ++ show ((summa 6) + (summa 9)) ++ "..")
  print ("kek")

  print("**")

  print ("Now, doing all of the same (just with extra steps) for the first number yields: " ++ show (facto 6) ++ ".")
  print ("And doing all of that (just with same extra steps) for the second number, yields: " ++ show (facto 9) ++ "!")
  print ("Once again, together they make up to: " ++ show ((facto 6) + (facto 9)))
  print ("keke")

  print("**")
