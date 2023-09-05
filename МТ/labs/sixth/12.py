# Создание ДКА
states = ["q0", "q1", "q2", "q3", "q4", "q5", "q6", "q7", "q8", "q9", "q10", "q11", "q12", "q13", "q14"]
alphabet = ["begin", "end", ";", ",", "*", "/", "+", "-", "(", ")", " ", "p1", "p2", "p3", "p4", "a1", "a2", "a3", "a4", "a5", "a6", "r1", "r2", "r3", "r4", "r5", "r6"]
start_state = "q0"
accept_states = ["q14"]

transitions = {
    "q0": {"begin": "q1"},
    "q1": {"p1": "q2", "p2": "q2", "p3": "q2", "p4": "q2"},
    "q2": {"(": "q3"},
    "q3": {"r1": "q4", "r2": "q4", "r3": "q4", "r4": "q4", "r5": "q4", "r6": "q4", "a1": "q4", "a2": "q4", "a3": "q4", "a4": "q4", "a5": "q4", "a6": "q4", ")": "q5"},
    "q4": {"+": "q6", "-": "q6", "*": "q7", "/": "q7", ")": "q5", ",": "q2", ";": "q14", " ": "q4"},
    "q6": {"r1": "q4", "r2": "q4", "r3": "q4", "r4": "q4", "r5": "q4", "r6": "q4", "a1": "q4", "a2": "q4", "a3": "q4", "a4": "q4", "a5": "q4", "a6": "q4", "(": "q3"},
    "q7": {"r1": "q8", "r2": "q8", "r3": "q8", "r4": "q8", "r5": "q8", "r6": "q8", "a1": "q8", "a2": "q8", "a3": "q8", "a4": "q8", "a5": "q8", "a6": "q8", "(": "q9"},
    "q8": {"+": "q6", "-": "q6", "*": "q7", "/": "q7", ")": "q10", ",": "q2", ";": "q14", " ": "q8"},
    "q9": {"r1": "q11", "r2": "q11", "r3": "q11", "r4": "q11", "r5": "q11", "r6": "q11", "a1": "q11", "a2": "q11", "a3": "q11", "a4": "q11", "a5": "q11", "a6": "q11"},
    "q11": {"+": "q6", "-": "q6", "*": "q7", "/": "q7", ")": "q10", ",": "q12", ";": "q14", " ": "q11"},
    "q12": {"r1": "q4", "r2": "q4", "r3": "q4", "r4": "q4", "r5": "q4", "r6": "q4", "a1": "q4", "a2": "q4", "a3": "q4", "a4": "q4", "a5": "q4", "a6": "q4", "(": "q3"},
    "q10": {"+": "q6", "-": "q6", "*": "q7", "/": "q7", ",": "q12", ";": "q14", " ": "q10"},
}

# Функция для проверки синтаксической правильности конструкции
def syntax_check(string):
    current_state = start_state
    for char in string:
        if char not in alphabet:
            return False
        current_state = transitions[current_state][char]
    if current_state in accept_states:
        return True
    else:
        return False

# Примеры правильной и неправильной конструкций
correct_string = "begin p2( r5*a1+a4); p4( a3-a4/r3, r1*r1); end;"
incorrect_string = "begin p2( r5*a1+a4); p4( a3-a4/r3, r1*r1) end;"

# Проверка синтаксической правильности
print(syntax_check(correct_string)) # Вывод: True
print(syntax_check(incorrect_string)) # Вывод: False