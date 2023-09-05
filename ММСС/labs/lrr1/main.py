import matplotlib.pyplot as mp
import matplotlib.animation as animation
import numpy as np
Vb =0.862
S0=1.185
T=np.arange (0,1.2,0.01)

AC=0.52
OA=0.8
AB=0.91

W=2.247
Ksi0=0.551

S1 = S0 - Vb * T
Ksil = Ksi0+W*T

f = np.arccos((-AB**2+S1**2+OA**2) / (2*OA*S1))
XA=OA*np.cos (f)
YA=OA*np.sin (f)
XC=XA-AC*np.cos (f-Ksil)
YC=YA-AC*np.sin(f-Ksil)
print (XC[np.argmax (YC) ])
print (T[np.argmax (YC) ])
print (max (YC) )
fig = mp.figure(facecolor='white')
ax = mp.axes(xlim=(-2, 2), ylim=(0, 2) )
mp.plot (XC, YC,XC [np.argmax (YC) ])

lin1, = ax.plot([ ], [ ], lw=3) # line = объект кривой
lin2, = ax.plot([ ], [ ], lw=3)
lin3, = ax.plot([ ], [ ], lw=3)
ax.grid(True)

def redraw(i):
    x = XC[i]
    y = YC[i]
    x1=XA[i]
    y1=YA[i]
    x2=S1[i]
    lin1.set_data([x,x1], [y,y1])
    lin2.set_data( [0, x1], [0, y1])
    lin3.set_data([x2, x1], [0, y1])
    return lin1, lin2, lin3
anim=animation.FuncAnimation(fig,redraw,frames=200,interval=30)

mp.show()