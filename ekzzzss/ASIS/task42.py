def kruskal(graph):
    # создаем список ребер и сортируем его по возрастанию весов
    edges = []
    for i in range(len(graph)):
        for j in range(i+1, len(graph)):
            if graph[i][j] > 0:
                edges.append((graph[i][j], i, j))
    edges.sort()

    # создаем список множеств для каждой вершины
    sets = [set([i]) for i in range(len(graph))]

    # создаем пустой список для хранения ребер остовного дерева
    tree = []

    # перебираем все ребра и добавляем их в остовное дерево, если они не создадут цикл
    for edge in edges:
        weight, vertex1, vertex2 = edge
        set1 = None
        set2 = None
        for s in sets:
            if vertex1 in s:
                set1 = s
            if vertex2 in s:
                set2 = s
        if set1 != set2:
            tree.append(edge)
            set1.update(set2)
            sets.remove(set2)

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
tree = kruskal(graphNeeew)
print("Минимальное остовное дерево:")
for edge in tree:
    print(f"Ребро ({edge[1]}, {edge[2]}) весом {edge[0]}")



tree = kruskal(adjacency_matrix)
print("Минимальное остовное дереводля нового графа:")
for edge in tree:
    print(f"Ребро ({edge[1]}, {edge[2]}) весом {edge[0]}")