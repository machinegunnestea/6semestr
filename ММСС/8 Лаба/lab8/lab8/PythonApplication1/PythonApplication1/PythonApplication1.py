from control.matlab import *
import matplotlib.pyplot as plt


K1=1
K2=1
K3=1
K4=1
T1=0.1
T3=0.3
T4=0.4
T5=0.5
T6=0.6
W1=tf([K1],[T1, 1])
W2=tf([K2],[1, 0])
W3=tf([K3*T3, K3],[T4, 1])
W4=tf([K4],[T5*T6,T6,1])
W5=W1*W2
W6=(W5+W3)
W7=feedback(W6,W4)
print(W7)
print(W7)
num= [0., 1.]
den= [1., 2., 10.]
w= tf(num, den)
y,x=step(W7)
plt.plot(x,y)
plt.grid(True)
plt.show()
p = pole(W7)
for i in p:
    if(i == 0):
        print("Система нейтральна")
        break
    if(isinstance(i, complex)):
        if(i < 0):
            print("Система устойчива с колебаниями")
            break
        if((i) > 0):
            print("Система неустойчива с колебаниями")
            break
    else:
        if(i < 0):
            print("Система устойчива без колебаний")
            break
        if(i > 0):
            print("Система неустойчива без колебаний")
            break  
print(p)
