def bfs_connected(graph):
    # инициализируем очередь и список visited
    queue = []
    visited = [False] * len(graph)

    # счетчик компонент связности
    count = 0

    for start in range(len(graph)):
        if not visited[start]:
            # начинаем алгоритм с не посещенной вершины
            queue.append(start)
            visited[start] = True

            # увеличиваем счетчик компонент связности
            count += 1

            # список вершин текущей компоненты связности
            components = [start]

            while queue:
                # извлекаем вершину из очереди
                vertex = queue.pop(0)

                # перебираем всех соседей вершины
                for neighbor in range(len(graph[vertex])):
                    # если есть ребро и сосед еще не посещен
                    if graph[vertex][neighbor] > 0 and not visited[neighbor]:
                        # добавляем соседа в очередь и отмечаем как посещенный
                        queue.append(neighbor)
                        visited[neighbor] = True

                        # добавляем соседа в список вершин текущей компоненты связности
                        components.append(neighbor)

            # выводим вершины текущей компоненты связности
            print(f"Компонента связности {count}: {components}")

    # если все вершины были посещены, то граф связный
    if count == 1:
        print("Граф связный")
    else:
        print(f"Граф не связный, количество компонент связности: {count}")


# пример использования
graph1 = [
    [0, 0, 2, 3, 4, 5],
    [0, 0, 0, 0, 0, 0],
    [2, 0, 0, 1, 1, 0],
    [3, 0, 1, 0, 0, 1],
    [4, 0, 1, 0, 0, 1],
    [5, 0, 0, 1, 1, 0]
]
graph = [
    [0, 0, 2, 3, 4, 5],
    [0, 0, 2, 4, 0, 0],
    [2, 2, 0, 1, 1, 0],
    [3, 4, 1, 0, 0, 1],
    [4, 0, 1, 0, 0, 1],
    [5, 0, 0, 1, 1, 0]
]
graphNeeew = [
    [0, 0, 0, 0, 0, 0, 2],
    [0, 0, 0, 0, 0, 0, 2],
    [0, 0, 0, 0, 0, 0, 0],
    [0, 0, 0, 0, 0, 1, 0],
    [0, 0, 0, 0, 0, 1, 0],
    [0, 0, 0, 1, 1, 0, 0],
    [2, 2, 0, 0, 0, 0, 0]
]

bfs_connected(graphNeeew)
