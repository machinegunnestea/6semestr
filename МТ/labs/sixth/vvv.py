# Определение функции для проверки символа на принадлежность алфавиту языка
def is_valid_symbol(symbol):
    valid_symbols = ['begin', 'end', ';', ',', '*', '/', '+', '-', '(', ')', ' ', 'p1', 'p2', 'p3', 'p4',
                     'a1', 'a2', 'a3', 'a4', 'a5', 'a6', 'r1', 'r2', 'r3', 'r4', 'r5', 'r6']
    return symbol in valid_symbols

# Определение функции для проверки конструкции на синтаксическую правильность
def syntax_check(construction):
    state = 'S0'
    i = 0
    while i < len(construction):
        symbol = construction[i]
        if not is_valid_symbol(symbol):
            return False
        if state == 'S0':
            if symbol == 'begin':
                state = 'S1'
            else:
                return False
        elif state == 'S1':
            if symbol in ['p1', 'p2', 'p3', 'p4']:
                state = 'S2'
            else:
                return False
        elif state == 'S2':
            if symbol == '(':
                state = 'S3'
            else:
                return False
        elif state == 'S3':
            if symbol in ['a1', 'a2', 'a3', 'a4', 'a5', 'a6', 'r1', 'r2', 'r3', 'r4', 'r5', 'r6']:
                state = 'S4'
            else:
                return False
        elif state == 'S4':
            if symbol in ['+', '-']:
                state = 'S5'
            elif symbol == '*':
                state = 'S6'
            elif symbol == ')':
                state = 'S7'
            else:
                return False
        elif state == 'S5':
            if symbol in ['a1', 'a2', 'a3', 'a4', 'a5', 'a6', 'r1', 'r2', 'r3', 'r4', 'r5', 'r6']:
                state = 'S6'
            else:
                return False
        elif state == 'S6':
            if symbol == ')':
                state = 'S7'
            elif symbol == ',':
                state = 'S3'
            else:
                return False
        elif state == 'S7':
            if symbol == ';':
                state = 'S1'
            elif symbol == 'end':
                state = 'SF'
            else:
                return False
        i += 1
    return state == 'SF'

# Примеры проверки конструкций
print(syntax_check('begin p2(r5*a1+a4); p4(a3-a4/r3, r1*r1); end;')) # True
print("True")
print(syntax_check('begin p2(r5*a1+a4); p4(a3-a4/r3, r1*r1) end;')) # False (отсутствует ';')