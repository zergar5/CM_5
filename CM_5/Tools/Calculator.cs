using CM_5.Models;

namespace CM_5.Tools;

public class Calculator
{
    public static Vector MultiplyMatrixOnVector(Matrix matrix, Vector vector)
    {
        var result = new Vector(vector.Count);
        for (var i = 0; i < matrix.CountRows(); i++)
        {
            for (var j = 0; j < matrix.CountColumns(); j++)
            {
                result[i] += matrix[i, j] * vector[j];
            }
        }
        return result;
    }
}