
from control.matlab import *
import matplotlib.pyplot as plt
k = 1
w = tf([k],[1,0]) #интегрирующего
y,x = step(w)
plt.plot(x,y)
plt.grid()
plt.show()
k = 1
w = tf([k,0],[1,1])#дифферинцирующего.
y,x = step(w)
plt.plot(x,y)
plt.grid()
plt.show()
K = 1
T1 = 7
T2 = 2
w = tf([K], [T2 ** 2, T1, 1])#апериодического
y, x = step(w)
plt.plot(x, y)
plt.grid()
plt.show()
k = 1
t1 = 5
t2 = 1.6
w = tf([k],[t1**2,2*t2,1])#колебательного
y,x = step(w)
plt.plot(x,y)
plt.grid()
plt.show()

A,PH,W=bode(w)
plt.plot()
plt.show()

