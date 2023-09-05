import numpy as np
import matplotlib.pyplot as plt
from scipy.integrate import odeint
from scipy.signal import find_peaks

m = 1.34
n = 0.35
k = 3.7

def dempf(y, t):
    F = 0
    if t > 0:
        F = 1
    return [y[1], (F - n*y[1] - k*y[0]) / m]

y0 = [0, 0]
t = np.linspace(0, 10, 1000)
sol = odeint(dempf, y0, t)

peaks, _ = find_peaks(sol[:, 0])
max_peak = max(sol[peaks, 0])

plt.plot(t, sol[:, 0])
plt.plot(t[peaks], sol[peaks, 0], "x")
plt.title("Переходная характеристика модели")
plt.xlabel("Время")
plt.ylabel("Перемещение")
plt.show()

print(f"Максимальное значение переходной характеристики: {max_peak}")
