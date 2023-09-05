from control.matlab import *
import matplotlib.pyplot as plt

# Интегрир
nom = [1]
den = [1,0]

W = tf(nom, den)
y,t = step(W)

plt.figure(0)
plt.plot(t,y)
print(W)

# Реальн фиг
plt.figure(1)

nom = [1,0]
den = [1,1]

W = tf(nom, den)
y,t = step(W)

plt.plot(t,y)
print(W)

# Апериодич
plt.figure(2)

nom = [-1,0]
den = [1,1]

W = tf(nom, den)
y,t = step(W)

plt.plot(t,y)
print(W)

# Колебательные
plt.figure(3)

W = tf([1], [1, 2, 20])
y,t = step(W)

plt.plot(t,y)
plt.show()
print(W)