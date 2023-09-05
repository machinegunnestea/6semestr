import matplotlib.pyplot as plt
import numpy as np
from scipy.integrate import *
from scipy.signal import find_peaks
from control.matlab import *

m = 1.34
n = 0.35
k = 3.7

t = np.linspace(0, 50, 3000)
y0 = [0, 0]

def dempf(y, t):
    F = 0
    if t > 0:
        F = 1
    return [y[1], (F - n*y[1] - k*y[0]) / m]

Y = odeint(dempf, y0, t)
plt.grid()

plt.figure(1)
plt.plot(t, Y[:, 0])

del_v = np.abs(Y[:, 0][len(Y[:, 0])-1])
delta = del_v * 0.05
vz = del_v + delta
nz = del_v - delta

A1 = del_v - min(Y[:, 0])
A2 = max(Y[:, 0]) - del_v

D = A1 / A2
print("Декремент колебаний:", D)

#переходная характеристика
K = 1
W = tf([K], [m, n, k]) #1.34, 5, 3.7 без колебаний
print("Корни:", pole(W))

yw, xw = step(W)

#переходная характеристика
plt.figure(2)
plt.plot(xw, yw, color='green')
plt.grid()

i = 0
while Y[i, 0] < nz and i < len(t):
    i = i + 1

Vrem = t[i+1]
print("Время переходного процесса:", Vrem)

plt.figure(3)
plt.plot(t, Y[:, 0])
plt.hlines(vz, 0, 50)
plt.hlines(nz, 0, 50)
plt.plot(t, Y[:, 0], t[i], Y[:, 0][i], '*')

plt.grid()
plt.show()