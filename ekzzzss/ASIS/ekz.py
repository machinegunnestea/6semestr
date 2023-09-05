import heapq
from collections import defaultdict

def get_frequencies(text):
    freq = defaultdict(int)
    for char in text:
        freq[char] += 1
    return freq

def build_huffman_tree(freq):
    heap = [[weight, [char, ""]] for char, weight in freq.items()]
    heapq.heapify(heap)
    while len(heap) > 1:
        lo = heapq.heappop(heap)
        hi = heapq.heappop(heap)
        for pair in lo[1:]:
            pair[1] = '0' + pair[1]
        for pair in hi[1:]:
            pair[1] = '1' + pair[1]
        heapq.heappush(heap, [lo[0] + hi[0]] + lo[1:] + hi[1:])
    return sorted(heapq.heappop(heap)[1:], key=lambda p: (len(p[-1]), p))

def encode(text, codes):
    encoded_text = ""
    for char in text:
        encoded_text += codes[char]
    return encoded_text

def decode(encoded_text, codes):
    decoded_text = ""
    current_code = ""
    for bit in encoded_text:
        current_code += bit
        for char, code in codes.items():
            if current_code == code:
                decoded_text += char
                current_code = ""
                break
    return decoded_text

# пример использования функций
text = "Коваленко Анастасия Игоревна 2003"
freq = get_frequencies(text)
tree = build_huffman_tree(freq)
codes = dict(tree)
encoded_text = encode(text, codes)
decoded_text = decode(encoded_text, codes)
print("Encoded text:", encoded_text)
print("Decoded text:", decoded_text)
print("Codes:")
for char, code in codes.items():
    print(char, ":", code)