from ChooseSort import *
def insertion_sort(list1, countKey):
    countComp = 0
    countIter = 0
    for i in range(1, len(list1)):
        Value = list1[i]
        Position = i
        while Position > 0 and keyDictionary[countKey](list1[Position - 1], Value):
            list1[Position] = list1[Position - 1]
            Position = Position - 1
            countComp+=1
        list1[Position] = Value
        countIter += 1
    return countIter+countComp
def insertion_sort_with_check(list1, countKey):
    countComp = 0
    countIter = 0
    sort=sorted(list1,key=lambda x:(-x.i,x.d,x.s))
    for i in range(1, len(list1)):
        if(list1==sort):
            return countIter + countComp
        Value = list1[i]
        Position = i
        while Position > 0 and keyDictionary[countKey](list1[Position - 1], Value):
            list1[Position] = list1[Position - 1]
            Position = Position - 1
            countComp += 1
        list1[Position] = Value
        countIter += 1
    return countIter + countComp

def insertion_sort_with_check2(list1, countKey):
    countComp = 0
    countIter = 0
    sort = list1.copy()
    sort.sort()

    sort1 = sort.copy()

    for i in range(1, len(sort1)):
        if(sort1==sort):
            return countIter + countComp
        Value = sort1[i]
        Position = i
        while Position > 0 and keyDictionary[countKey](sort1[Position - 1], Value):
            sort1[Position] = sort1[Position - 1]
            Position = Position - 1
            countComp += 1
        list1[Position] = Value
        countIter += 1
    return countIter + countComp