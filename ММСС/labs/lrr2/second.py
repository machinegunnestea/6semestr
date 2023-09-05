import sys
from functools import reduce
import numpy as np
import matplotlib.pyplot as plt

def psi(phi):
    return k1 * np.sin(phi) + k2

def f0(phi):
    return np.cos(phi + alpha)

def f1(phi):
    return np.cos(psi(phi) + betta)

def f2():
    return 1

def F(phi):
    return np.cos(phi + alpha - psi(phi) - betta)

def max_error():
    return reduce(lambda x, y: x if np.abs(x) > np.abs(y) else y, delta_psi), \
           list(delta_psi).index(reduce(lambda x, y: x if np.abs(x) > np.abs(y) else y, delta_psi))

def print_result():
    print(f'\nДлина кривошипа: {a:.3f} \nДлина шатуна: {b:.3f} \nДлина коромысла: {c:.3f} \nДлина стойки: {d:.3f}')
    print(f'Максимальный угол давления: {max(v):.3f} при delta_phi = {phi_change[np.argmax(v)]:.3f}')
    print(f'Максимальное значение погрешности: {np.abs(max_error):.3f} при delta_phi = {phi_change[index_max_error]:.3f}')

def print_graphics():
    plt.plot(phi_change, psi_f)
    plt.plot(phi_change, [psi_f[i] + delta_psi[i] for i in range(len(phi_change))], color='pink')
    plt.plot([phi_change[index_max_error], phi_change[index_max_error]],
             [psi_f[index_max_error], psi_f[index_max_error] + max_error], color='purple', linewidth='3')
    plt.grid()
    plt.show()


alpha = 3
betta = np.radians(140)
k1 = 0.313
k2 = 0.13
v_d = 1.3

phi_m = 2 * np.pi
phi3 = phi_m
phi2 = 0.75 * phi_m
phi1 = 0.25 * phi_m
phi_change = np.arange(0, phi_m, 0.01)
d = 1

matrix_coefficients = [[np.cos(phi1 + alpha), np.cos(psi(phi1) + betta), 1],
                       [np.cos(phi2 + alpha), np.cos(psi(phi2) + betta), 1],
                       [np.cos(phi3 + alpha), np.cos(psi(phi3) + betta), 1]]
column_tree_members = [np.cos(phi1 + alpha - psi(phi1) - betta),
                       np.cos(phi2 + alpha - psi(phi2) - betta),
                       np.cos(phi3 + alpha - psi(phi3) - betta)]
p = np.linalg.solve(matrix_coefficients, column_tree_members)


a = 1 / p[1]
c = -1 / p[0]
b = np.sqrt(a * a + c * c + 1 - 2 * c * a * p[2])
#l_sqr = a**2 + 1 - 2 * a * np.cos(phi_elem);
v = [np.arcsin((b**2 + c**2 - (a**2 + 1 - 2 * a * np.cos(phi_elem))) / (2 * b * c)) for phi_elem in phi_change]

psi_f = [psi(phi_elem) for phi_elem in phi_change]

delta_q = [-2 * a * c * (p[0] * f0(phi_elem) + p[1] * f1(phi_elem) +
                         p[2] * f2() - F(phi_elem)) for phi_elem in phi_change]
delta_psi = [delta_q[i] / (2 * b * c * np.cos(v[i])) for i in range(len(phi_change))]

max_error, index_max_error = max_error()

print_result()
print_graphics()