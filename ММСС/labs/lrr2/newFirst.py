import math
from scipy.optimize import fsolve
import numpy as np
import matplotlib.pyplot as mp
f11=math.radians(43)
f2=math.radians(82)
f3=math.radians(103)
S1=1
S2=0.8
S3=0.67
a4=0.09
B=math.radians(120)
def F(X):
    K1,K2,K3=X
    K = np.array([0, 0, 0], float)
    K[0] = K1*S1*np.cos(f11)+K2*np.sin(f11)-K3-S1**2
    K[1] = K1*S2*np.cos(f2)+K2*np.sin(f2)-K3-S2**2
    K[2]=K1*S3*np.cos(f3)+K2*np.sin(f3)-K3-S3**2
    return K
K=fsolve(F,[1,1,1])
a1=K[0]/2
a3=K[1]/(2*a1)
a2=math.sqrt(a1**2+a3**2-K[2])
print("a1: " + str(a1) + "\na2: " + str(a2) + "\na3: " + str(a3))

if a1< a2-a3:
    print("Решение существует")
else:
    print("Решение не существует")
H=0
if a3>0:
    H=1
elif a3<0:
    H=-1
f1=np.linspace(0,math.pi,100)
Xc=np.zeros(100)
Xc=a1*np.cos(f1)+np.sqrt(a2**2-(a3*H-a1*np.sin(f1))*(a3*H-a1*np.sin(f1)))
Yc=a3*H
Xv=a1*np.cos(f1)
Yv=a1*np.sin(f1)
f6=f2+B
Xn=a1*np.cos(f1)+a4*np.cos(f6)
Yn=a1*np.sin(f1)+a4*np.sin(f6)
f22=np.arccos((Xc-a1*np.cos(f1))/a2)
mp.plot(Xv, Yv,Xn,Yn)
mp.scatter(Xn[30],Yn[30])
mp.scatter(Xv[20],Yv[20])
mp.scatter(Xc[10],a3)
mp.scatter(0,0)
XD=[0,Xv[20],Xn[30]]
YD=[0,Yv[20],Yn[30]]
XCD=[Xc[10],Xv[20]]
YCD=[a3,Yv[20]]
print(math.sqrt((Xv[0]-Xc[0])**2+(Yv[0]-a3)**2))
mp.plot(XD,YD)
mp.plot(XCD,YCD)
mp.grid()
mp.show()