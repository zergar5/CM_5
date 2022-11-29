using CM_5.Models;

namespace CM_5.Tools;

public class SLAESolver
{
    public static Vector SolveSLAE(Matrix matrix, Vector f)
    {
        var y = CalcY(matrix, f);
        CalcZ(matrix, y);
        CalcX(matrix, y);
        return y;
    }

    public static Vector CalcY(Matrix matrix, Vector f)
    {
        var n = f.Count;
        var y = (Vector)f.Clone();

        for (var i = 0; i < n; i++)
        {
            var sumL = 0.0;
            for (var j = 0; j < i; j++)
            {
                sumL += matrix[i, j] * y[j];
            }
            y[i] -= sumL;
        }
        return y;
    }

    public static void CalcZ(Matrix matrix, Vector y)
    {
        for (var i = 0; i < y.Count; i++)
        {
            y[i] /= matrix[i, i];
        }
    }

    public static void CalcX(Matrix matrix, Vector z)
    {
        for (var i = z.Count - 1; i >= 0; i--)
        {
            for (var j = 0; j < i; j++)
            {
                z[j] -= matrix[j, i] * z[i];
            }
        }
    }
}