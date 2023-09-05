def dijkstra(graph, start_vertex):
    shortest_paths = {vertex: float('infinity') for vertex in graph}
    shortest_paths[start_vertex] = 0
    unvisited_vertices = list(graph.keys())

    while unvisited_vertices:
        current_min_vertex = min(unvisited_vertices, key=lambda vertex: shortest_paths[vertex])
        unvisited_vertices.remove(current_min_vertex)

        for neighbor, weight in graph[current_min_vertex].items():
            tentative_shortest_path = shortest_paths[current_min_vertex] + weight

            if tentative_shortest_path < shortest_paths[neighbor]:
                shortest_paths[neighbor] = tentative_shortest_path

    return shortest_paths


adjacency_matrix = [
    [0, 0, 2, 3, 4, 5],
    [0, 0, 0, 0, 0, 0],
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

graph = {}

for i, row in enumerate(graphNeeew):
    graph[i] = {j: weight for j, weight in enumerate(row) if weight != 0}

start_vertex = 0
shortest_paths = dijkstra(graph, start_vertex)

for vertex, distance in shortest_paths.items():
    print(f"Кратчайший путь от вершины {start_vertex} до вершины {vertex} равен {distance}")