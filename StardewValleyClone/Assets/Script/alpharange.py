class AlphabetRange:
    #One arg
    """def one_char(self, letter):
        #Has to include the letters before the last, can't print out the last
        end_point = ord(letter)
        start_point = ord('A')

        print(chr(start_point) + "-" + chr(end_point), "1")
        for i in range(end_point):
            print(start_point + i + '\n')
    #Two args
    def two_chars(self,*args):
       for_loop = tuple(args)
       start_point = ord(for_loop[0])
       end_point = ord(for_loop[1])
       try:
           iter_num = for_loop[2]
       except IndexError:
            iter_num = 1

       print(chr(start_point) + "-" + chr(end_point), "1")
       for i in range(start_point, end_point, iter_num):
           print(start_point + i + '\n')"""
    def __init__(self, *args):
        self.for_loop = tuple(args)
        if len(self.for_loop) == 1:
            self.start_point = ord('A')
            self.end_point = ord(self.for_loop[0])
            self.iter_num = 1
        elif len(self.for_loop) == 2:
            self.start_point = ord(self.for_loop[0])
            self.end_point = ord(self.for_loop[1])
            self.iter_num = 1
        else:
            self.start_point = ord(self.for_loop[0])
            self.end_point = ord(self.for_loop[1])
            self.iter_num = self.for_loop[3]

        
    def __iter__(self):
        return self

    def __next__(self):
        the_end = self.end_point
        if the_end == self.end_point:
            raise StopIteration
        else:
            return the_end - 1

    def __str__(self):
        return #the_end #self.start_point + i + '\n'


    #Two w/ skip
#A - 101...


if __name__ == '__main__':
    letters = AlphabetRange('D')
    print(letters)
    for letter in letters:
        print(letter)

    """letters = AlphabetRange('B', 'E')
    print(letters)
    for letter in letters:
        print(letter)

    letters = AlphabetRange('C', 'L', 2)
    print(letters)
    for letter in letters:
        print(letter)"""