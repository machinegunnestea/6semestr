def Main(data_item,data_weight,data_value,max_weight):
    def get_memtable(weights,values, A):
        n = len(values)  # находим размеры таблицы

        # создаём таблицу из нулевых значений
        V = [[0 for a in range(A + 1)] for i in range(n + 1)]

        for i in range(n + 1):
            for a in range(A + 1):
                # базовый случай
                if i == 0 or a == 0:
                    V[i][a] = 0

                # если площадь предмета меньше площади столбца,
                # максимизируем значение суммарной ценности
                elif weights[i - 1] <= a:
                    V[i][a] = max(values[i - 1] + V[i - 1][a - weights[i - 1]], V[i - 1][a])

                # если площадь предмета больше площади столбца,
                # забираем значение ячейки из предыдущей строки
                else:
                    V[i][a] = V[i - 1][a]
        return V, weights, values


    def get_selected_items_list(weights,values,names, A):
        V, area, value = get_memtable(weights,values,A)
        n = len(value)
        res = V[n][A]  # начинаем с последнего элемента таблицы
        a = A  # начальная площадь - максимальная
        items_list = []  # список площадей и ценностей

        for i in range(n, 0, -1):  # идём в обратном порядке
            if res <= 0:  # условие прерывания - собрали "рюкзак"
                break
            if res == V[i - 1][a]:  # ничего не делаем, двигаемся дальше
                continue
            else:
                # "забираем" предмет

                items_list.append((area[i - 1], value[i - 1],names[i-1]))
                res -= value[i - 1]  # отнимаем значение ценности от общей
                a -= area[i - 1]  # отнимаем площадь от общей


        # находим ключи исходного словаря - названия предметов
        weightS=sum([x[0] for x in items_list])
        valueS=sum([x[1] for x in items_list])
        return weightS,valueS,[x[2] for x in items_list]

    return get_selected_items_list(data_weight,data_value,data_item,max_weight)