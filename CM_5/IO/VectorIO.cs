using CM_5.Models;

namespace CM_5.IO;

public class VectorIO
{
    private readonly string _path;
    public VectorIO(string path)
    {
        _path = path;
    }

    public Vector Read(string fileName)
    {
        using var streamReader = new StreamReader(_path + fileName);
        var text = streamReader.ReadLine();
        var vectorValues = text.Split(' ').Select(double.Parse).ToArray();
        var vector = new Vector(vectorValues);

        return vector;
    }
}