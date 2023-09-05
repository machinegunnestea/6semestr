import scipy.misc
import numpy as np
from matplotlib import pyplot as plt
from scipy.optimize import curve_fit
from scipy import integrate

xs = [3.9, 4.23, 4.6, 4.9, 5.1, 5.5, 5.8]
ys = [-16, -7, 4, 19, 37, 60, 87]


def y_f(x, a, b):
    return a * x**3 + b * x**2


k, s = curve_fit(y_f, xs, ys, (0, 0))
[a, b] = k
axs = np.arange(xs[0], xs[-1], 0.01)
ays = list(map(lambda x: y_f(x, a, b), axs))

get_delt = lambda a, b: np.abs(a - b)


def len_f(x):
    return np.sqrt(1 + scipy.misc.derivative(lambda x: y_f(x, a, b), x, dx=1.0, n=1) ** 2)


full_dist = integrate.quad(len_f, xs[0], xs[-1])
print('Полная дистанция, погрешность', full_dist)
print("Максимальное отклонение по координате Y", xs[0], xs[-1])
print("k=", k)

plt.plot(axs, ays)
plt.plot(xs, ys, '+')

plt.grid()
plt.show()