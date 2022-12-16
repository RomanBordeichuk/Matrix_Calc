using System.Reflection.PortableExecutable;

Console.Write("Enter the matrix's degree: ");
int matDeg = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("------------");

float[,] matrix = new float[matDeg, matDeg];

for (int i = 0; i < matDeg; i++)
{
    Console.WriteLine($"{i + 1}: ");

    for (int j = 0; j < matDeg; j++)
    {
        Console.Write($"a({i + 1},{j + 1}): ");
        matrix[i, j] = float.Parse(Console.ReadLine()); 
    }

    Console.WriteLine();
}

Console.WriteLine("------------");
//----------------------------------------------------

DisplayMatrix();

bool detZero = false;
int koef = 1;

for (int i = 0; i < matDeg && !detZero; i++)
{
    int n = 0;
    while (matrix[n + i, i] == 0)
    {
        if (n < matDeg - i - 1) n++;
        else
        {
            detZero = true;
            break;
        }
    };

    for(int j = 0; j < matDeg; j++)
    {
        float l = matrix[i, j];
        matrix[i, j] = matrix[n + i, j];
        matrix[n + i, j] = l;
    }
    if (n > 0) koef *= -1;

    for(int j = 1; j < matDeg - i; j++)
    {
        float k = -1 * matrix[j + i, i] / matrix[i, i];

        for(int l = 0; l < matDeg; l++)
        {
            matrix[j + i, l] += k * matrix[i, l]; 
        }
    }

    DisplayMatrix();
}

float detMatrix = 1;

if (detZero) detMatrix = 0;
else
{
    for (int i = 0; i < matDeg; i++)
    {
        detMatrix *= matrix[i, i];
    }
}

detMatrix *= koef;

Console.WriteLine($"Determinant of matrix: {detMatrix}");

//-----------------------------------------------------

void DisplayMatrix()
{
    for (int m = 0; m < matDeg; m++)
    {
        for (int j = 0; j < matDeg; j++)
        {
            Console.Write("    " + matrix[m, j]);
        }
        Console.WriteLine();
    }

    Console.ReadLine();
    Console.WriteLine("------------");
}