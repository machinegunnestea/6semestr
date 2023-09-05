import control
import numpy as np
import matplotlib.pyplot as plt
from scipy.integrate import odeint

# параметры модели
m = 1.34
n = 0.35
k = 3.7

# функция правых частей дифференциального уравнения
def model(y, t,):
    y1, y2 = y
    dydt = [y2, ( n*y2 - k*y1) / m]
    return dydt

# начальные условия и время моделирования
y0 = [0, 0]
t = np.linspace(0, 10, 100)


# решение дифференциального уравнения
sol = odeint(model, y0, t)

# построение графиков
plt.plot(t, 'b-', label='Input')
plt.plot(t, sol[:,0], 'r-', label='Output')
plt.legend(loc='best')
plt.xlabel('Time')
plt.ylabel('y(t)')
plt.show()


# передаточная функция
num = [1]
den = [m, n, k]
sys = control.tf(num, den)

# переходная характеристика
t, y = control.step_response(sys)

# построение графиков
plt.plot(t, y, 'r-', label='Output')
plt.plot(t, np.sin(t), 'b-', label='Input')
plt.legend(loc='best')
plt.xlabel('Time')
plt.ylabel('y(t)')
plt.show()


# корни характеристического уравнения
s1, s2 = np.roots(den)

# коэффициент затухания и частота колебаний
alpha = -np.real(s1)
w = np.imag(s1)

# аппроксимирующая функция
def approx_func(m):
    return alpha + w * np.sqrt(m)

# график зависимости коэффициента затухания и частоты колебаний от параметра m
m_range = np.linspace(0.1, 5, 50)
alpha_list = []
w_list = []
for m in m_range:
    s1, s2 = np.roots([m, n, k])
    alpha_list.append(-np.real(s1))
    w_list.append(np.imag(s1))
plt.plot(m_range, alpha_list, 'r-', label='Damping')
plt.plot(m_range, w_list, 'b-', label='Frequency')
plt.legend(loc='best')
plt.xlabel('m')
plt.show()