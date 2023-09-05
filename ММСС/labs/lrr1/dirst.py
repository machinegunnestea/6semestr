import math as m
import numpy as np
import matplotlib.pyplot as plt

import matplotlib.animation as animation

t = np.arange(0, 1.2, 0.01)

Vb = 0.862
S0 = 1.185
mu = 2.247
PS0 = 0.551

AB = 0.91
OA = 0.80
AC = 0.52

S1 = S0 - Vb * t
PS1 = PS0 + mu * t

fi = np.arccos((-(AB ** 2) + S1 ** 2 + OA ** 2) / (2 * OA * S1))

XA = OA * np.cos(fi)
YA = OA * np.sin(fi)

XC = XA - AC * np.cos(fi - PS1)
YC = YA - AC * np.sin(fi - PS1)

max_index = np.argmax(YC)
max_time = t[max_index]
max_point = (XC[max_index], YC[max_index])

print(max_time)

plt.scatter(max_point[0], max_point[1], color='red')
plt.plot(XC, YC)
plt.show()