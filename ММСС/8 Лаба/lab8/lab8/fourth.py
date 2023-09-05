from control.matlab import *
import matplotlib.pyplot as plt
k = 1
t1 = 5
t2 = 1.6
g = t2/(2*t1)
w = tf([k],[t1**2,2*g*t1,1])
y,x = step(w)
plt.plot(x,y)
plt.grid()
plt.show()
