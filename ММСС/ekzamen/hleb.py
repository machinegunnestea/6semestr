import numpy as np
import matplotlib.pyplot as plt
from scipy.integrate import odeint

m = 1.34
n = 0.35
k = 3.7

def dempf(y, t):
    F = 0
    if t > 0:
        F = 1
    return [y[1], (F - n*y[1] - k*y[0]) / m]

y0 = [0.03, 0]
t = np.linspace(0, 10, 100)
sol = odeint(dempf, y0, t)

plt.plot(t, sol[:, 1])
plt.title("Ускорение модели")
plt.xlabel("Время")
plt.ylabel("Ускорение")
plt.show()
