def binary_search(sequence, start_element, key):
    end_element = len(sequence) - 1
    while start_element <= end_element:
        middle_element = start_element + (end_element - start_element) // 2
        if sequence[middle_element].i == key.i and sequence[middle_element].d==key.d and sequence[middle_element].s==key.s :
            return middle_element
        elif sequence[middle_element].i < key.i or (sequence[middle_element].i == key.i and sequence[middle_element].d<key.d )\
                or (sequence[middle_element].i == key.i and sequence[middle_element].d==key.d and sequence[middle_element].s<key.s):
            start_element = middle_element + 1
        else:
            end_element = middle_element - 1
    return -1

