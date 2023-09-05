import numpy as np
import matplotlib.pyplot as plt
from scipy.integrate import odeint

m = 1.34
k = 3.7

def dempf(y, t, n):
    F = 5*np.sin(t)
    return [y[1], (F - n*y[1] - k*y[0]) / m]

n_values = np.arange(3, 11)
y0 = [0, 0]
t = np.linspace(0, 20*np.pi, 1000)

plt.figure(figsize=(10, 6))
for n in n_values:
    sol = odeint(dempf, y0, t, args=(n,))
    plt.plot(t, sol[:, 0], label=f"n={n}")
plt.title("Перемещения динамической системы")
plt.xlabel("Время")
plt.ylabel("Перемещение")
plt.legend()
plt.show()