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
y1, x1 = step(W1)
y2, x2 = step(W2)
y3, x3 = step(W3)
y4, x4 = step(W4)

fig, axs = plt.subplots(2, 2)
axs[0, 0].plot(x1, y1)
axs[0, 0].set_title('Устойчива с колебаниями')
axs[0, 1].plot(x2, y2, 'tab:orange')
axs[0, 1].set_title('Устойчива без колебаний')
axs[1, 0].plot(x3, y3, 'tab:green')
axs[1, 0].set_title('Неустойчива с колебаниями')
axs[1, 1].plot(x4, y4, 'tab:red')
axs[1, 1].set_title('Неустойчива без колебаний')

for ax in axs.flat:
    ax.set(xlabel='Время', ylabel='Переходная характеристика')

for ax in axs.flat:
    ax.label_outer()
plt.grid()
plt.show()
