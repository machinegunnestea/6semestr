import numpy as np
from scipy.optimize import curve_fit
import matplotlib.pyplot as plt

def func(u, A, D, alpha, beta):
    return A * u * np.exp(-alpha * u) + D * (np.exp(beta * u) - 1)

A = 0.2
alpha = 7
D = 1e-7
beta = 10

Iu = np.array([0.003, 0.006, 0.009, 0.012, 0.009, 0.008, 0.006, 0.004, 0.003, 0.002, 0.003, 0.005])
u = np.array([0.01, 0.03, 0.06, 0.11, 0.24, 0.28, 0.35, 0.42, 0.5, 0.56, 0.63, 0.7])

Res, pog = curve_fit(func, u, Iu, (A, D, alpha, beta))

A1 = Res[0]
D1 = Res[1]
alpha1 = Res[2]
beta1 = Res[3]

print("A начальное", A)
print("A1", A1)
print("D начальное",D)
print("D1",D1)
print("alpha начальное", alpha)
print("alpha1", alpha1)
print("beta начальное", beta)
print("beta1", beta1)

u1 = np.linspace(0, 0.7, 100)
Iu1 = func(u1, A1, D1, alpha1, beta1)
plt.scatter(u, Iu, color='orange')
plt.plot(u1, Iu1)
plt.show()