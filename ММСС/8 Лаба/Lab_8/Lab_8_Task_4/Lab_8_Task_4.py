from control.matlab import *
import matplotlib.pyplot as plt
import numpy as np

K1=0.1 
K2=10 
K3=2 
T1=3
T3=0.6
T4=2
K4=1
T5=4
T6=2

W1 = tf([K1], [T1, 1])
W2 = tf([K2], [1, 0])
W3 = tf([T3, 1], [T4, 1])
W4 = tf([K4], [T5*T6, T6, 1])
W44 = W1*(W2+W3)
W5 = 1
W6 = feedback(W44, W5)
W7 = W6 * W4
W8 = 1
W9 = feedback(W7, W8)
print(W9)

y,t = step(W9)
plt.plot(t, y)
plt.grid()
plt.show()
