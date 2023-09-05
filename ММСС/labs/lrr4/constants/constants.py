import numpy as np
from full_factors_exp.full_factors_exp import get_full_factors_exp

count_factors = 3
ms_t = np.array([
    [4.307,	4.284,	4.284,	4.316,	4.286],
    [8.387,	8.396,	8.430,	8.389,	8.404],
    [5.832,	5.873,	5.856,	5.843,	5.862],
    [13.329, 13.304, 13.328, 13.340, 13.312],
    [7.379,	7.415,	7.415,	7.368,	7.368],
    [20.255, 20.278, 20.304, 20.279, 20.261],
    [11.226, 11.238, 11.271, 11.234, 11.273],
    [66.599, 66.605, 66.588, 66.595, 66.562]
])

average_ms_t = np.array([np.average(measures_of_persons) for measures_of_persons in ms_t])

average_ms = np.array([average_ms_t.transpose()])
xs = np.array(get_full_factors_exp(count_factors))
count_experiments = 2 ** count_factors

index_arrays = [
    [],
    [0],
    [1],
    [2],
    [0, 1],
    [0, 2],
    [1, 2],
    [0, 1, 2]
]