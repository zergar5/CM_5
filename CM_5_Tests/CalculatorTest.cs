using CM_5.Models;
using CM_5.Tools;

namespace CM_5_Tests;

public class CalculatorTest
{
    private Matrix _matrix;
    private Vector _f;

    [SetUp]
    public void Setup()
    {
        var matrix = new[,]
        {
            { 1.0, 2.0, 3.0 },
            { 4.0, 5.0, 6.0 },
            { 7.0, 8.0, 9.0 }
        };
        _matrix = new Matrix(matrix);
        var vector = new[] { 1.0, 2.0, 3.0 };
        _f = new Vector(vector);
    }

    [TestCase(new[] { 14.0, 32.0, 50.0 })]
    public void MultiplyMatrixOnVectorTest(double[] actual)
    {
        var expected = Calculator.MultiplyMatrixOnVector(_matrix, _f);
        CollectionAssert.AreEqual(expected.VectorArray, actual);
    }
}