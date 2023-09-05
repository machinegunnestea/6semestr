import numpy as np
import scipy.integrate as sp
import matplotlib
from matplotlib.figure import *
import math
from tkinter import *
import matplotlib.pyplot as plt

m = 5
a = 0.2
l = 0.5
D = 0.05
d = 0.005
i = 5

alpha = 300
G = 80 * 10 ** 9
g = 9.81
c = (G * d ** 4) / (8 * D ** 3 * i) #жесткость
p = math.sqrt((c * (a**2) - m * g*l) / (m * (l**2))) #частота
n = alpha*(a**2) / (2*m * (l**2)) #приведенный коэффициент сопротивления демпфера
F0 = 0.05
w = 15

var_m = [2.0, 2.3, 2.9, 3.3, 3.8, 4.1, 4.5, 5.3, 6.8]
print(n)

def func(y, t, m):
    n = alpha*(a**2) / (2*m * (l**2))
    y1, y2 = y
    dydt = [y2, -2*n * y2 - p ** 2 * y1]
    return dydt

def funcInfluence(y, t, m):
    n = alpha*(a**2) / (2*m * (l**2))
    y1, y2 = y
    dydt = [y2, (-2*n * y2 - p ** 2 * y1 + F0 * math.sin(w * t))]
    return dydt

x0 = 0.0
y0 = 0.5, 0.0
t = np.linspace(x0, 1, 500)
s = sp.odeint(func, y0, t, args=(m,))
s1= s[:,0]
sInfluence = sp.odeint(funcInfluence, y0, t, args=(m,))[:,0]

print(n)
print(p ** 2)

########################  task 1
#1.	С использованием СКМ рассчитать значение функций перемещения,
# скорости и ускорения динамической системы под воздействием
# начальных значений перемещения и скорости без учета возмущающей
# силы. Построить графики этих функций.

# скорость
plt.plot(t, s1)
plt.title("Функция перемещения")
plt.grid()
plt.figure()

# перемещение
plt.plot(t, s[:,1])
plt.title("Функция скорости")
plt.grid()
plt.figure()

########################  task 2
#2.	Рассчитать значение функции перемещения динамической
# системы под воздействием возмущающей силы. Построить графики этой функции.

plt.plot(t, sInfluence)
plt.title("Функция перемещения с воздействием")
plt.grid()
plt.figure()

########################  task 3
#3.	Исследовать влияние значений изменяемого параметра на амплитуду
# перемещения динамической системы, для этого рассчитать функцию
# перемещения при различных значениях изменяемого параметра.
# Построить графики зависимости перемещения системы от времени.
for i in range(0, len(var_m)):
    sInfluence = sp.odeint(func, y0, t, args=(var_m[i],))[:,0]
    plt.plot(t, sInfluence)

plt.title("Варьирование параметра")
plt.grid()
plt.figure()

########################  task 5

mins = np.zeros(len(var_m))
for i in range(0, len(var_m)):
    sInfluence = sp.odeint(func, y0, t, args=(var_m[i],))[:,0]
    mins[i] = min(sInfluence)

plt.title("Зависимость экстремума от варьируемого параметра")
plt.plot( var_m, mins, '*')
plt.grid()
plt.figure()

######################## task 6

var_m_2 = np.linspace(1.1, 7, 500)
plt.plot(var_m, mins, '*')
coeff = np.polyfit(var_m, mins, 2)
data_new = np.poly1d(coeff)
print(data_new)

plt.title("Исходные и аппроксимирующие зависимости")
plt.plot(var_m_2, data_new(var_m_2))
plt.grid()

plt.show()


