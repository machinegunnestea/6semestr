import random
import time
def Seven (n):
    start = time.time()
    array = random.sample(range(1000000), n)
    sum = 0
    for i in range(n):
        if i % 2 == 0:
            if array[i] > 0:
                sum += array[i]**2
    print("%s секунд" % (time.time() - start))

print("Для 100")
Seven(100)

print("Для 1000")
Seven(1000)

print("Для 10000")
Seven(10000)

print("Для 100000")
Seven(100000)