using NET01._2Task;

try
{
    SquareMatrix<int> sqMatrix1 = new(3);
    sqMatrix1.MatrixElementChanged += sqMatrix1.WriteMatrixElementChangeDetails;
    sqMatrix1[0, 0] = 1;
    sqMatrix1[0, 1] = 2;
    sqMatrix1[0, 2] = 3;
    sqMatrix1[1, 2] = 4;

    Console.WriteLine(sqMatrix1.ToString());
    Console.WriteLine("/////////////////");
    //Console.WriteLine(sqMatrix1[0 ,3]);
    sqMatrix1[0, 0] = 9;
    Console.WriteLine("/////////////////");

    sqMatrix1[0, 0] = 9;

    Console.WriteLine(sqMatrix1.ToString());
    Console.WriteLine("/////////////////");
    SquareMatrix<float> sqMatrix2 = new(3);
    sqMatrix2.MatrixElementChanged += sqMatrix2.WriteMatrixElementChangeDetails;
    sqMatrix2[0, 0] = 9;

}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}



