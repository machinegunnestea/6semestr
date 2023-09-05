import numpy as np
import matplotlib.pyplot as plt

v = 0.675
f1 = 1.88
f2 = 3.05
f3 = 5.12
a1 = 8.5
a2 = 7.23
W0 = 1.256

T = (2 * np.pi) / W0
t = np.arange(0, T, 0.01)

S11 = np.zeros(len(t))
number = 0
for i in t:
    if i < (f1/ W0) and i >= 0:
        S11[number] = a1*np.sin(2*np.pi*W0*i/f1)
        number= number+1
    if i >= (f1/ W0) and i < (f2/W0) :
        S11[number] = 0
        number = number + 1
    if i < (f2/W0 + (f3 - f2)/ W0) and i >= (f2/W0) :
        S11[number] = a2*np.sin(2*np.pi*W0*i/(f3-f2))
        number = number + 1
    if i >= (f2/W0 + (f3 - f2)/ W0) and i < (2*np.pi/W0) :
        S11[number] = 0
        number = number + 1

S1 = np.zeros(len(t))

for i in range(0, len(t), 1):
    S1[i] = np.trapz(S11[0:i], t[0:i]) * W0 * W0

S = np.zeros(len(t))

for i in range(0, len(t), 1):
    S[i] = np.trapz(S1[0:i], t[0:i])

R1 = S1 / np.tan(v)
R0 = min(R1)
R = R0 + S
X = np.zeros(len(t))
Y = np.zeros(len(t))
for i in range(0, len(t), 1):
    X[i] = R[i] * np.sin(W0 * t[i])
    Y[i] = R[i] * np.cos(W0 * t[i])

#1
plt.plot(t, S11, color='green')
plt.xlabel('t')
plt.ylabel('S11 ')
plt.grid(True)
plt.show()

#2
plt.plot(t, S1, color='green')
plt.xlabel('t')
plt.ylabel('S1 ')
plt.grid(True)
plt.show()

#3
plt.plot(t, S, color='green')
plt.xlabel('t')
plt.ylabel('S ')
plt.grid(True)
plt.show()

#4
plt.plot(X, Y, color='green')
plt.xlabel('X')
plt.ylabel('Y')
plt.grid(True)
plt.show()