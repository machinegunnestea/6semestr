from control.matlab import *
import matplotlib.pyplot as plt

K = 1
A1 = 20; B1 = 44; C1 = 128
A2 = 22; B2 = 68; C2 = 22
A3 = 7843; B3 = -5; C3 = 3
A4 = 20; B4 = -64; C4 = 20
W1 = tf([K], [A1, B1, C1])
W2 = tf([K], [A2, B2, C2])
W3 = tf([K], [A3, B3, C3])
W4 = tf([K], [A4, B4, C4])

print(pole(W1))
print(pole(W2))
print(pole(W3))
print(pole(W4))

y1, x1 = step(W1)
y2, x2 = step(W2)
y3, x3 = step(W3)
y4, x4 = step(W4)

plt.figure()
plt.title('Устойчива с колебаниями')
plt.grid()
plt.plot(x1, y1)

plt.figure()
plt.title('Устойчива без колебаний')

plt.grid()
plt.plot(x2, y2)

plt.figure()
plt.title('Неустойчива c колебаниями')

plt.plot(x3, y3)
plt.grid()

plt.figure()
plt.title('Неустойчива без колебаний '+ pole(W4))

plt.plot(x4, y4)
plt.grid()

plt.show()
