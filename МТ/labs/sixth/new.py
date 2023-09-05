
# Создаем класс узла автомата
class State:
  def __init__(self, name):
    self.name = name
    self.transitions = {}

  def add_transition(self, symbol, state):
    self.transitions[symbol] = state

  def get_transition(self, symbol):
    return self.transitions.get(symbol, None)


# Создаем класс ДКА
class DFA:
  def __init__(self, alphabet):
    self.alphabet = alphabet
    self.start_state = State("0")
    self.current_state = self.start_state
    self.accept_states = set()
    self.build()

  def build(self):
    # Создаем все необходимые состояния и переходы
    state1 = State("1")
    state2 = State("2")
    state3 = State("3")
    state4 = State("4")
    state5 = State("5")
    state6 = State("6")
    state7 = State("7")
    state8 = State("8")
    state9 = State("9")
    state10 = State("10")
    state11 = State("11")

    self.start_state.add_transition("begin", state1)
    state1.add_transition("p1", state2)
    state1.add_transition("p2", state2)
    state1.add_transition("p3", state2)
    state1.add_transition("p4", state2)
    state2.add_transition("(", state3)
    state3.add_transition("r1", state4)
    state3.add_transition("r2", state4)
    state3.add_transition("r3", state4)
    state3.add_transition("r4", state4)
    state3.add_transition("r5", state4)
    state3.add_transition("r6", state4)
    state3.add_transition("a1", state4)
    state3.add_transition("a2", state4)
    state3.add_transition("a3", state4)
    state3.add_transition("a4", state4)
    state3.add_transition("a5", state4)
    state3.add_transition("a6", state4)
    state4.add_transition("+", state5)
    state4.add_transition("-", state5)
    state4.add_transition("*", state6)
    state4.add_transition("/", state6)
    state5.add_transition("r1", state7)
    state5.add_transition("r2", state7)
    state5.add_transition("r3", state7)
    state5.add_transition("r4", state7)
    state5.add_transition("r5", state7)
    state5.add_transition("r6", state7)
    state5.add_transition("a1", state7)
    state5.add_transition("a2", state7)
    state5.add_transition("a3", state7)
    state5.add_transition("a4", state7)
    state5.add_transition("a5", state7)
    state5.add_transition("a6", state7)
    state6.add_transition("r1", state8)
    state6.add_transition("r2", state8)
    state6.add_transition("r3", state8)
    state6.add_transition("r4", state8)
    state6.add_transition("r5", state8)
    state6.add_transition("r6", state8)
    state6.add_transition("a1", state8)
    state6.add_transition("a2", state8)
    state6.add_transition("a3", state8)
    state6.add_transition("a4", state8)
    state6.add_transition("a5", state8)
    state6.add_transition("a6", state8)
    state8.add_transition("r1", state9)
    state8.add_transition("r2", state9)
    state8.add_transition("r3", state9)
    state8.add_transition("r4", state9)
    state8.add_transition("r5", state9)
    state8.add_transition("r6", state9)
    state8.add_transition("a1", state9)
    state8.add_transition("a2", state9)
    state8.add_transition("a3", state9)
    state8.add_transition("a4", state9)
    state8.add_transition("a5", state9)
    state8.add_transition("a6", state9)
    state9.add_transition(",", state3)
    state9.add_transition(")", state10)
    state5.add_transition(";", state2)
    state7.add_transition(";", state2)
    state10.add_transition(";", state2)
    state2.add_transition(",", state11)
    state11.add_transition("r1", state4)
    state11.add_transition("r2", state4)
    state11.add_transition("r3", state4)
    state11.add_transition("r4", state4)
    state11.add_transition("r5", state4)
    state11.add_transition("r6", state4)
    state11.add_transition("a1", state4)
    state11.add_transition("a2", state4)
    state11.add_transition("a3", state4)
    state11.add_transition("a4", state4)
    state11.add_transition("a5", state4)
    state11.add_transition("a6", state4)
    state11.add_transition("+", state5)
    state11.add_transition("-", state5)
    state11.add_transition("*", state6)
    state11.add_transition("/", state6)
    state5.add_transition("r1", state7)
    state5.add_transition("r2", state7)
    state5.add_transition("r3", state7)
    state5.add_transition("r4", state7)
    state5.add_transition("r5", state7)
    state5.add_transition("r6", state7)
    state5.add_transition("a1", state7)
    state5.add_transition("a2", state7)
    state5.add_transition("a3", state7)
    state5.add_transition("a4", state7)
    state5.add_transition("a5", state7)
    state5.add_transition("a6", state7)
    state6.add_transition("r1", state8)
    state6.add_transition("r2", state8)
    state6.add_transition("r3", state8)
    state6.add_transition("r4", state8)
    state6.add_transition("r5", state8)
    state6.add_transition("r6", state8)
    state6.add_transition("a1", state8)
    state6.add_transition("a2", state8)
    state6.add_transition("a3", state8)
    state6.add_transition("a4", state8)
    state6.add_transition("a5", state8)
    state6.add_transition("a6", state8)
    state8.add_transition("r1", state9)
    state8.add_transition("r2", state9)
    state8.add_transition("r3", state9)
    state8.add_transition("r4", state9)
    state8.add_transition("r5", state9)
    state8.add_transition("r6", state9)
    state8.add_transition("a1", state9)
    state8.add_transition("a2", state9)
    state8.add_transition("a3", state9)
    state8.add_transition("a4", state9)
    state8.add_transition("a5", state9)
    state8.add_transition("a6", state9)
    state9.add_transition(",", state11)
    state9.add_transition(")", state10)
    state5.add_transition(";", state2)
    state7.add_transition(";", state2)
    state10.add_transition(";", state2)

    # Устанавливаем конечные состояния
    self.accept_states.add(state2)

  def process_input(self, input_string):
    # Считываем входную строку символ за символом и делаем соответствующие переходы
    for symbol in input_string.split():
      if symbol in self.alphabet:
        self.current_state = self.current_state.get_transition(symbol)
      else:
        return False
    # Проверяем, является ли текущее состояние конечным
    if self.current_state in self.accept_states:
      return True
    else:
      return False


# Создаем экземпляр ДКА и проверяем правильность работы
alphabet = {"begin", "end", ";", ",", "*", "/", "+", "-", "(", ")", "p1", "p2", "p3", "p4", "a1", "a2", "a3", "a4", "a5", "a6", "r1", "r2", "r3", "r4", "r5", "r6"}
dfa = DFA(alphabet)

# Проверяем правильность работы на правильной конструкции
input_string1 = "begin p2(r5*a1+a4); p4(a3-a4/r3,r1*r1); end;"
print(dfa.process_input(input_string1)) # True

# Проверяем правильность работы на неправильной конструкции
input_string2 = "begin p2( r5*a1+a4); p4( a3-a4/r"
print(dfa.process_input(input_string2)) # False