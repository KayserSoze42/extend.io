sixOrNine :: Int -> [Char]
sixOrNine 6 = "It is not a 9.. but it is 6!"
sixOrNine 9 = "It is not a 6.. but it is 9!"
sixOrNine n
  | n == 69    = "It is kind of both, but neither really.."
  | n == 420   = "No relations... but nice"
  | n == 42069 = "I mean.. it is in there... somewhere..."
  | otherwise  = "Not even close!"


main :: IO()
main = do

  print ("Is number 6 either 6 or 9?")
  print (sixOrNine 6)

  print ("Is number 9 either 6 or 9?")
  print (sixOrNine 6)

  print ("Is number 69 either 6 or 9?")
  print (sixOrNine 69)

  print ("Is number 420 either 6 or 9?")
  print (sixOrNine 420)

  print ("Is number 42069 either 6 or 9?")
  print (sixOrNine 42069)

  print ("Is number 42 either 6 or 9?")
  print (sixOrNine 42)

