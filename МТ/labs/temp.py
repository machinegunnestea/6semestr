# Функция для поиска пути увеличения
def dfs(u, graph, match, visited):
    for v in graph[u]:
        if not visited[v]:
            visited[v] = True
            if match[v] == -1 or dfs(match[v], graph, match, visited):
                match[v] = u
                return True
    return False

# Функция для нахождения наибольшего паросочетания
def max_matching(graph):
    n = len(graph)
    match = [-1] * n
    for i in range(n):
        visited = [False] * n
        dfs(i, graph, match, visited)
    return match

# Пример использования
graph = [[1, 2], [0, 2], [0, 1]]
match = max_matching(graph)
print(match)



# [2, 0, 1]
