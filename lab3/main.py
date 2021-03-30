class Node:

    def __init__(self, childrens = {}, comment = '', answer = ''):
        self._childrens = childrens
        self._comment = comment
        self._answer = answer

    def moveTo(self, answer):
        return self._childrens.get(answer)

    @property
    def comment(self):
        return self._comment

    @property
    def answer(self):
        return self._answer

    @property
    def childrens(self):
        return self._childrens

class Interpreter:

    def __init__(self, root):
        self._root = root
        self._currentPos = root

    def run(self):
        while self._currentPos != None:
            if self._currentPos.answer:
                print('>>', self._currentPos.answer)
                break

            options = ','.join(["{0}({1})".format(child, ind) for ind, child in enumerate(self._currentPos.childrens.keys())])
            print(f"?{self._currentPos.comment}: {options}")
            try:
                index = int(input())
            except ValueError:
                continue
            if index > len(self._currentPos.childrens)-1 or index < 0: continue

            self._currentPos = list(self._currentPos.childrens.values())[index]

    def __moveTo(self, answer):
        if self._currentPos.answer: print('>>', self._currentPos.answer)
        self._currentPos = self._currentPos.moveTo(answer)


if __name__ == '__main__':
    # q4
    answer1 = Node(answer='яблоки')
    answer2 = Node(answer='груши')
    question4 = Node({'круглая': answer1, 'продолговатая': answer2}, 'форма плодов')

    # q5
    answer1 = Node(answer='вишня')
    answer2 = Node(answer='сливы')
    question5 = Node({'ягоды': answer1, 'фрукты': answer2}, 'это')

    # q3
    answer1 = Node(answer='смородина')
    answer2 = Node(answer='черника')
    answer3 = Node(answer='клюква')
    question3 = Node({'в саду': answer1, 'в лесу': answer2, 'на болоте': answer3}, 'произрастает')

    # q2
    question2 = Node({'крупные': question4, 'мелкие': question5}, 'плоды')

    # q1
    question1 = Node({'на дереве': question2, 'на кусте или земле': question3}, 'растет')

    _ = Interpreter(question1).run()