// Доп. задание.
// Задать целочисленный двумерный массив размерности n х m.
// Выяснить, в какой строке последовательность является 
// возрастающей или убывающей.

// Условимся при решении, что размерность массива определяет
// пользователь. Хорошо проверяется массив размерностью 10 х 3.
// Чем больше N, тем меньше вероятность, что сгенерируется 
// убывающая или возрастающая строка, но увеличение M
// увеличивает эту вероятность.

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
            rndArr[i, j] = rndNum.Next(0, 100);
    }
    return rndArr;
}

void ShowAnalysisResult(int marker)
{
    // Метод выводит строку, соответствующую маркеру
    // метода IncreaseAndDecreaseAnalysis.
    switch (marker)
    {
        case 0: Console.WriteLine(" - без закономерности"); break;
        case 1: Console.WriteLine(" - возрастающая строка"); break;
        case -1: Console.WriteLine(" - убывающая строка"); break;
    }
}

int IncreaseAndDecreaseAnalysis(int[,] arr, int row)
{
    // Метод возвращает маркер:
    // 1  - строка возрастающая;
    // -1 - строка убывающая;
    // 0  - без закономерности.
    bool increase = true, decrease = true;
    for (int i = 0; i < arr.GetLength(1) - 1; i++)
    {
        if (arr[row, i] < arr[row, i + 1]) increase &= true;
        else increase &= false;
        if (arr[row, i] > arr[row, i + 1]) decrease &= true;
        else decrease &= false;
    }
    // Наиболее вероятный исход при случайной генерации чисел
    // !(false || false) = true проверяется первым. 
    if (!(increase || decrease)) return 0;
    if (increase) return 1; //increase = true             
    else return -1;         //decrease = false
}

void ShowArrayRow(int[,] arr, int row)
{
    // Метод выводит строку row массива arr.
    for (int i = 0; i < arr.GetLength(1) - 1; i++)
    {
        Console.Write($"{arr[row, i]}, ");
    }
    Console.Write($"{arr[row, arr.GetLength(1) - 1]}");
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

Console.WriteLine("Введите размерность массива M x N:");

int M = DimensionInput();
int N = DimensionInput();

int[,] rndArray = CreateRndArray(M, N);
ShowDoubleDimArray(rndArray);
Console.WriteLine();

if (rndArray.GetLength(1) >= 2)
    for (int i = 0; i < rndArray.GetLength(0); i++)
    {
        ShowArrayRow(rndArray, i);
        ShowAnalysisResult(IncreaseAndDecreaseAnalysis(rndArray, i));
    }
else
    Console.WriteLine("Массив с одним столбцом не может быть проанализирован.");