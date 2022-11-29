namespace CM_5.Models;

public class Vector : ICloneable
{
    public double[] VectorArray { get; set; }

    public Vector()
    {
        VectorArray = Array.Empty<double>();
    }

    public Vector(int size)
    {
        VectorArray = new double[size];
    }

    public Vector(double[] vectorArray)
    {
        VectorArray = vectorArray;
    }

    public double this[int index]
    {
        get => VectorArray[index];
        set => VectorArray[index] = value;
    }

    public int Count => VectorArray.Length;

    public static Vector operator +(Vector vector1, Vector vector2)
    {
        var sumOfVector = new Vector(vector1.Count);
        if (vector1.Count != vector2.Count) throw new Exception("Can't sum vectors");
        for (var i = 0; i < vector1.Count; i++)
        {
            sumOfVector[i] += vector1[i] + vector2[i];
        }

        return sumOfVector;
    }

    public IEnumerator<double> GetEnumerator() => (IEnumerator<double>)VectorArray.GetEnumerator();

    public double CalcNorm()
    {
        var norm = VectorArray.Sum(item => item * item);
        return Math.Sqrt(norm);
    }

    public object Clone()
    {
        var clone = new double[Count];
        Array.Copy(VectorArray, clone, Count);
        return new Vector(Count)
        {
            VectorArray = clone
        };
    }
}