def Main(data_item,data_weight,data_value,max_weight):
    def misha(data_item):
        return data_item[2]//data_item[1]

    data_sorted = sorted(zip(data_item, data_weight, data_value),\
                         key = misha, reverse=True)


    class State(object):
        def __init__(self, level, benefit, weight, token):
            # token = list marking if a task is token. ex. [1, 0, 0] means
            # item0 token, item1 non-token, item2 non-token
            # available = list marking all tasks available, i.e. not explored yet
            self.level = level
            self.benefit = benefit
            self.weight = weight
            self.token = token
            self.available = self.token[:self.level]+[1]*(len(data_sorted)-level)
            self.ub = self.upperbound()

        def upperbound(self):  # define upperbound using fractional knaksack
            upperbound = 0  # initial upperbound
            # accumulated weight used to stop the upperbound summation
            weight_accumulate = 0
            for avail, (_, wei, val) in zip(self.available, data_sorted):
                if wei * avail <= max_weight - weight_accumulate:
                    weight_accumulate += wei * avail
                    upperbound += val * avail
                else:
                    upperbound += val * (max_weight - weight_accumulate) / wei * avail
                    break
            return upperbound

        def develop(self):
            level = self.level + 1
            _, weight, value = data_sorted[self.level]
            left_weight = self.weight + weight
            if left_weight <= max_weight:  # if not overweighted, give left child
                left_benefit = self.benefit + value
                left_token = self.token[:self.level]+[1]+self.token[level:]
                left_child = State(level, left_benefit, left_weight, left_token)
            else:
                left_child = None
            # anyway, give right child
            right_child = State(level, self.benefit, self.weight, self.token)
            return ([] if left_child is None else [left_child]) + [right_child]


    Root = State(0, 0, 0, [0] * len(data_sorted))  # start with nothing
    waiting_States = []  # list of States waiting to be explored
    current_state = Root
    while current_state.level < len(data_sorted):
        waiting_States.extend(current_state.develop())
        # sort the waiting list based on their upperbound
        waiting_States.sort(key=lambda x: x.ub)
        # explore the one with largest upperbound
        current_state = waiting_States.pop()
    best_item = [item for tok, (item, _, _)
                 in zip(current_state.token, data_sorted) if tok == 1]

    return  current_state.weight,current_state.benefit,best_item