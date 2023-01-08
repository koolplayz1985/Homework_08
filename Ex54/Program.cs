// Задача 54: Задайте двумерный массив. Напишите программу,
// которая упорядочит по убыванию элементы каждой строки двумерного массива.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

// В итоге получается вот такой массив:
// 1 2 4 7
// 2 3 5 9
// 2 4 4 8

string[] GetUserInputNumbersString(string userInputTextString)
{
    Console.WriteLine(userInputTextString);
    string[] userInputString = Console.ReadLine().Split(",");
    return userInputString;
}

void CheckUserInputToInt(string[] userInputString)
{
    for (int i = 0; i < userInputString.Length; i++)
    {
        if (userInputString[i] == string.Empty || userInputString[i] == " "
            || Convert.ToInt32(userInputString[i]) == null
            || userInputString.Length < 2)
        {
            Console.WriteLine("Ошибка ввода данных. Попробуйте еще раз запустить программу и ввести данные корректно.");
            Environment.Exit(0);
        }
    }
}

int[] ConvertUserInputNumbersInt(string[] userNumberString)
{
    int[] userNumberInt = new int[userNumberString.Length];
    for (int i = 0; i < userNumberString.Length; i++)
    {
        userNumberInt[i] = Convert.ToInt32(userNumberString[i]);
    }
    return userNumberInt;
}

void FillMatrix2DInt(int[,] matrix, int min, int max)
{
    Random random = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = random.Next(min, max);
        }
    }
}

void SortLineElementsMatrix2D(int[,] matrix2D)
{
    int minValue = matrix2D[0, 0];
    for (int i = 0; i < matrix2D.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2D.GetLength(1); j++)
        {
            for (int k = j + 1; k < matrix2D.GetLength(1); k++)
            {
                if (matrix2D[i, j] > matrix2D[i, k]) continue;
                int temp = matrix2D[i, j];
                matrix2D[i, j] = matrix2D[i, k];
                matrix2D[i, k] = temp;
            }
        }
    }
}

void PrintMatrix2DInt(int[,] matrixTwoDimensional, string userOutputString)
{
    Console.WriteLine(userOutputString);
    for (int i = 0; i < matrixTwoDimensional.GetLength(0); i++)
    {
        Console.Write("[ ");
        for (int j = 0; j < matrixTwoDimensional.GetLength(1); j++)
        {
            if (matrixTwoDimensional[i, j] >= 0)
                Console.Write($" {matrixTwoDimensional[i, j]} ");
            else Console.Write($"{matrixTwoDimensional[i, j]} ");
        }
        Console.Write(" ]");
        Console.WriteLine();
    }
}


Console.Clear();
string[] matrixSizeString = GetUserInputNumbersString("Введите количество строк и столбцов массива через запятую: ");
CheckUserInputToInt(matrixSizeString);
int[] matrixSizeInt = ConvertUserInputNumbersInt(matrixSizeString);
string[] matrixMinMaxString = GetUserInputNumbersString("Введите границы интервала случайных чисел (через запятую): ");
CheckUserInputToInt(matrixMinMaxString);
int[] matrixMinMaxInt = ConvertUserInputNumbersInt(matrixMinMaxString);
int[,] matrixToSort = new int[matrixSizeInt[0], matrixSizeInt[1]];
FillMatrix2DInt(matrixToSort, matrixMinMaxInt[0], matrixMinMaxInt[1]);
PrintMatrix2DInt(matrixToSort, "Исходный массив: ");
SortLineElementsMatrix2D(matrixToSort);
PrintMatrix2DInt(matrixToSort, "Массив после сортировки: ");
