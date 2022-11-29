using CM_5.Models;

namespace CM_5.Tools;

public class EigenvalueFinder
{
    public static double FindMax(in Matrix matrix, in Vector startVector, double eps, int maxIter)
    {
        var prevVector = (Vector)startVector.Clone();
        var nextVector = Calculator.MultiplyMatrixOnVector(matrix, prevVector);
        var eigenvalue = nextVector.CalcNorm() / prevVector.CalcNorm();
        var residual = 1.0;
        prevVector = nextVector;
        CourseHolder.GetInfo(1, eigenvalue, residual);
        for (var i = 2; i <= maxIter && residual > eps; i++)
        {
            var prevEigenvalue = eigenvalue;
            nextVector = Calculator.MultiplyMatrixOnVector(matrix, prevVector);
            eigenvalue = nextVector.CalcNorm() / prevVector.CalcNorm();
            residual = Math.Abs((eigenvalue - prevEigenvalue) / eigenvalue);
            prevVector = nextVector;
            CourseHolder.GetInfo(i, eigenvalue, residual);
        }

        Console.WriteLine();
        return eigenvalue;
    }

    public static double FindMin(in Matrix matrix, in Vector startVector, double eps, int maxIter)
    {
        matrix.LDUDecomposition();
        var prevVector = (Vector)startVector.Clone();
        var nextVector = SLAESolver.SolveSLAE(matrix, prevVector);
        var eigenvalue = nextVector.CalcNorm() / prevVector.CalcNorm();
        var residual = 1.0;
        prevVector = nextVector;
        CourseHolder.GetInfo(1, 1 / eigenvalue, residual);
        for (var i = 2; i <= maxIter && residual > eps; i++)
        {
            var prevEigenvalue = eigenvalue;
            nextVector = SLAESolver.SolveSLAE(matrix, prevVector);
            eigenvalue = nextVector.CalcNorm() / prevVector.CalcNorm();
            residual = Math.Abs((eigenvalue - prevEigenvalue) / eigenvalue);
            prevVector = nextVector;
            CourseHolder.GetInfo(i, 1 / eigenvalue, residual);
        }

        Console.WriteLine();
        return 1 / eigenvalue;
    }
}