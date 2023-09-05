import matplotlib.pyplot as plt
import numpy as np
from scipy.integrate import odeint

tk = 3
s = 500

a = 0.2
l = 0.5
m = 5
D = 0.05
d = 0.005
i = 5

alpha = 300
G = 80 * 10 ** 9
g = 9.81
c = (G * d ** 4) / (8 * D ** 3 * i)
p = np.sqrt((c * (a**2) - m * g*l) / (m * (l**2)))
n = alpha*(a**2) / (2*m * (l**2))
t = np.linspace(0, tk, s)
y0 = [0, 0]

def function(y, t):
    if t > 1:
        F = 1
    else:
        F = 0
    return [y[1], -2*n * y[1] - p**2 * y[0] + F]

Y = odeint(function, y0, t)


moveArr = Y[:, 0]
value = moveArr[len(moveArr) - 1]
topLine = value + 0.05 * value
bottomLine = value - 0.05 * value

print("Коридор стабилизации уст. состояния: " f"{bottomLine:.{4}f}" " : " f"{topLine:.{4}f}")


tlast = 0
Ylast = 0
for i in range(1,s):
    tmp = Y[i, 0]
    if tmp <= bottomLine or tmp >= topLine :
        Ylast = Y[i, 0]
        tlast = t[i]

vibrancy = 0

for i in range(1, s):
    if (t[i] < tlast and Y[i, 0] < Y[i + 1, 0] and Y[i + 1, 0] > Y[i + 2, 0]) or (t[i] < tlast and Y[i, 0] > Y[i + 1, 0] and Y[i + 1, 0] < Y[i + 2, 0]):
        t[vibrancy + 1] = np.abs(Y[i, 0] - value)
        vibrancy = vibrancy + 1

Amax = max(moveArr) - value
D = t[1] / t[2]
dynamicCoeff = 1 + Amax / value;

print("Время переходного процесса: " f"{tlast - 1:.{3}f}")
print("Коэффициент динамичности: " f"{dynamicCoeff:.{3}f}")
print("Декремент колебаний : " f"{D:.{3}f}")
print("Колебательность: ", vibrancy)
re_regulation = (max(moveArr) - value) / value * 100

plt.plot(t, Y[:, 0])
plt.plot(t, Y[:, 0], [0, tk], [topLine, topLine], [0, tk], [bottomLine, bottomLine])
plt.plot([0, tk], [topLine, topLine], [0, tk], [bottomLine, bottomLine], color='b')
plt.plot(tlast,Ylast,'*')
print( "Перерегулирование " f"{re_regulation:.{3}f}%")
plt.grid()

plt.show()
