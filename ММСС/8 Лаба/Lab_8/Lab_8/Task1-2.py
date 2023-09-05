from control.matlab import *
import matplotlib.pyplot as plt
import numpy as np

##########    ИНТЕГРИРУЮЩАЯ   ##############

k = 1
w = tf([k],[1,0])
y,x = step(w)
plt.plot(x,y)
plt.grid()
plt.title("Интегрирующая")
plt.figure()

##############    ДИФФЕРЕНЦИРУЮЩАЯ   ###########

k = 1
w = tf([k,0],[1,1])
y,x = step(w)
plt.plot(x,y)
plt.grid()
plt.title("Дифференцирующая")
plt.figure()

##############    АПЕРИОДИЧЕСКАЯ   #################

K = 1
T1 = 7
T2 = 2
w = tf([K], [T2 ** 2, T1, 1])
y, x = step(w)
plt.plot(x, y)
plt.grid()
plt.title("Апериодическая")
plt.figure()

################    КОЛЕБАТЕЛЬНАЯ   ##################

k = 1
t1 = 5
t2 = 1.6
w = tf([k],[t1 ** 2, 2 * t2, 1])
y, x = step(w)
plt.plot(x,y)
plt.grid()
plt.title("Колебательная")
plt.show()





