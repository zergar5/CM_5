using CM_5.Models;

namespace CM_5.IO;

public class MatrixIO
{
    private readonly string _path;
    public MatrixIO(string path)
    {
        _path = path;
    }

    public Matrix Read(string fileName)
    {
        using var streamReader = new StreamReader(_path + fileName);

        var matrixValues = streamReader.ReadToEnd().Split('\n');
        var inputMatrix = new double[matrixValues.Length, matrixValues[0].Split(' ').Length];
        for (var i = 0; i < inputMatrix.GetLength(0); i++)
        {
            var row = matrixValues[i].Split(' ');
            for (var j = 0; j < inputMatrix.GetLength(1); j++)
            {
                inputMatrix[i, j] = double.Parse(row[j]);
            }
        }
        var matrix = new Matrix(inputMatrix);

        return matrix;
    }
}