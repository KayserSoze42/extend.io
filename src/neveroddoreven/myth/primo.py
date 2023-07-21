primos = []

def isPrimo(agen) -> bool:

  if (agen / 2 == 1):
    return True

  if (agen % 2 == 0):
    return False

  for i in range(3, int(agen/2), 2):
    if (agen % i == 0):
      return False

  return True

for i in range(2, 422):

  if isPrimo(i):
    primos.append(i)

for primo in primos:

  print(f"For primo: {primo}")

  iD = primos.index(primo) - 1

  while iD >= 0:

    lesPrimo = primos[iD]

    div = primo / lesPrimo

    print(f"{div}", end="")
    iD = iD -1

  print("...")


