using NET01._2Task;

try
{
    SquareMatrix<int> sqMatrix1 = new(3);
    sqMatrix1[0, 0] = 1;
    sqMatrix1[0, 1] = 2;
    sqMatrix1[0, 2] = 3;
    sqMatrix1[1, 4] = 4;
    Console.WriteLine(sqMatrix1.ToString());
    Console.WriteLine("/////////////////");
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}

