from numpy import array

def checkArray(arr):
    for i in range(7):
        for j in range(i+1, 7):
            if arr[i] == arr[j]:
                return False
    return True

def calculateNumbers() -> str:
    l = [0, 0, 0, 0, 0, 0, 0]
    answer = []
    for l[0] in range(10): # В
        for l[1] in range(10): # А
            for l[2] in range(10): # Г
                for l[3] in range(10): # О
                    for l[4] in range(10): # Н
                        for l[5] in range(10): # С
                            for l[6] in range(10): # Т
                                carriage = l[0] * 10000 + l[1] * 1000 + l[2] * 100 + l[3] * 10 + l[4]
                                train = l[5] * 100000 + l[3] * 10000 + l[5] * 1000 + l[6] * 100 + l[1] * 10 + l[0]
                                if carriage + carriage == train and checkArray(l):
                                    answer.append(array(l).view())
    return answer

if __name__ == "__main__":
    # Вагон + Вагон = Состав: В А Г О Н С Т
    answers = calculateNumbers()
    for answ in answers:
        print('''В({0})А({1})Г({2})О({3})Н({4}) +
В({0})А({1})Г({2})О({3})Н({4})
------------------------------
С({5})О({3})С({5})Т({6})А({1})В({0})
        '''.format(*answ))
    
