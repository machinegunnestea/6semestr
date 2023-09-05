from control.matlab import *
import matplotlib.pyplot as plt
k = 1
w = tf([k],[1,0])
y,x = step(w)
plt.plot(x,y)
plt.grid()
plt.show()