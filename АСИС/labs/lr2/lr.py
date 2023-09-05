import random
import time
import matplotlib.pyplot as plt

class Node:
    def __init__(self, val, nextPtr=None):
        self.val = val
        self.nextPtr = nextPtr


class LinkedList:
    def __init__(self):
        self.head = None

    def insertMany(self, dataArray):
       if len(dataArray) == 0:
          return

       if self.head == None:
          self.insert(dataArray[0])
          dataArray.pop(0)

       current = self.getLastNode()

       for element in dataArray:
          current.nextPtr = Node(element)
          current = current.nextPtr

    def getLastNode(self):
       if self.head == None:
          return None

       current = self.head

       while (current.nextPtr):
          current = current.nextPtr
       return current

    def insert(self, data):
        newNode = Node(data)
        if (self.head):
            current = self.head
            while (current.nextPtr):
                current = current.nextPtr
            current.nextPtr = newNode
        else:
            self.head = newNode

    def deleteHead(self):
        self.head = self.head.nextPtr

    def countList(self):
        temp = self.head
        listLen = 0
        while (temp != None):
            temp = temp.nextPtr
            listLen += 1
        return listLen

    def delete(self, nodeIndex):
        temp1 = self.head
        temp2 = None

        if (self.head == None):
            print("List is empty")
            return

        if (self.countList() < nodeIndex):
            print("Index out of range")
            return

        if (nodeIndex == 1):
            self.deleteHead()
            return

        while (nodeIndex > 1):
            temp2 = temp1
            temp1 = temp1.nextPtr
            nodeIndex -= 1

        temp2.nextPtr = temp1.nextPtr

    def printLL(self):
        current = self.head
        while (current):
            print(current.val)
            current = current.nextPtr

    def sortedMerge(self, a, b):
        result = None
        # Base cases
        if a == None:
            return b
        if b == None:
            return a
        # pick either a or b and recur..
        if a.val <= b.val:
            result = a
            result.nextPtr = self.sortedMerge(a.nextPtr, b)
        else:
            result = b
            result.nextPtr = self.sortedMerge(a, b.nextPtr)
        return result

    def mergeSort(self, h):
        if h == None or h.nextPtr == None:
            return h

        # get the middle of the list
        middle = self.getMiddle(h)
        nexttomiddle = middle.nextPtr

        # set the next of middle node to None
        middle.nextPtr = None

        # Apply mergeSort on left list
        left = self.mergeSort(h)

        # Apply mergeSort on right list
        right = self.mergeSort(nexttomiddle)

        # Merge the left and right lists
        sortedlist = self.sortedMerge(left, right)
        return sortedlist

        # Utility function to get the middle
        # of the linked list
    def __contains__(self, list):
        current=self.head
        while (current):
            current1 = list.head
            while (current1):
                if (current.val == current1.val):
                    return  True
                current1 = current1.nextPtr
            current = current.nextPtr
        return  False

    def getMiddle(self, head):
        if (head == None):
            return head

        slow = head
        fast = head

        while (fast.nextPtr != None and
               fast.nextPtr.nextPtr != None):
            slow = slow.nextPtr
            fast = fast.nextPtr.nextPtr

        return slow

    def sort(self):
        self.mergeSort(self.head)
    def task1(self, temp1, temp2):
        current = self.head
        while (current):
            current1 = temp1.head
            while (current1):
                if (current.val == current1.val and not temp1.__contains__(temp2)):
                    temp2.insert(current.val)
                current1 = current1.nextPtr
            current = current.nextPtr

def AlghoritmTime(n,m):
   inputData1 = random.sample(range(10000), n)
   inputData2 = random.sample(range(10000), m)
   temp1 = LinkedList()
   temp2 = LinkedList()
   temp3 = LinkedList()
   temp1.insertMany(inputData1)
   temp2.insertMany(inputData2)
   start_time = time.time()
   temp1.task1(temp2,temp3)
   end_time=time.time()
   return end_time-start_time
amountOfElementsF = [100 ,1000,10000]
amountOfElementsS = [100, 1000 ,10000]
timeResults = [AlghoritmTime(amountOfElementsF[0],amountOfElementsS[0]),
               AlghoritmTime(amountOfElementsF[1],amountOfElementsS[1]),
               AlghoritmTime(amountOfElementsF[2], amountOfElementsS[2])
              ]
print(timeResults)
plt.plot(amountOfElementsF, timeResults)
plt.grid()
plt.show()
