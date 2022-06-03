// Задача 50: Напишите программу, которая на вход
// принимает позиции элемента в двумерном массиве, и
// возвращает значение этого элемента или же указание,
// что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

// Если опираясь на пример ввода/вывода положить, что
// позиция элемента определяется двухзначным числом,
// старший разряд которого есть номер строки, а младший
// разряд - номер столбца, то решение может быть следующим.

// При вызове программы задается двумерный массив случайной
// размерности (от 1 х 1 до 9 х 9, например), заполненный
// случайными целыми числами, положим, от 0 до 99, и выводится
// на экран. Затем пользователь вводит двузначное число с
// "координатами" элемента. Допустимый диапазон вводимых значений
// в таком случае лежит в пределах от 0 до 99, а однозначные
// числа будут восприниматься, как бутдо было введено число 0Х, где
// Х - число от 0 до 9.

int[,] CreateRndArray(int M, int N)
{
    // Метод возвращает двумерный массив (M x N) случайных
    // целых чисел в диапазоне от 1 до 99.
    int[,] rndArr = new int[M, N];
    Random rndNum = new Random();
    for (int i = 0; i < M; i++)
    {
        for (int j = 0; j < N; j++)
            rndArr[i, j] = rndNum.Next(0, 100);
    }
    return rndArr;
}

void ShowDoubleDimArray(int[,] array)
{
    // Метод выводит двумерный массив целых чисел.
    Console.WriteLine("Двумерный массив случайных целых чисел:");
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
}

bool IsInRange(int num, int M, int N)
{
    // Метод проверяет, находится ли число num в
    // диапазоне допустимых значений.
    if (num >= 0 && num <= ((M - 1) * 10 + N - 1)) return true;
    else return false;
}

void GetUserChoise(int[,] rndArr)
{
    // Метод осуществляет пользовательский ввод и его обработку.
    int userChoise = int.Parse(Console.ReadLine());
    int m = userChoise / 10;
    int n = userChoise % 10;
    if (IsInRange(userChoise, rndArr.GetLength(0), rndArr.GetLength(1)))
        Console.WriteLine($"Элемент массива с индексом ({m}, {n})" +
                          $" равен {rndArr[m, n]}");
    else
        Console.WriteLine("Такого числа в массиве нет");
}

int M = new Random().Next(1, 10);
int N = new Random().Next(1, 10);
int[,] rndArray = CreateRndArray(M, N);
ShowDoubleDimArray(rndArray);
Console.WriteLine("Введите позицию интересующего элемента MN:");
GetUserChoise(rndArray);