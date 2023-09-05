from control.matlab import *
from control import *
import matplotlib.pyplot as plt

K=20
A=1
B=5
C=5

function = tf([K],[A,B,C])
coeff = pole(function)

print(coeff)
y,x = step(function)

string = "Устойчива без колебаний: "+ str(coeff)
plt.figure(0)
plt.title(string)
plt.plot(x,y)



K=10
A=5
B=1
C=1

function = tf([K],[A,B,C])
coeff = pole(function)

print(coeff)
y,x = step(function)

string = "Устойчива c колебаниями: "+ str(coeff)

plt.figure(1)
plt.title(string)
plt.plot(x,y)



K=10
A=1
B=-1
C=1

function = tf([K],[A,B,C])
coeff = pole(function)

print(coeff)
y,x = step(function)

string = "Неустойчива c колебаниями: "+ str(coeff)

plt.figure(2)
plt.title(string)
plt.plot(x,y)



K=5
A=1
B=-3
C=1

function = tf([K],[A,B,C])
coeff = pole(function)

print(coeff)
y,x = step(function)

string = "Неустойчива без колебаний: "+ str(coeff)

plt.figure(3)
plt.title(string)
plt.plot(x,y)

plt.show()