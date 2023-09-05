import control
import matplotlib.pyplot as plt
import numpy as np
from control import tf, pole
from control.matlab import step
from scipy.integrate import odeint

# параметры модели
m = 1.34
n = 0.35
k = 3.7

# начальные условия и время моделирования
y0 = [0, 0]
t = np.linspace(0, 50, 1000)


# функция правых частей дифференциального уравнения
def dempf(y, t):
    F = 0
    if t > 0:
        F = 1
    return [y[1], (F - n*y[1] - k*y[0]) / m]


# решение дифференциального уравнения
sol = odeint(dempf, y0, t)

plt.grid()
plt.figure(1)
plt.plot(t, sol[:, 0])
plt.xlabel('Время')
plt.ylabel('y(t)')

# передаточная функция
num = [1]
den = [m, n, k]
sys = control.tf(num, den)

# переходная характеристика
t, y = control.step_response(sys)

plt.figure(2)
plt.grid()
plt.plot(t, y, color='green')
plt.xlabel('Время')
plt.ylabel('y(t)')


# корни характеристического уравнения
s1, s2 = np.roots(den)
print("Корень s1 характеристического уравнения: ", s1)
print("Корень s2 характеристического уравнения: ", s2)


alpha = np.abs(np.real(s1))
w = np.imag(s1)
print("коэффициент затухания", alpha)
print("частота колебаний", w)

# аппроксимирующая функция
def approx_func(m):
    return alpha + w * np.sqrt(m)

# график зависимости коэффициента затухания и частоты колебаний от параметра m
m_range = np.linspace(0.1, 5, 10)
alpha1 = []
w1 = []
for m in m_range:
    s1, s2 = np.roots([m, n, k])
    alpha1.append(-np.real(s1))
    w1.append(np.imag(s1))

for i in range(0, len(alpha1)):
    print("Значение при m", i + 1 ,"=", alpha1[i])

plt.figure(3)
plt.grid()
plt.plot(m_range, alpha1, color='green')
plt.plot(m_range, w1, color='pink')
plt.xlabel('m')

plt.show()


