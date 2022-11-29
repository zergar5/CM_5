using CM_5.Models;
using CM_5.Tools;

namespace CM_5_Tests;

public class SLAESolverTest
{
    private Matrix _matrix;
    private Vector _f;

    [SetUp]
    public void Setup()
    {
        var matrix = new[,]
        {
            { 5.0, 11.0, 17.0 },
            { 11.0, 25, 39.0 },
            { 17.0, 39.0, 60.0 }
        };
        _matrix = new Matrix(matrix);
        _matrix.LDUDecomposition();

        var f = new[] { 33.0, 75.0, 116.0 };
        _f = new Vector(f);
    }

    [TestCase(new[] { 1.0000000000000049, 1.0000000000000195, 0.99999999999998579 })]
    public void SolveSLAETest(double[] actual)
    {
        var expected = SLAESolver.SolveSLAE(_matrix, _f);
        CollectionAssert.AreEqual(expected.VectorArray, actual);
    }

    [TestCase(new[] { 33.0, 2.3999999999999915, -0.99999999999998579 })]
    public void CalcYTest(double[] actual)
    {
        var expected = SLAESolver.CalcY(_matrix, _f);
        CollectionAssert.AreEqual(expected.VectorArray, actual);
    }

    [TestCase(new[] { 6.6, 3.0, 0.99999999999998579 })]
    public void CalcZTest(double[] actual)
    {
        var y = new Vector(new[] { 33.0, 2.3999999999999915, -0.99999999999998579 });
        SLAESolver.CalcZ(_matrix, y);
        CollectionAssert.AreEqual(y.VectorArray, actual);
    }

    [TestCase(new[] { 1.0000000000000049, 1.0000000000000195, 0.99999999999998579 })]
    public void CalcXTest(double[] actual)
    {
        var z = new Vector(new[] { 6.6, 3.0, 0.99999999999998579 });
        SLAESolver.CalcX(_matrix, z);
        CollectionAssert.AreEqual(z.VectorArray, actual);
    }
}