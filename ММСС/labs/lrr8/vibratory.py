from control.matlab import *
import matplotlib.pyplot as plt

k = 1
t1 = 5
t2 = 1.6
w = tf([k],[t1**2,2*t2,1])
y,x = step(w)
print(w)
plt.plot(x,y)
plt.grid()
plt.title("Коллебательное")
plt.show()

