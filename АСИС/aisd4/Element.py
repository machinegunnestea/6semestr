class Element:
    def __init__(self,int , data, str):
        self.i = int
        self.d = data
        self.s = str

    def __str__(self):
        return str.format("({},{},{})", self.i, self.d,self.s)
