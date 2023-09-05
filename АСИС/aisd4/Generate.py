import random
import string
from datetime import date, datetime, timedelta
from random import randint
from Element import Element
def gen_datetime(min_year=1900, max_year=datetime.now().year):
    start = datetime(min_year, 1, 1, 00, 00, 00)
    years = max_year - min_year + 1
    end = start + timedelta(days=365 * years)
    return datetime.date(start + (end - start) * random.random())
def generate_random_string():
    letters = string.ascii_lowercase
    rand_string = ''.join(random.choice(letters) for i in range(7))
    return rand_string
def gen_int():
    return randint(0,1000)
def generateArray(size):
    list=[]
    i=0
    while i<size:
        list.append(Element(gen_int(),gen_datetime(),generate_random_string()))
        i+=1
    return list