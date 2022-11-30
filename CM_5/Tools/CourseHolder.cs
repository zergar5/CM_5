using System.Text;

namespace CM_5.Tools;

public class CourseHolder
{
    public static void GetInfo(int iteration, double eigenvalue, double residual)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append($"\rIteration: {iteration}, ");
        stringBuilder.Append($"Eigenvalue: {eigenvalue}".Replace(",", "."));
        stringBuilder.Append(", ");
        stringBuilder.Append($"Residual: {residual}                     ".Replace(",", "."));
        Console.Write(stringBuilder);
    }
}