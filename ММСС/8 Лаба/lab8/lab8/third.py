from control.matlab import *
import matplotlib.pyplot as plt
K = 1
T1 = 1.6
T2 = 5
w = tf([K], [T1 ** 2, T1, 1])
y, x = step(w)
plt.plot(x, y)
plt.grid()
plt.show()

