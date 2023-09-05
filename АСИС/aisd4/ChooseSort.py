keyDictionary = {1: lambda x,y:x.i<y.i,
              2: lambda x,y:x.i < y.i or (x.i == y.i and x.d > y.d),
              3: lambda x,y:x.i<y.i or(x.i==y.i and x.d>y.d) or (x.i==y.i and x.d==y.d and x.s>y.s),
              4: lambda x,y:x>y}