// Задача 52: Задайте двумерный массив из целых чисел.
// Найдите среднее арифметическое элементов в каждом
// столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого
// столбца: 4,6; 5,6; 3,6; 3.

// При решении условимся, что размерность массива определяет
// пользователь, а диапазон значений элементов массива
// от 0 до 9 для простоты проверки.

char dimension = 'M';

bool IsNatural(int number)
{
    // Метод определяет, является ли число number натуральным.
    if (number >= 1) return true;
    else return false;
}

int DimensionInput()
{
    // Метод ввода количества строк М и столбцов N двумерного массива.
    Console.Write($"{dimension} - ");
    int result = int.Parse(Console.ReadLine());
    while (!IsNatural(result))
    {
        Console.Write($"Число должно быть больше нуля. Повторите ввод:\n{dimension} - ");
        result = int.Parse(Console.ReadLine());
    }
    dimension++;
    return result;
}

int[,] CreateRndArray(int M, int N)
{
    // Метод возвращает двумерный массив (M x N) случайных
    // вещественных чисел в диапазоне от 0 до 1.
    int[,] rndArr = new int[M, N];
    Random rndNum = new Random();
    for (int i = 0; i < M; i++)
    {
        for (int j = 0; j < N; j++)
            rndArr[i, j] = rndNum.Next(0, 10);
    }
    return rndArr;
}

void ShowDoubleDimArray(int[,] array)
{
    // Метод выводит двумерный массив вещественных чисел.
    Console.WriteLine("Двумерный массив случайных вещественных чисел:");
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
}

double[] CalcAverageColVal(int[,] arr)
{
    // Метод возвращает массив средних арифметических значений
    // элементов массива arr по столбцам.
    double[] averages = new double[arr.GetLength(1)];
    double sum = 0;
    for (int i = 0; i < arr.GetLength(1); i++)
    {
        for (int j = 0; j < arr.GetLength(0); j++)
            sum += arr[j, i];
        averages[i] = sum / arr.GetLength(0);
        sum = 0;
    }
    return averages;
}

void ShowArray(double[] arr)
{
    // Метод выводит массив среднего арифметического столбцов.
    for (int i = 0; i < arr.Length - 1; i++)
        Console.Write(string.Format("{0:f2}", arr[i]) + ", ");
    Console.WriteLine(string.Format("{0:f2}", arr[arr.Length - 1]) + ".");
}

Console.WriteLine("Введите размерность массива M x N:");

int M = DimensionInput();
int N = DimensionInput();

int[,] rndArray = CreateRndArray(M, N);
ShowDoubleDimArray(rndArray);

double[] averages = CalcAverageColVal(rndArray);
Console.Write("Среднее арифметическое каждого столбца:");
ShowArray(averages);