using NET012.Task;

try
{
    SquareMatrix<int> sqMatrix1 = new(3);
    sqMatrix1.MatrixElementChanged += sqMatrix1.WriteMatrixElementChangeDetails;
    sqMatrix1.MatrixElementChanged += delegate { Console.WriteLine("Anonymous method for eventhandler"); };
    sqMatrix1.MatrixElementChanged += (sender, e) => Console.WriteLine("Lambda expression for eventhandler");

    sqMatrix1[0, 0] = 1;
    sqMatrix1[0, 1] = 2;
    sqMatrix1[0, 2] = 3;
    sqMatrix1[1, 2] = 4;

    Console.WriteLine(sqMatrix1.ToString());
    Console.WriteLine("/////////////////");

    sqMatrix1[0, 0] = 9;
    Console.WriteLine("/////////////////");

    sqMatrix1[0, 0] = 9;

    Console.WriteLine(sqMatrix1.ToString());
    Console.WriteLine("/////////////////");
    SquareMatrix<float> sqMatrix2 = new(3);
    sqMatrix2.MatrixElementChanged += sqMatrix2.WriteMatrixElementChangeDetails;
    sqMatrix2[0, 0] = 18;
    Console.WriteLine("/////////////////");
    DiagonalMatrix<int> diagMatrix1 = new(3);
    diagMatrix1.MatrixElementChanged += diagMatrix1.WriteMatrixElementChangeDetails;
    Console.WriteLine(diagMatrix1.ToString());
    Console.WriteLine("/////////////////");

    diagMatrix1[0, 0] = 9;
    Console.WriteLine("XXXXXXXXXXXXXXX");

    diagMatrix1[1, 1] = 27;

    Console.WriteLine(diagMatrix1.ToString());

}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}



