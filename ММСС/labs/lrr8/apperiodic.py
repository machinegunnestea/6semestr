from control.matlab import *
import matplotlib.pyplot as plt
K = 1
T1 = 1.5
T2 = 6
w = tf([K], [T1 ** 2, T2, 1])
y, x = step(w)

print(w)

plt.plot(x, y)
plt.grid()
plt.title("Апериодическое звено")
plt.show()
