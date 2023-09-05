from collections import deque

def bfs(graph, start):
    # создаем пустой список для хранения ребер остовного дерева
    tree = []

    # создаем список посещенных вершин и добавляем в него начальную вершину
    visited = [start]

    # создаем очередь для обработки вершин в порядке их посещения
    queue = deque([start])

    # обходим граф в ширину, добавляя все ребра в остовное дерево
    while queue:
        vertex = queue.popleft()
        for neighbor, weight in enumerate(graph[vertex]):
            if weight > 0 and neighbor not in visited:
                visited.append(neighbor)
                tree.append((vertex, neighbor))
                queue.append(neighbor)

    return tree


# пример использования
adjacency_matrix = [
    [0, 0, 2, 3, 4, 5],
    [0, 0, 2, 4, 0, 0],
    [2, 2, 0, 1, 1, 0],
    [3, 4, 1, 0, 0, 1],
    [4, 0, 1, 0, 0, 1],
    [5, 0, 0, 1, 1, 0]
]
graphNeeew = [
    [0, 0, 2, 0, 0, 0, 2],
    [0, 0, 2, 0, 0, 0, 2],
    [2, 2, 0, 1, 1, 3, 4],
    [0, 0, 1, 0, 0, 1, 0],
    [0, 0, 1, 0, 0, 1, 0],
    [0, 0, 3, 1, 1, 0, 0],
    [2, 2, 4, 0, 0, 0, 0]
]
tree = bfs(graphNeeew, 0)
print("Остовное дерево:")
for edge in tree:
    print(f"Ребро ({edge[0]}, {edge[1]})")