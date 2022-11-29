namespace CM_5.Models;

public class Matrix : ICloneable
{
    public double[,] MatrixElements { get; set; }

    public Matrix()
    {
        MatrixElements = new double[0, 0];
    }

    public Matrix(int i, int j)
    {
        MatrixElements = new double[i, j];
    }

    public Matrix(double[,] matrixElements)
    {
        MatrixElements=matrixElements;
    }

    public double this[int i, int j]
    {
        get => MatrixElements[i, j];
        set => MatrixElements[i, j] = value;
    }

    public int CountRows()
    {
        return MatrixElements.GetLength(0);
    }

    public int CountColumns()
    {
        return MatrixElements.GetLength(1);
    }

    public void LDUDecomposition()
    {
        var n = MatrixElements.GetLength(0);
        for (var i = 0; i < n; i++)
        {
            var sumD = 0.0;
            for (var j = 0; j < i; j++)
            {
                var sumL = 0.0;
                var sumU = 0.0;
                for (var k = 0; k < j; k++)
                {
                    sumL += MatrixElements[i, k] * MatrixElements[k, k] * MatrixElements[k, j];
                    sumU += MatrixElements[j, k] * MatrixElements[k, k] * MatrixElements[k, i];
                }

                MatrixElements[i, j] = (MatrixElements[i, j] - sumL) / MatrixElements[j, j];
                MatrixElements[j, i] = (MatrixElements[j, i] - sumU) / MatrixElements[j, j];
                sumD += MatrixElements[i, j] * MatrixElements[j, j] * MatrixElements[j, i];
            }
            MatrixElements[i, i] -= sumD;
        }
    }

    public void GenerateHilbert(int n)
    {
        MatrixElements = new double[n, n];

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                MatrixElements[i, j] = 1.0 / (i + 1 + j + 1 - 1);
            }
        }
    }

    public object Clone()
    {
        var clone = MatrixElements.Clone() as double[,];
        return new Matrix(CountRows(), CountColumns())
        {
            MatrixElements = clone
        };
    }
}