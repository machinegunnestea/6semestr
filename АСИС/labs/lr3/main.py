import branchesandborders
import dynamicprog
import time
import matplotlib.pyplot as mp


def readFromFile():
    items = [[], [], []]
    f = open("C:\\Users\\igrea\\OneDrive\\Рабочий стол\\textToWrite.txt", "r")
    for string in f:
        splitted = string.strip().split(" ")
        res = [eval(i) for i in splitted]
        items[0].append(res[0])
        items[1].append(res[1])
        items[2].append(res[2])
    f.close()
    return items


items = readFromFile()
data_item = items[2]
data_weight = items[0]
data_value = items[1]
max_weight = 10

print(branchesandborders.Main(data_item, data_weight, data_value, max_weight))
print(dynamicprog.Main(data_item, data_weight, data_value, max_weight))


def CalculateAlgTime(function, data_item, data_weight, data_value, max_weight):
    start = time.time()
    ans = function(data_item, data_weight, data_value, max_weight)
    return time.time() - start, ans


countElem = [10, 100, 1000]
timeBranch = [CalculateAlgTime(branchesandborders, data_item[:countElem[0]], data_weight[:countElem[0]],
                               data_value[:countElem[0]], max_weight[:countElem[0]][0]),
              CalculateAlgTime(branchesandborders, data_item[:countElem[1]], data_weight[:countElem[1]],
                               data_value[:countElem[1]], max_weight[:countElem[1]][0]),
              CalculateAlgTime(branchesandborders, data_item[:countElem[2]], data_weight[:countElem[2]],
                               data_value[:countElem[2]], max_weight[:countElem[2]][0])]
timeDynamic = [
    CalculateAlgTime(dynamicprog, data_item[:countElem[0]], data_weight[:countElem[0]], data_value[:countElem[0]],
                     max_weight[:countElem[0]][0]),
    CalculateAlgTime(dynamicprog, data_item[:countElem[1]], data_weight[:countElem[1]], data_value[:countElem[1]],
                     max_weight[:countElem[1]][0]),
    CalculateAlgTime(dynamicprog, data_item[:countElem[2]], data_weight[:countElem[2]], data_value[:countElem[2]],
                     max_weight[:countElem[2]][0])]
mp.plot(countElem, timeBranch)
mp.plot(countElem, timeDynamic)
mp.grid()
mp.show()
