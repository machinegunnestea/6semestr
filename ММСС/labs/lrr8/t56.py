from control.matlab import *
import matplotlib.pyplot as plt
import numpy as np
K = 1
T1 = 5
T2 = 5
w = tf([K], [T1 ** 2, 2 * T2 / (2 * T1) * T1, 1])

y, x = step(w)
maxA = 0.0
maxW = 0.0
mag, phase, omega = bode(w)

for i in range(len(mag)):
    if(mag[i] == max(mag)):
        maxA = mag[i]
        maxW = omega[i]

print("Максимальная частота = ", maxW)
print("Частота при этом значении = ", maxW)

plt.grid()

plt.figure(2)

plt.grid()

plt.plot(omega,mag)

maxi = np.argmax(mag)

plt.scatter(omega[maxi],mag[maxi])

print(omega[maxi],mag[maxi])

plt.show()
