import Generate
from Sort import *
import time
import  matplotlib.pyplot as plt
from BinarySearch import binary_search
list1 = Generate.generateArray(1000)

list2=list1.copy()
list3=list1.copy()
list4=list1.copy()


# start1=time.time()
# countWithOneKey=insertion_sort(list1, 1)
# end1=time.time()-start1
#
# print("1 Ключ")
# print(end1)
# print(countWithOneKey)
#
# start2=time.time()
# countWithDoubleKey=insertion_sort(list2, 2)
# end2=time.time()-start2
#
# print("2 Ключа")
# print(end2)
# print(countWithDoubleKey)
#
# start3=time.time()
# countWithThreeKey=insertion_sort(list3, 3)
# end3=time.time()-start3
#
# print("3 Ключа")
# print(end3)
# print(countWithThreeKey)
#
# start4=time.time()
# countWithCheckFourKey=insertion_sort_with_check(list4,3)
# end4=time.time()-start4
#
# print("3 Ключа с проверкой")
# print(end4)
# print(countWithCheckFourKey)
#
# print("Бинарный поиск")
# startSearch=time.time()
# takeElemInd=330
# takeElem=list4[takeElemInd]
# ind=binary_search(list(reversed(list4)),0,takeElem)
# end5=time.time()-startSearch
# if ind==len(list4)-(takeElemInd+1):
#     print("Элемент найден за "+str(end5)+"под индексом "+str(takeElemInd))

list5 = [1,2,21,4,76,87]
list6 = list5.copy()

count = insertion_sort(list5, 4)
print(list5)
print(count)

count2 = insertion_sort_with_check2(list6,4)
print(list6)
print(count2)