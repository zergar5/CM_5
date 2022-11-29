using System.Globalization;

namespace CM_5.IO;

public class EigenvaluesIO
{
    private static readonly CultureInfo _culture = CultureInfo.CreateSpecificCulture("en-US");
    private readonly string _path;
    public EigenvaluesIO(string path)
    {
        _path = path;
    }

    public void Write(double maxEigenvalue, double minEigenvalue, string fileName)
    {
        using var streamWriter = new StreamWriter(_path + fileName);
        streamWriter.WriteLine("Max eigenvalue: " + maxEigenvalue.ToString("0.00000000000000e+00", _culture));
        streamWriter.WriteLine("Min eigenvalue: " +minEigenvalue.ToString("0.00000000000000e+00", _culture));
    }
}