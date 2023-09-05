import numpy as np
import matplotlib.pyplot as plt
from scipy.optimize import fsolve
import scipy.optimize as opt

f1=np.radians(45)
f2=np.radians(22.5)
f3=np.radians(67.5)
S1 = 1.2
S2 = 1.4
S3 = 0.95
a4 = 0.1
B = np.radians(100)

f_array = ([f1, f2, f3])
S = np.asarray([S1, S2, S3]);
first = np.empty([3, 3])
second = np.asarray([]);

for i in range(0, 3):
    first[i, 0] = S[i] * np.cos(f_array[i]);
    first[i, 1] = np.sin(f_array[i]);
    first[i, 2] = -1;
    second = np.append(second, S[i] ** 2);

### нахождение коэффициента
K = np.linalg.solve(first, second);
a1 = K[0]/2;
a3 = K[1] / (2*a1);
a2 = np.sqrt(a1 ** 2 + a3 ** 2 - K[2]);

print("a1: " + str(a1) + "\na2: " + str(a2) + "\na3: " + str(a3))

if (a1>a2-a3):
    print("Нет решения")
else:
    print("Есть решение")
    if (a3 > 0):
        H = 1
    else:
        H = -1

    xc = a1 * np.cos(f1) + np.sqrt(a2 ** 2 - (a3 * H - a1 * np.sin(f1)) ** 2)
    yc = a3 * H
    xb = a1 * np.cos(f1)
    yb = a1 * np.sin(f1)
    f22 = np.arccos((xc - a1 * np.cos(f1)) / a2)
    f6 = f22 + B
    xn = a1 * np.cos(f1) + a4 * np.cos(f6)
    yn = a1 * np.sin(f1) + a4 * np.sin(f6)

    hod = np.asarray([]);
    size = 50;
    fi = np.linspace(0, 2 * np.pi, size);
    for f in fi:
        s = a1 * np.cos(f) + np.sqrt(a2 ** 2 - (a3 * H - a1 * np.sin(f)) ** 2);
        hod = np.append(hod, s);
    args = np.array([1, 5]);
    porog = 1.2;
    porog_fi = opt.fsolve(lambda x: a1 * np.cos(x) + np.sqrt(a2 ** 2 - (a3 * H - a1 * np.sin(x)) ** 2) - porog, args);

    print('Пороговое значение: ' + str(porog) + ' достигается при значениях fi = ' + str(porog_fi));
    min = np.argmin(hod)
    indexOfMinValue = np.argmin(hod);
    print(
        'Минимальное значение хода ползуна = ' + str(hod[indexOfMinValue]) + ', при fi = ' + str(fi[indexOfMinValue]));




