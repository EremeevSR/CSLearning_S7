// Задача 47: Задайте двумерный массив размером m×n,
// заполненный случайными вещественными числами.
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

// При решении условимся, что размерность массива определяет
// пользователь путем ввода чисел M и N.
// Длина массива есть натуральное число от 1 до +бесконечности.
// Диапазон случайных чисел от 0 до 1.

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

double[,] CreateRndArray(int M, int N)
{
    // Метод возвращает двумерный массив (M x N) случайных
    // вещественных чисел в диапазоне от 0 до 1.
    double[,] rndArr = new double[M, N];
    Random rndNum = new Random();
    for (int i = 0; i < M; i++)
    {
        for (int j = 0; j < N; j++)
            rndArr[i, j] = rndNum.NextDouble();
    }
    return rndArr;
}

void ShowDoubleDimArray(double[,] array)
{
    // Метод выводит двумерный массив вещественных чисел.
    Console.WriteLine("Двумерный массив случайных вещественных чисел:");
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(string.Format("{0:f3}", array[i, j]) + "\t");
        }
        Console.WriteLine();
    }
}

Console.WriteLine("Введите размерность массива M x N:");
int M = DimensionInput();
int N = DimensionInput();
double[,] rndArray = CreateRndArray(M, N);
ShowDoubleDimArray(rndArray);